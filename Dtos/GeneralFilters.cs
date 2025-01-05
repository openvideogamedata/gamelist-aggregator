public class GeneralFilters
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int MaxPages { get; set; }
    public string SearchedText { get; set; }

    public GeneralFilters()
    {
        Page = 1;
        PageSize = 5;
        MaxPages = 5;
        SearchedText = "";
    }

    public GeneralFilters(int page = 1, int pageSize = 5, int maxPages = 5, string searchedText = "")
    {
        Page = page;
        PageSize = pageSize;
        MaxPages = maxPages;
        SearchedText = searchedText;
    }
}