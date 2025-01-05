namespace community.Dtos;

public class TwiterOptions
{
	public string Key { get; set; }
	public string Secret { get; set; }
	public string AuthTokenV1 { get; set; }
	public string AuthTokenSecretV1 { get; set; }
	public string ClientIdV2 { get; set; }
	public string ClientSecretV2 { get; set; }
	public string Bearer { get; set; }
	public string BaseUrl { get; set; }
	public string AuthUrl { get; set; }
	public string TweetPath { get; set; }
	public string WritePermissionQuery { get; set; }
}