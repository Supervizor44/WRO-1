using System.Linq.Expressions;
using WRO.Web.Data.Entities.ImageAggregate;
using WRO.Web.Models.Image;

namespace WRO.Web.Mappers;

public static class GalleryImageMapper
{
    public static readonly Expression<Func<GalleryImage, GalleryImageModel>> ProjectToGalleryImageModel =
        img => new GalleryImageModel
        {
            Id = img.Id,
            Path = img.Path,
            Season = img.Season
        };

    public static readonly Expression<Func<GalleryImage, ImageModel>> ProjectToImageModel =
        img => new ImageModel
        {
            Id = img.Id,
            Path = img.Path
        };
}