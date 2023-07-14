using System.ComponentModel.DataAnnotations;

namespace WRO.Web.Areas.Admin.Models.Judge;

public class SingleJudgeModel
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

    // [Display(Name = "display_profession_a")]
    public string Profession { get; set; } = string.Empty;

    // [Display(Name = "display_rekvizit_a")]
    public string BankRekvizit { get; set; } = string.Empty;

    // [Display(Name = "display_wro_experience_a")]
    public string WroExperince { get; set; } = string.Empty;

    // [Display(Name = "display_startup_experience_a")]
    public string StartupExperince { get; set; } = string.Empty;

    // [Display(Name = "display_judge_contest_category_a")]
    public string ContestCategoryName { get; set; } = string.Empty;

    // [Display(Name = "display_registration_date")]
    public DateTime RegistrationDate { get; set; }

    public string ImagePath { get; set; } = null!;
}