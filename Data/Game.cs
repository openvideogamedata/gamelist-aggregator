using System.ComponentModel.DataAnnotations.Schema;

namespace community.Data;

public class Game
{
    public long Id { get; set; }
    public string Title { get; set; }
    public DateTime FirstReleaseDate { get; set; }
    public long ExternalId { get; set; }
    public string? ExternalCoverImageId { get; set; }
    public List<Item> Items { get; set; }
    public List<GameUserTracker> GameUserTrackers { get; set; } = new List<GameUserTracker>();
    [NotMapped]
    public long NumberOfLists { get; set; }
    [NotMapped]
    public GameUserTracker? GameUserTracker { get; set; }
    [NotMapped]
    public int? Score { get; set; }
    public string CoverImageUrl => $"https://images.igdb.com/igdb/image/upload/t_cover_small/{ExternalCoverImageId}.jpg";
    public string CoverBigImageUrl => $"https://images.igdb.com/igdb/image/upload/t_cover_big/{ExternalCoverImageId}.jpg";
}
