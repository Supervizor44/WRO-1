using System.ComponentModel.DataAnnotations;

namespace WRO.Web.Models.Register;

public class RegisterJudgeModel : RegisterModel
{
    [Display(Name = "display_email")]
    [Required(ErrorMessage = "required")]
    [EmailAddress(ErrorMessage = "email_address")]
    public string Email { get; set; } = string.Empty;

    [Display(Name = "display_profession")]
    [Required(ErrorMessage = "required")]
    public string Profession { get; set; } = string.Empty;

    [Display(Name = "display_rekvizit")]
    [Required(ErrorMessage = "required")]
    public string BankRekvizit { get; set; } = string.Empty;

    [Display(Name = "display_wro_experience")]
    [Required(ErrorMessage = "required")]
    public string WroExperience { get; set; } = string.Empty;

    [Display(Name = "display_startup_experience")]
    [Required(ErrorMessage = "required")]
    public string StartupExperience { get; set; } = string.Empty;

    [Display(Name = "display_judge_contest_category")]
    [Required(ErrorMessage = "required")]
    public Guid ContestCategoryId { get; set; }
}
