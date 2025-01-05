public class GroupItem
{
    public long GameId { get; set; }
    public string GameTitle { get; set; }
    public TrackStatus TrackStatus { get; set; }
    public int Citations { get; set; }
    public int PorcentageOfCitations { get; set; }
    public DateTime FirstReleaseDate { get; set; }
    public string CoverImageUrl { get; set; }
    public int Score { get; set; }
    public int Position { get; set; }
    public long GameListId { get; set; }
    public long? FinalGameListId { get; set; }
}