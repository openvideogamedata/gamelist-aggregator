using Microsoft.EntityFrameworkCore;

namespace community.Data;

public class TrackerService 
{
    private readonly IDbContextFactory<ApplicationDbContext> _factory;
    public TrackerService(IDbContextFactory<ApplicationDbContext> factory)
    {
        this._factory = factory;
    }

    public async Task<GameUserTracker>? CreateOrUpdate(GameUserTracker gameUserTracker) 
    {
        using var context = this._factory.CreateDbContext();
        
        var tracker = await context.GameUserTrackers.FirstOrDefaultAsync(tracker => tracker.GameId == gameUserTracker.GameId
                                                && tracker.UserId == gameUserTracker.UserId);

        if (tracker is not null) {
            tracker.Status = gameUserTracker.Status;
            tracker.Note = gameUserTracker.Note;
            tracker.StatusDate = DateTime.SpecifyKind(gameUserTracker.StatusDate, DateTimeKind.Utc);
            tracker.LastUpdateDate = DateTime.UtcNow;
            tracker.Platinum = gameUserTracker.Platinum;
            context.GameUserTrackers.Update(tracker);
            gameUserTracker = tracker;
        } else {
            var newGameUserTracker = new GameUserTracker() {
                GameId = gameUserTracker.GameId,
                UserId = gameUserTracker.UserId,
                Status = gameUserTracker.Status,
                Note = gameUserTracker.Note,
                StatusDate = gameUserTracker.StatusDate,
                LastUpdateDate = DateTime.UtcNow
            };
            context.GameUserTrackers.Add(newGameUserTracker);
        }

        await context.SaveChangesAsync();

        return gameUserTracker;
    }

    public GameUserTracker? GetByGameIdAndUserId(long userId, long gameId) 
    {
        using var context = this._factory.CreateDbContext();

        var tracker = context.GameUserTrackers.FirstOrDefault(tracker => tracker.GameId == gameId 
                                                && tracker.UserId == userId);

        return tracker;
    }

    public async Task<GameUserTracker?> GetByGameIdAndUserIdAsync(long userId, long gameId) 
    {
        using var context = this._factory.CreateDbContext();

        var tracker = await context.GameUserTrackers.FirstOrDefaultAsync(tracker => tracker.GameId == gameId 
                                                && tracker.UserId == userId);

        return tracker;
    }
}