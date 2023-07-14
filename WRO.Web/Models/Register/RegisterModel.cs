using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using WRO.Web.Controllers.Attributes;
using WRO.Web.Data.Entities.ImageAggregate;
namespace WRO.Web.Models.Register;

/// <summary>
/// Hakim, Könüllü, İştirakçı qeydiyyat modellerinin base class-ı.
/// </summary>
public abstract class RegisterModel
{
    [Display(Name = "display_firstname")]
    [Required(ErrorMessage = "required")]
    public string FirstName { get; set; } = string.Empty;

    [Display(Name = "display_lastname")]
    [Required(ErrorMessage = "required")]
    public string LastName { get; set; } = string.Empty;

    [Display(Name = "display_phone_number")]
    [Required(ErrorMessage = "required")]
    [Phone(ErrorMessage = "phone_number")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Display(Name = "display_identity_number")]
    [Required(ErrorMessage = "required")]
    [StringLength(7, MinimumLength = 7, ErrorMessage = "identity_number_length")]
    public string IdentityNumber { get; set; } = string.Empty;
    
    [Display(Name = "display_id_serial_number")]
    [Required(ErrorMessage = "required")]
    [StringLength(11, MinimumLength = 10, ErrorMessage = "id_serial_number_length")]
    public string IdSerialNumber { get; set; } = string.Empty;

    [Display(Name = "display_identity_card_image")]
    [Required(ErrorMessage = "required")]
    [RequiredExtensions(".jpg", ".jpeg", ".png",".pdf")]
    [MaxAllowedFileSize(2 * 1024)] // 2 mb
    public IFormFile IdentityCardImageForm { get; set; } = null!;

    [ValidateNever]
    public IdentityCardImage IdentityCardImage { get; set; } = null!;
}