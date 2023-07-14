using WRO.Web.Data.Entities.ImageAggregate;

namespace WRO.Web.Data.Entities.NewsAggregate;

public class News : Entity, IAuditableEntity
{
    public News() { }

    public News(Image image, ICollection<NewsContext> contexts)
    {
        Image = image;
        Contexts = contexts;
    }

    public DateTime Created { get; set; }
    public DateTime? LastModified { get; set; }
    public ICollection<NewsContext> Contexts { get; set; } = null!;
    public Guid ImageId { get; set; }
    public Image Image { get; set; } = null!;
}
