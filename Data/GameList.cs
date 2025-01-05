using System.ComponentModel.DataAnnotations.Schema;
using community.Data;

public class GameList {
    public long Id { get; set; }
    public long? UserContributedId { get; set; }
    public User? UserContributed { get; set; }
    public bool ByUser { get; set; }
    public string? SourceListUrl { get; set; }
    public long? SourceId { get; set; }
    public Source? Source { get; set; }

    public long? FinalGameListId { get; set; }
    public FinalGameList? FinalGameList { get; set; }

    public DateTime DateAdded { get; set; }

    public DateTime? DateLastUpdated { get; set; }

    public List<Item> Items { get; set; }
}