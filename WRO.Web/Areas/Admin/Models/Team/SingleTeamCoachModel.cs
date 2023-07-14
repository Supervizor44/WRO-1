using System.ComponentModel.DataAnnotations;

namespace WRO.Web.Areas.Admin.Models.Team;

public class SingleTeamCoachModel
{
    //[Display(Name = "display_fullname")]
    public string FullName { get; set; } = string.Empty;

    //[Display(Name = "display_phone_number")]
    public string PhoneNumber { get; set; } = string.Empty;

    //[Display(Name = "display_identity_number")]
    public string IdentityNumber { get; set; } = string.Empty;

    //[Display(Name = "display_id_serial_number")]
    public string IdSerialNumber { get; set; } = string.Empty;

    //[Display(Name = "display_email")]
    public string Email { get; set; } = string.Empty;

    //[Display(Name = "display_birth_date")]
    public DateTime BirthDate { get; set; }

    public string CoachImagePath { get; set; } = null!;
}