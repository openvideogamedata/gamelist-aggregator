using System.ComponentModel.DataAnnotations;

public class Friendship 
{
    [Key]
    public long Id { get; set; }
    public long User1Id { get; set; }
    public User UserRequested { get; set; }
    public long User2Id { get; set; }
    public User UserReceived { get; set; }
    public FriendshipStatus Status { get; set; }
}

public enum FriendshipStatus
{
    WAITING,
    ACCEPTED,
    REJECTED
}