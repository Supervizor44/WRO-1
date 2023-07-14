using System.ComponentModel.DataAnnotations;

namespace WRO.Web.Areas.Admin.Models.Team;

public class SingleTeamExcelModel
{
    //[Display(Name = "display_team_name")]
    public string Name { get; set; } = string.Empty;

    //[Display(Name = "display_team_contest_category_a")]
    public string ContestCategoryName { get; set; } = string.Empty;

    //[Display(Name = "display_registration_date")]
    public DateTime RegistrationDate { get; set; }

    //[Display(Name = "display_team_coach")]
    public string TeamCoach { get; set; } = null!;

    //[Display(Name = "display_team_member_1")]
    public string Member1 { get; set; } = null!;

    //[Display(Name = "display_team_member_2")]
    public string Member2 { get; set; } = null!;

    //[Display(Name = "display_team_member_3")]
    public string? Member3 { get; set; }

    //[Display(Name = "display_team_member_4")]
    public string? Member4 { get; set; }

    //[Display(Name = "display_is_winner")]
    public bool IsWinner { get; set; }
}