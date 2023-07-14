using System.ComponentModel.DataAnnotations;

namespace WRO.Web.Models.Team;

public class WinnerTeamModel
{
    //[Display(Name = "display_team_name")]
    public string Name { get; set; } = string.Empty;

    //[Display(Name = "display_team_contest_category_a")]
    public string ContestCategoryName { get; set; } = string.Empty;

    public int Season { get; set; }
}
