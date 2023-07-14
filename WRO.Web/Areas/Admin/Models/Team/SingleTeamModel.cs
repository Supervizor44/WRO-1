using System.ComponentModel.DataAnnotations;

namespace WRO.Web.Areas.Admin.Models.Team;

public class SingleTeamModel
{
    public Guid Id { get; set; }

    // [Display(Name = "display_team_name")]
    public string Name { get; set; } = string.Empty;

    // [Display(Name = "display_team_contest_category_a")]
    public string ContestCategoryName { get; set; } = string.Empty;

    // [Display(Name = "display_registration_date")]
    public DateTime RegistrationDate { get; set; }

    // [Display(Name = "display_team_coach")]
    public SingleTeamCoachModel TeamCoach { get; set; } = null!;

    // [Display(Name = "display_team_members")]
    public IList<SingleTeamMemberModel> Members { get; set; } = new List<SingleTeamMemberModel>();

    public bool IsWinner { get; set; }
}
