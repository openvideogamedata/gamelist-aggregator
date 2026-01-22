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
        var pinnedLists = _gameListService.GetAllPinnedLists(userId: 0);
        var userActivity = _gameListService.GetUserActivity();
        var allTags = FilterListsCategory.GetTagsList();
        var (listsCategories, pager) = _gameListService.GetAllListsCategories(filters, userId: 0);

        return Ok(new
        {
            pinnedLists,
            userActivity,
            allTags,
            listsCategories,
            pager,
            filters
        });
    }

    [HttpGet("pinned-lists")]
    public IActionResult GetPinnedLists()
    {
        return Ok(_gameListService.GetAllPinnedLists(userId: 0));
    }

    [HttpGet("user-activity")]
    public IActionResult GetUserActivity()
    {
        return Ok(_gameListService.GetUserActivity());
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

        return Ok(new
        {
            lists,
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
}
