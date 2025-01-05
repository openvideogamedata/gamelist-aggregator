public class GameFilters : GeneralFilters {
    public TrackStatus Status { get; set; }
    public GamesOrder Order { get; set; }
    public int? TrackerYear { get; set; }

    public GameFilters(int page = 1, int pageSize = 5, int maxPages = 5, string searchedText = "")
    {
        Page = page;
        PageSize = pageSize;
        MaxPages = maxPages;
        SearchedText = searchedText;
    }

    public GameFilters(int? status, int? order, string searchedText)
    {
        try
        {
            if (EnumHelper.IsValidEnumValue(typeof(TrackStatus), status))
                Status = (TrackStatus)status.Value;
            if (EnumHelper.IsValidEnumValue(typeof(GamesOrder), order))
                Order = (GamesOrder)order.Value;
            if (!string.IsNullOrEmpty(searchedText))
                SearchedText = searchedText;
        } catch {}
    }
}

public enum GamesOrder
{
    ByLists,
    ByAvgPosition,
    ByStatusDate
};