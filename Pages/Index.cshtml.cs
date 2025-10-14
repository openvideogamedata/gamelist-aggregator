using System.Globalization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using community.Data;
using community.Dtos;
using community.Services;
using community.Utils;

namespace community.Pages;

public class IndexModel : PageModel
{
    private readonly GameListService _gameListService;
    private readonly HashSet<string> _selectedTags = new(StringComparer.OrdinalIgnoreCase);

    public IndexModel(GameListService gameListService)
    {
        _gameListService = gameListService;
    }

    public List<FinalGameList> PinnedLists { get; private set; } = new();
    public List<UserActivityData> UserActivities { get; private set; } = new();
    public List<FinalGameList> FilteredLists { get; private set; } = new();
    public Pager? Pager { get; private set; }
    public IReadOnlyCollection<string> SelectedTags => _selectedTags;
    public IReadOnlyList<string> AllTags { get; private set; } = Array.Empty<string>();
    public string SearchTerm { get; private set; } = string.Empty;
    public string? BannedStatus { get; private set; }
    public bool IsBanned => string.Equals(BannedStatus, "banned", StringComparison.OrdinalIgnoreCase);
    public string CurrentPath => string.IsNullOrEmpty(BannedStatus) ? "/" : $"/{BannedStatus}";
    public string TagsQueryValue => string.Join(",", _selectedTags);
    public FilterListsCategory? Filters { get; private set; }

    public void OnGet(string? banned, int page = 1, string? search = null, string? tags = null)
    {
        BannedStatus = banned;
        SearchTerm = search?.Trim() ?? string.Empty;

        foreach (var tag in ParseTags(tags))
        {
            _selectedTags.Add(tag);
        }

        if (_selectedTags.Count == 0)
        {
            _selectedTags.Add(Tags.All);
        }

        if (_selectedTags.Count > 1 && _selectedTags.Contains(Tags.All))
        {
            _selectedTags.Remove(Tags.All);
        }

        var currentPage = page < 1 ? 1 : page;
        var filterTags = _selectedTags.ToList();
        Filters = new FilterListsCategory(currentPage, 6, 5, filterTags, SearchTerm);
        AllTags = Filters.AllTags;

        (FilteredLists, Pager) = _gameListService.GetAllListsCategories(Filters, userId: 0);
        PinnedLists = _gameListService.GetAllPinnedLists(userId: 0);
        UserActivities = _gameListService.GetUserActivity();
    }

    public string BuildTagUrl(string tag)
    {
        var updated = new HashSet<string>(_selectedTags, StringComparer.OrdinalIgnoreCase);

        if (string.Equals(tag, Tags.All, StringComparison.OrdinalIgnoreCase))
        {
            updated.Clear();
            updated.Add(Tags.All);
        }
        else
        {
            if (updated.Contains(Tags.All))
            {
                updated.Remove(Tags.All);
            }

            if (!updated.Add(tag))
            {
                updated.Remove(tag);
            }

            if (updated.Count == 0)
            {
                updated.Add(Tags.All);
            }
        }

        var tagsParam = string.Join(",", updated);
        var queryValues = new Dictionary<string, string?>();

        if (!string.IsNullOrEmpty(SearchTerm))
        {
            queryValues["search"] = SearchTerm;
        }
        if (!string.IsNullOrEmpty(tagsParam))
        {
            queryValues["tags"] = tagsParam;
        }

        queryValues["page"] = "1";
        return QueryHelpers.AddQueryString(CurrentPath, queryValues);
    }

    public bool TagIsSelected(string tag) => _selectedTags.Contains(tag);

    public string BuildSearchAction()
    {
        var queryValues = new Dictionary<string, string?>();
        if (!string.IsNullOrEmpty(TagsQueryValue))
        {
            queryValues["tags"] = TagsQueryValue;
        }
        queryValues["page"] = "1";
        return QueryHelpers.AddQueryString(CurrentPath, queryValues);
    }

    public string BuildPageUrl(int pageNumber)
    {
        var queryValues = new Dictionary<string, string?>();
        if (!string.IsNullOrEmpty(SearchTerm))
        {
            queryValues["search"] = SearchTerm;
        }
        if (!string.IsNullOrEmpty(TagsQueryValue))
        {
            queryValues["tags"] = TagsQueryValue;
        }
        queryValues["page"] = pageNumber.ToString(CultureInfo.InvariantCulture);
        return QueryHelpers.AddQueryString(CurrentPath, queryValues);
    }

    public string ResolveCoverImage(string? source)
    {
        if (string.IsNullOrWhiteSpace(source) || source.Contains("/.jpg", StringComparison.OrdinalIgnoreCase))
        {
            return "https://images.igdb.com/igdb/image/upload/t_cover_big/nocover.png";
        }

        return source;
    }

    public string GetUserInitials(User? user)
    {
        if (user == null)
        {
            return "?";
        }

        var nickname = user.FullName;
        if (string.IsNullOrWhiteSpace(nickname))
        {
            nickname = user.GivenName ?? user.NameIdentifier ?? "?";
        }

        var parts = nickname.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 0)
        {
            return nickname.Length > 0 ? nickname.Substring(0, 1).ToUpperInvariant() : "?";
        }

        if (parts.Length == 1)
        {
            return parts[0][0].ToString().ToUpperInvariant();
        }

        return (char.ToUpperInvariant(parts[0][0]).ToString() + char.ToUpperInvariant(parts[^1][0])).ToUpperInvariant();
    }

    private static IEnumerable<string> ParseTags(string? tags)
    {
        if (string.IsNullOrWhiteSpace(tags))
        {
            yield break;
        }

        foreach (var tag in tags.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
        {
            yield return tag.ToLowerInvariant();
        }
    }
}
