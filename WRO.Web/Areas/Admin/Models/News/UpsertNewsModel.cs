using System.ComponentModel.DataAnnotations;
using WRO.Web.Controllers.Attributes;

namespace WRO.Web.Areas.Admin.Models.News;

public class UpsertNewsModel
{
    // [Display(Name = "display_title")]
    public string Title { get; set; } = string.Empty;

    // [Display(Name = "display_body")]
    public string Body { get; set; } = string.Empty;

    // [Display(Name = "display_image")]
    [RequiredExtensions(".jpg", ".jpeg", ".png")]
    public IFormFile Image { get; set; } = null!;
}
