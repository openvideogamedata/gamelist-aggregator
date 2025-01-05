using System.ComponentModel.DataAnnotations.Schema;

namespace community.Data;

public class Item
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
}