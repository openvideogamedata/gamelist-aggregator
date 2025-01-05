using System.Text.Json.Serialization;

public class GetGameApiReturn
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("cover")]
    public Cover Cover { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("rating")]
    public decimal Rating { get; set; }

    [JsonPropertyName("parent_game")]
    public long ParentGame { get; set; }

    [JsonPropertyName("first_release_date")]
    public long FirstReleaseDate { get; set; }

    [JsonPropertyName("category")]
    public int Category { get; set; }

    public string FirstReleaseDateText { get; set; }

    public GetGameApiReturn()
    {
        this.Cover = new Cover();
    }
}

public class Cover
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("image_id")]
    public string ImageId { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}