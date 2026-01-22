using Microsoft.AspNetCore.Mvc;
using community.Data;

namespace community.Controllers;

[ApiController]
[Route("api/home")]
public class HomeController : ControllerBase
{
    private readonly GameListService _gameListService;

    public HomeController(GameListService gameListService)
    {
        _gameListService = gameListService;
    }

    [HttpGet]
    public IActionResult GetHome(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 6,
        [FromQuery] int maxPages = 5,
        [FromQuery] string? tags = null,
        [FromQuery] string? search = null)
    {
        var filters = BuildFilters(page, pageSize, maxPages, tags, search);
        var pinnedLists = MapFinalGameLists(_gameListService.GetAllPinnedLists(userId: 0));
        var userActivity = MapUserActivity(_gameListService.GetUserActivity());
        var allTags = FilterListsCategory.GetTagsList();
        var (listsCategories, pager) = _gameListService.GetAllListsCategories(filters, userId: 0);
        var mappedListsCategories = MapFinalGameLists(listsCategories);

        return Ok(new
        {
            pinnedLists,
            userActivity,
            allTags,
            listsCategories = mappedListsCategories,
            pager,
            filters
        });
    }

    [HttpGet("pinned-lists")]
    public IActionResult GetPinnedLists()
    {
        return Ok(MapFinalGameLists(_gameListService.GetAllPinnedLists(userId: 0)));
    }

    [HttpGet("user-activity")]
    public IActionResult GetUserActivity()
    {
        return Ok(MapUserActivity(_gameListService.GetUserActivity()));
    }

    [HttpGet("tags")]
    public IActionResult GetTags()
    {
        return Ok(FilterListsCategory.GetTagsList());
    }

    [HttpGet("lists")]
    public IActionResult GetLists(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 6,
        [FromQuery] int maxPages = 5,
        [FromQuery] string? tags = null,
        [FromQuery] string? search = null)
    {
        var filters = BuildFilters(page, pageSize, maxPages, tags, search);
        var (lists, pager) = _gameListService.GetAllListsCategories(filters, userId: 0);
        var mappedLists = MapFinalGameLists(lists);

        return Ok(new
        {
            lists = mappedLists,
            pager,
            filters
        });
    }

    private static FilterListsCategory BuildFilters(
        int page,
        int pageSize,
        int maxPages,
        string? tags,
        string? search)
    {
        var tagsToFilter = ParseTags(tags);
        return new FilterListsCategory(
            page,
            pageSize,
            maxPages,
            tagsToFilter,
            search ?? "");
    }

    private static List<string> ParseTags(string? tags)
    {
        if (string.IsNullOrWhiteSpace(tags))
        {
            return new List<string> { Tags.All };
        }

        var parsed = tags
            .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(tag => tag.ToLowerInvariant())
            .Distinct()
            .ToList();

        return parsed.Count == 0 ? new List<string> { Tags.All } : parsed;
    }

    private static List<HomeFinalGameListDto> MapFinalGameLists(IEnumerable<FinalGameList> lists)
    {
        return lists.Select(list => new HomeFinalGameListDto(
            list.Id,
            list.Title,
            list.Year,
            list.NumberOfGames,
            list.NumberOfSources,
            list.Slug,
            list.TopThreeWinners.Select(winner => new HomeWinnerDto(
                winner.GameId,
                winner.GameTitle,
                winner.CoverImageUrl)).ToList())).ToList();
    }

    private static List<HomeUserActivityDto> MapUserActivity(IEnumerable<UserActivityData> activity)
    {
        return activity.Select(item => new HomeUserActivityDto(
            item.Activity,
            item.DateAdded,
            item.ItemsTracked,
            item.UserProfileUrl,
            item.GameListUrl,
            item.User is null
                ? null
                : new HomeUserDto(item.User.FullName, item.User.GetUserPicture()),
            item.MostRecentTracker is null
                ? null
                : new HomeTrackerDto(item.MostRecentTracker.Status),
            item.GameList?.FinalGameList?.GetFullName())).ToList();
    }

    private sealed record HomeFinalGameListDto(
        long Id,
        string Title,
        int? Year,
        int NumberOfGames,
        int NumberOfSources,
        string Slug,
        List<HomeWinnerDto> TopThreeWinners);

    private sealed record HomeWinnerDto(
        long GameId,
        string GameTitle,
        string CoverImageUrl);

    private sealed record HomeUserActivityDto(
        ActivityType Activity,
        DateTime DateAdded,
        int ItemsTracked,
        string UserProfileUrl,
        string GameListUrl,
        HomeUserDto? User,
        HomeTrackerDto? MostRecentTracker,
        string? GameListName);

    private sealed record HomeUserDto(
        string FullName,
        string[]? UserPicture);

    private sealed record HomeTrackerDto(
        TrackStatus Status);
}
