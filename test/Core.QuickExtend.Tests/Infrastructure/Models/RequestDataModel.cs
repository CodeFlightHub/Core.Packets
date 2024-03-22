namespace Core.QuickExtend.Tests.Infrastructure.Models;

public class RequestDataModel
{
    public int UserId { get; set; }
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Body { get; set; } = default!;
}
