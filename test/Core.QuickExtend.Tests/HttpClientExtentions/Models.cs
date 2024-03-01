namespace Core.QuickExtend.Tests.HttpClientExtentions;

public class RequestData
{
    public int UserId { get; set; }
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Body { get; set; } = default!;

}

public class ResponseData
{
    public int UserId { get; set; }
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Body { get; set; } = default!;
}
