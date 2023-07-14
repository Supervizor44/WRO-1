using System.ComponentModel.DataAnnotations;
using WRO.Web.Controllers.Attributes;

namespace WRO.Web.Areas.Admin.Models.Image;

public class UpsertImageModel
{
    [Required(ErrorMessage = "required")]
    [RequiredExtensions(".jpg", ".jpeg", ".png")]
    [MaxAllowedFileSize(2 * 1024)] // 2 mb
    public IFormFileCollection Images { get; set; } = null!;
}
