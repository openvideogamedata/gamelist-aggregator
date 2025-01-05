using System.ComponentModel.DataAnnotations;

public class UserNotification 
{
    public long Id { get; set; }
    [Required]
    public string Message { get; set; }
    [Required]
    public bool Read { get; set; }
    [Required]
    public DateTime DateAdded { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }
}