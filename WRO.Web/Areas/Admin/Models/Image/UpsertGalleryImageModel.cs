using System.ComponentModel.DataAnnotations;
using WRO.Web.Controllers.Attributes;

namespace WRO.Web.Areas.Admin.Models.Image;

public class UpsertGalleryImageModel : UpsertImageModel
{
    [Required(ErrorMessage = "required")]
    // [Display(Name = "display_season")]
    [SeasonRange]
    public int Season { get; set; }
}
