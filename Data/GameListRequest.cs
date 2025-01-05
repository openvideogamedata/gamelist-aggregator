using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace community.Data;

public class GameListRequest
{
    public long Id { get; set; }
    public string SourceListUrl { get; set; }
    public string SourceName { get; set; }
    public string HostUrl { get; set; }
    public long FinalGameListId { get; set; }
    public FinalGameList FinalGameList { get; set; }
    public long Score { get; set; }
    public DateTime DateAdded { get; set; }
    public long UserPostedId { get; set; }
    public User UserPosted { get; set; }
    public bool Hidden { get; set; }
    public List<GameRequest> GameRequests { get; set; }
    public ICollection<User> UsersLiked { get; set; }
    public ICollection<User> UsersDisliked { get; set; }
    
    [NotMapped]
    public bool Updating { get; set; }

    private void SetScore() {
        this.Score = this.UsersLiked.Count - this.UsersDisliked.Count;
    }

    public void GiveLike(User user) {
        this.UsersDisliked.Remove(user);
        this.UsersLiked.Add(user);
        this.SetScore();
    }

    public void GiveDislike(User user) {
        this.UsersDisliked.Add(user);
        this.UsersLiked.Remove(user);
        this.SetScore();
    }

    public void RemoveLike(User user) {
        this.UsersLiked.Remove(user);
        this.SetScore();
    }

    public void RemoveDislike(User user) {
        this.UsersDisliked.Remove(user);
        this.SetScore();
    }
}