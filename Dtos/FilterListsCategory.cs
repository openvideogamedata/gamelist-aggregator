using System.Reflection;
using community.Utils;

public class FilterListsCategory : GeneralFilters
{
    public List<string> TagsToFilter { get; set; }
    public List<string> AllTags { get; set; }

    public FilterListsCategory(int page, int pageSize, int maxPages, List<string> tagsToFilter, string searchedListText)
    {
        Page = page;
        PageSize = pageSize;
        MaxPages = maxPages;
        AllTags = GetTagsList();
        TagsToFilter = tagsToFilter;
        SearchedText = searchedListText;
    }

    public static List<string> GetTagsList()
    {
        List<string> tagsList = new List<string>();
        Type tagsType = typeof(Tags);
        FieldInfo[] fields = tagsType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

        foreach (FieldInfo field in fields)
        {
            object? fieldValue = field.GetValue(null);

            if (fieldValue is string tagValue)
            {
                tagsList.Add(tagValue);
            }
        }

        return tagsList;
    }
}