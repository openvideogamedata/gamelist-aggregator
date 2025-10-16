using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using community.Data;
using community.Dtos;

namespace community.Services;

public sealed class ChallengeService
{
    private const int MaxGamesPerChallenge = 3;

    private readonly GameListService _gameListService;
    private readonly TrackerService _trackerService;

    public ChallengeService(GameListService gameListService, TrackerService trackerService)
    {
        _gameListService = gameListService;
        _trackerService = trackerService;
    }

    public MicroChallengeDto? BuildChallenge(long? userId, DateTime? referenceDate = null)
    {
        var lists = _gameListService.GetAllPinnedLists(userId ?? 0);
        return BuildChallengeFromLists(lists, userId, referenceDate);
    }

    public MicroChallengeDto? BuildChallengeFromLists(IEnumerable<FinalGameList>? sourceLists, long? userId, DateTime? referenceDate = null)
    {
        var lists = sourceLists?.Where(list => list is not null).Cast<FinalGameList>().ToList();
        if (lists is null || lists.Count == 0)
            return null;

        var eligibleLists = lists
            .Select(list => new
            {
                List = list,
                Games = list.TopThreeWinners
                    .Where(game => TrackStatusConsidered(game.TrackStatus))
                    .Take(MaxGamesPerChallenge)
                    .ToList()
            })
            .Where(x => x.Games.Count > 0)
            .ToList();

        if (eligibleLists.Count == 0)
        {
            var fallback = lists.Select(list => new
            {
                List = list,
                Games = list.TopThreeWinners.Take(MaxGamesPerChallenge).ToList()
            })
            .FirstOrDefault(x => x.Games.Count > 0);

            if (fallback is null)
                return null;

            eligibleLists.Add(fallback);
        }

        var seedDate = DateOnly.FromDateTime(referenceDate ?? DateTime.UtcNow);
        var chosenIndex = seedDate.DayNumber % eligibleLists.Count;
        var chosen = eligibleLists[chosenIndex];

        var challengeId = $"{seedDate:yyyyMMdd}-{chosen.List.Id}";
        var tags = (chosen.List.Tags ?? string.Empty)
            .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        return new MicroChallengeDto(
            challengeId: challengeId,
            finalGameListId: chosen.List.Id,
            sourceTitle: chosen.List.Title,
            sourceYear: chosen.List.Year,
            sourceSlug: chosen.List.Slug,
            sourceTags: tags,
            suggestedGames: chosen.Games);
    }

    public async Task ApplyTrackerStatusAsync(MicroChallengeDto challenge, long userId, TrackStatus status, CancellationToken cancellationToken = default)
    {
        if (challenge is null || userId <= 0 || challenge.SuggestedGames.Count == 0)
            return;

        foreach (var game in challenge.SuggestedGames)
        {
            if (!ShouldUpdateStatus(game.TrackStatus, status))
                continue;

            var tracker = new GameUserTracker
            {
                GameId = game.GameId,
                UserId = userId,
                Status = status,
                StatusDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow
            };

            cancellationToken.ThrowIfCancellationRequested();
            var updateTask = _trackerService.CreateOrUpdate(tracker);
            if (updateTask is not null)
            {
                await updateTask;
            }
        }
    }

    private static bool TrackStatusConsidered(TrackStatus status)
    {
        return status == TrackStatus.None ||
               status == TrackStatus.ToPlay ||
               status == TrackStatus.Playing;
    }

    private static bool ShouldUpdateStatus(TrackStatus currentStatus, TrackStatus desiredStatus)
    {
        if (desiredStatus == TrackStatus.ToPlay)
            return currentStatus == TrackStatus.None;

        if (desiredStatus == TrackStatus.Playing)
            return currentStatus == TrackStatus.None || currentStatus == TrackStatus.ToPlay;

        if (desiredStatus == TrackStatus.Played || desiredStatus == TrackStatus.Beaten)
            return currentStatus != TrackStatus.Beaten && currentStatus != TrackStatus.Played;

        return false;
    }
}
