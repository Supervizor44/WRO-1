namespace WRO.Web.Data.Entities.ImageAggregate;

public class GalleryImage : Image
{
    public GalleryImage() { }

    public GalleryImage(string name, string path, int season) : base(name, path)
    {
        Season = season;
    }

    public int Season { get; set; }
}