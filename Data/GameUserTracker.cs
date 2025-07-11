using System.ComponentModel.DataAnnotations;
using community.Data;

public class GameUserTracker
{
    [Key]
    public long Id { get; set; }

    public long UserId { get; set; }
    public User? User { get; set; }

    public long GameId { get; set; }
    public Game? Game { get; set; }

    public TrackStatus Status { get; set; }

    public DateTime LastUpdateDate { get; set; }
    public DateTime StatusDate { get; set; }

    public string? Note { get; set; }

    public bool Platinum { get; set; } = false;

    public GameUserTracker()
    {

    }

    public GameUserTracker(long userId, long gameId, TrackStatus status, string note)
    {
        this.UserId = userId;
        this.GameId = gameId;
        this.Status = status;
        this.LastUpdateDate = DateTime.UtcNow;
        this.Note = note;
    }

    public string GetTrackStatusDate()
    {
        if (StatusDate == DateTime.MinValue) { return ""; }
        return $" ({StatusDate:yyyy-MM-dd})";
    }
    
    public bool HasStatusDate() {
        return StatusDate != DateTime.MinValue;
    }
}

public enum TrackStatus {
    None,
    ToPlay,
    Playing,
    Beaten,
    Abandoned,
    Played,
}

public record TrackFilters {
    public TrackStatus TrackStatus { get; set; }
    public int TrackStatusCount { get; set; }
}