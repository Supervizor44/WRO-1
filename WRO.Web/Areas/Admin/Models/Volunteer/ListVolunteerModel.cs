using System.ComponentModel.DataAnnotations;

namespace WRO.Web.Areas.Admin.Models.Volunteer;

public class ListVolunteerModel
{
    public Guid Id { get; set; }

   // [Display(Name = "display_fullname")]
    public string FullName { get; set; } = string.Empty;

    //[Display(Name = "display_phone_number")]
    public string PhoneNumber { get; set; } = string.Empty;

    //[Display(Name = "display_email")]
    public string Email { get; set; } = string.Empty;

    //[Display(Name = "display_registration_date")]
    public DateTime RegistrationDate { get; set; }
}
