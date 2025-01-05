public class FriendsListComparisonResult
{
    public IList<long> CoincidentGameIds { get; set; } = new List<long>();
    public double CompatibilityPercentage { get; set; } = 0;
    public long UserComparingListId { get; set; } = 0;

    public FriendsListComparisonResult(GameList listCompared, GameList listComparing)
    {
        if (listCompared != null && listComparing != null && listCompared.Items != null && listComparing.Items != null)
        {
            CoincidentGameIds = listCompared.Items
                                            .Where(x => listComparing.Items.Select(x => x.GameId).Contains(x.GameId))
                                            .Select(x => x.GameId).ToList();
            CompatibilityPercentage = ((double)CoincidentGameIds.Count/(double)listCompared.Items.Count) * 100.0;
            CompatibilityPercentage = Math.Round(CompatibilityPercentage, 2);
            UserComparingListId = listComparing.Id;
        }
    }
}