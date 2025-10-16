using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using community.Data;

namespace community.Dtos;

public sealed class MicroChallengeDto
{
    public MicroChallengeDto(
        string challengeId,
        long? finalGameListId,
        string sourceTitle,
        int? sourceYear,
        string? sourceSlug,
        IEnumerable<string> sourceTags,
        IEnumerable<GroupItem> suggestedGames,
        bool isAccepted = false,
        bool isCompleted = false)
    {
        ChallengeId = challengeId;
        FinalGameListId = finalGameListId;
        SourceTitle = sourceTitle;
        SourceYear = sourceYear;
        SourceSlug = sourceSlug;
        SourceTags = new ReadOnlyCollection<string>(sourceTags?.Select(tag => tag?.Trim() ?? string.Empty).Where(tag => !string.IsNullOrWhiteSpace(tag)).Distinct().ToList() ?? new List<string>());
        SuggestedGames = new ReadOnlyCollection<GroupItem>(suggestedGames?.ToList() ?? new List<GroupItem>());
        IsAccepted = isAccepted;
        IsCompleted = isCompleted;
    }

    public string ChallengeId { get; }
    public long? FinalGameListId { get; }
    public string SourceTitle { get; }
    public int? SourceYear { get; }
    public string? SourceSlug { get; }
    public IReadOnlyList<string> SourceTags { get; }
    public IReadOnlyList<GroupItem> SuggestedGames { get; }
    public bool IsAccepted { get; }
    public bool IsCompleted { get; }

    public MicroChallengeDto Accept() =>
        new MicroChallengeDto(ChallengeId, FinalGameListId, SourceTitle, SourceYear, SourceSlug, SourceTags, SuggestedGames, true, IsCompleted);

    public MicroChallengeDto Complete() =>
        new MicroChallengeDto(ChallengeId, FinalGameListId, SourceTitle, SourceYear, SourceSlug, SourceTags, SuggestedGames, true, true);
}
