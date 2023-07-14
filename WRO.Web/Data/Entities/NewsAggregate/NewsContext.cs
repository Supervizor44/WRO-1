namespace WRO.Web.Data.Entities.NewsAggregate;

public class NewsContext : Entity
{
    public NewsContext() { }

    public NewsContext(string title, string body, string culture)
    {
        Title = title;
        Body = body;
        Culture = culture;
    }

    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public Guid NewsId { get; set; }
    public News News { get; set; } = null!;
    public string Culture { get; set; } = string.Empty;
}
