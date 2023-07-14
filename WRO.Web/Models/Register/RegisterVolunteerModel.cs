using System.ComponentModel.DataAnnotations;
using WRO.Web.Data.Entities.ImageAggregate;

namespace WRO.Web.Models.Register;

public class RegisterVolunteerModel : RegisterModel
{
    [Display(Name = "display_email")]
    [Required(ErrorMessage = "required")]
    [EmailAddress(ErrorMessage = "email_address")]
    public string Email { get; set; } = string.Empty;

    [Display(Name = "display_profession_at_university")]
    [Required(ErrorMessage = "required")]
    public string ProfessionAtUniversity { get; set; } = string.Empty;

    [Display(Name = "display_volunteer_experience")]
    [Required(ErrorMessage = "required")]
    public string VolunteerExperience { get; set; } = string.Empty;

    [Display(Name = "display_known_foreign_langs")]
    [Required(ErrorMessage = "required")]
    public string KnownForeignLanguages { get; set; } = string.Empty;

}
