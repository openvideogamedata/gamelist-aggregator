using System.ComponentModel.DataAnnotations.Schema;
using community.Data;

public class GameRequest {
    public long Id { get; set; }
    public int Position { get; set; }
    public string GameTitle { get; set; }
    public long GameId { get; set; }
    public Game Game { get; set; }
    [NotMapped]
    public string FirstReleaseDate { get; set; }

    public long GameListRequestId { get; set; }
    public GameListRequest GameListRequest { get; set; }
}