using community.Data;
using community.Utils;

public class GamePageResults
{
    public GamePageResults(List<Item> citations, Pager pager, int numberOfCategories, string mostCitedCategory, string mostCitedCategoryUrl)
    {
        Citations = citations;
        PagerResult = pager;
        NumberOfCategories = numberOfCategories;
        MostCitedCategory = mostCitedCategory;
        MostCitedCategoryUrl = mostCitedCategoryUrl;
    }

    public List<Item> Citations { get; set; }
    public Pager PagerResult { get; set; }
    public int NumberOfCategories { get; set; }
    public string MostCitedCategory { get; set; }
    public string MostCitedCategoryUrl { get; set; }
}