using System.Text.Json.Serialization;

public class AuthTweeterApiReturn
{
    [JsonPropertyName("token_type")]
    public string TokenType { get; set; }

    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }
}