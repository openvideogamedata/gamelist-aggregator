namespace community.Dtos;

public class ResponseToPage
{
	public bool Success { get; set; }
	public string Reason { get; set; }

    public ResponseToPage(bool success)
    {
        Success = success;
    }

    public ResponseToPage(bool success, string reason)
    {
        Success = success;
        Reason = reason;
    }
}