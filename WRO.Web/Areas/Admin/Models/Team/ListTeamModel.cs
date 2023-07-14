using System.ComponentModel.DataAnnotations;

namespace WRO.Web.Areas.Admin.Models.Team;

public class ListTeamModel
{
    public Guid Id { get; set; }

   // [Display(Name = "display_team_name")]
    public string Name { get; set; } = string.Empty;

   // [Display(Name = "display_team_contest_category_a")]
    public string ContestCategoryName { get; set; } = string.Empty;

    // [Display(Name = "display_team_coach")]
    public string TeamCoachFullName { get; set; } = string.Empty;

    // [Display(Name = "display_registration_date")]
    public DateTime RegistrationDate { get; set; }

    // [Display(Name = "display_is_winner")]
    public bool IsWinner { get; set; }
}
