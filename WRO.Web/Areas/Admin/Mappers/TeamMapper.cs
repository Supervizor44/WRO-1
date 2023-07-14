using System.Linq.Expressions;
using WRO.Web.Areas.Admin.Models.Team;
using WRO.Web.Data.Entities.RegistrantAggregate;

namespace WRO.Web.Areas.Admin.Mappers;

public static class TeamMapper
{
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
                IdSerialNumber = team.TeamCoach.IdSerialNumber,
                Email = team.TeamCoach.Email,
                BirthDate = team.TeamCoach.BirthDate,
                CoachImagePath = team.TeamCoach.IdentityCardImage.Path
            },
            Members = team.Members.Select(member => new SingleTeamMemberModel
            {
                FullName = $"{member.FirstName} {member.LastName}",
                PhoneNumber = member.PhoneNumber,
                IdentityNumber = member.IdentityNumber,
                IdSerialNumber = member.IdSerialNumber,
                Instuition = member.Instuition,
                BirthDate = member.BirthDate,
                MemberImagePath = member.IdentityCardImage.Path
            }).ToList()
        };

    public static SingleTeamExcelModel MapToExcelModel(SingleTeamModel team)
    {
        return new()
        {
            Name = team.Name,
            ContestCategoryName = team.ContestCategoryName,
            RegistrationDate = team.RegistrationDate,
            TeamCoach = FormatTeamCoach(),
            Member1 = FormatTeamMember(0),
            Member2 = FormatTeamMember(1),
            Member3 = team.Members.Count == 3 ? FormatTeamMember(2) : string.Empty,
            Member4 = team.Members.Count == 4 ? FormatTeamMember(3) : string.Empty,
            IsWinner = team.IsWinner
        };

        string FormatTeamCoach()
        {
            return $"{team.TeamCoach.FullName}, {team.TeamCoach.PhoneNumber}, {team.TeamCoach.IdentityNumber}, {team.TeamCoach.Email}, {team.TeamCoach.BirthDate:d}";
        }

        string FormatTeamMember(int index)
        {
            return $"{team.Members[index].FullName}, {team.Members[index].PhoneNumber}, {team.Members[index].IdentityNumber}, {team.Members[index].Instuition}, {team.Members[index].BirthDate:d}";
        }
    }
}