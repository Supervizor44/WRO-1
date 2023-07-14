using System.ComponentModel.DataAnnotations;

namespace WRO.Web.Models.Register;

public class RegisterTeamModel
{
    [Display(Name = "display_team_name")]
    [Required(ErrorMessage = "required")]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "display_team_contest_category")]
    [Required(ErrorMessage = "required")]
    public Guid ContestCategoryId { get; set; }

    [Display(Name = "display_team_coach")]
    [Required(ErrorMessage = "required")]
    public TeamCoachModel TeamCoach { get; set; } = null!;

    [Display(Name = "display_team_members")]
    [Required(ErrorMessage = "required")]
    public IList<TeamMemberModel> Members { get; set; } = null!;

    public class TeamCoachModel : RegisterModel
    {
        [Display(Name = "display_email")]
        [Required(ErrorMessage = "required")]
        [EmailAddress(ErrorMessage = "email_address")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "display_birth_date")]
        [Required(ErrorMessage = "required")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }

    public class TeamMemberModel : RegisterModel
    {
        [Display(Name = "display_instuition")]
        [Required(ErrorMessage = "required")]
        public string Instuition { get; set; } = string.Empty;

        [Display(Name = "display_birth_date")]
        [Required(ErrorMessage = "required")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}