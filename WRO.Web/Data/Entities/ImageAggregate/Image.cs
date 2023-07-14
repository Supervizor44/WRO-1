namespace WRO.Web.Data.Entities.ImageAggregate;

public class Image : Entity
{
    public Image() { }

    public Image(string name, string path)
    {
        Name = name;
        Path = path;
    }

    public string Name { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
}
