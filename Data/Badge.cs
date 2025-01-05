using System.ComponentModel.DataAnnotations;
using System.Text.Json;

public class Badge 
{
    [Key]
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string PixelArt { get; set; }
    public int Priority { get; set; }
    public bool AutomaticallyGiven { get; set; }

    public ICollection<User> Users { get; set; }

    public string[]? GetPixelArt()
    {
        try
        {
            if (!string.IsNullOrEmpty(PixelArt))
                return JsonSerializer.Deserialize<string[]>(PixelArt);
            return null;
        }
        catch(Exception e)
        {
            Console.WriteLine($"[ERRO] - GetPixelArt - {e.Message}", e);
            return null;
        }
    }
}