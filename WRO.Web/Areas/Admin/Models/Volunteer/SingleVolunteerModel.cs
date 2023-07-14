using System.ComponentModel.DataAnnotations;

namespace WRO.Web.Areas.Admin.Models.Volunteer;

public class SingleVolunteerModel
{
    public Guid Id { get; set; }

   // [Display(Name = "display_fullname")]
    public string FullName { get; set; } = string.Empty;

   // [Display(Name = "display_phone_number")]
    public string PhoneNumber { get; set; } = string.Empty;

   // [Display(Name = "display_email")]
    public string Email { get; set; } = string.Empty;

   // [Display(Name = "display_identity_number")]
    public string IdentityNumber { get; set; } = string.Empty;

   // [Display(Name = "display_id_serial_number")]
    public string IdSerialNumber { get; set; } = string.Empty;

   // [Display(Name = "display_profession_at_university_a")]
    public string ProfessionAtUniversity { get; set; } = string.Empty;

   //[Display(Name = "display_volunteer_experience_a")]
    public string VolunteerExperince { get; set; } = string.Empty;

   // [Display(Name = "display_known_foreign_langs_a")]
    public string KnownForeignLanguages { get; set; } = string.Empty;

   // [Display(Name = "display_registration_date")]
    public DateTime RegistrationDate { get; set; }

    public string ImagePath { get; set; } = null!;
}