using community.Dtos;

public class TopWinners
{
    public List<GroupItem> TopGames { get; set; }
    public TrackerStatsViewModel TrackerStats { get; set; }

    public TopWinners(IList<GroupItem>? topGames)
    {
        TopGames = topGames != null ? topGames.ToList() : new List<GroupItem>();
        TrackerStats = new TrackerStatsViewModel(TopGames);
    }
}