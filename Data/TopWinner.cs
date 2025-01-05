using System.ComponentModel.DataAnnotations.Schema;

namespace community.Data;

public class TopWinner
{
    public long Id { get; set; }
    public int Position { get; set; }
    public string GameTitle { get; set; }
    public long GameId { get; set; }
    public Game Game { get; set; }
    public long GameListId { get; set; }
    public GameList GameList { get; set; }
    public long? FinalGameListId { get; set; }
    public FinalGameList? FinalGameList { get; set; }
    public int Score { get; set; }
    public int Citations { get; set; }
    public int PorcentageOfCitations { get; set; }
    public DateTime FirstReleaseDate { get; set; }
    public string CoverImageUrl { get; set; }
    public bool ByUser { get; set; }

    [NotMapped]
    public TrackStatus TrackStatus { get; set; }
}