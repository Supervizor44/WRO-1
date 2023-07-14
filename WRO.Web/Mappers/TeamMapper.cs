using System.Linq.Expressions;
using WRO.Web.Areas.Admin.Models.Team;
using WRO.Web.Data.Entities.RegistrantAggregate;
using WRO.Web.Models.Team;

namespace WRO.Web.Mappers;

public static class TeamMapper
{
    public static readonly Expression<Func<Team, WinnerTeamModel>> ProjectToWinnerModel =
        team => new WinnerTeamModel
        {
            Name = team.Name,
            ContestCategoryName = team.ContestCategory.Name,
            Season = team.Created.Year
        };
    public readonly static Expression<Func<Team, ListTeamModel>> ProjectToListModel =
        team => new ListTeamModel
        {
            Id = team.Id,
            Name = team.Name,
            ContestCategoryName = team.ContestCategory.Name,
            TeamCoachFullName = $"{team.TeamCoach.FirstName} {team.TeamCoach.LastName}",
            RegistrationDate = team.Created,
            IsWinner = team.IsWinner
        };

    public readonly static Expression<Func<Team, SingleTeamModel>> ProjectToSingleModel =
        team => new SingleTeamModel
        {
            Id = team.Id,
            Name = team.Name,
            ContestCategoryName = team.ContestCategory.Name,
            RegistrationDate = team.Created,
            IsWinner = team.IsWinner,
            TeamCoach = new()
            {
                FullName = $"{team.TeamCoach.FirstName} {team.TeamCoach.LastName}",
                PhoneNumber = team.TeamCoach.PhoneNumber,
                IdentityNumber = team.TeamCoach.IdentityNumber,
                Email = team.TeamCoach.Email,
                BirthDate = team.TeamCoach.BirthDate
            },
            Members = team.Members.Select(member => new SingleTeamMemberModel
            {
                FullName = $"{member.FirstName} {member.LastName}",
                PhoneNumber = member.PhoneNumber,
                IdentityNumber = member.IdentityNumber,
                Instuition = member.Instuition,
                BirthDate = member.BirthDate
            }).ToList()
        };
}
