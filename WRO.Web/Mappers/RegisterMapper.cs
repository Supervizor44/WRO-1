using WRO.Web.Data.Entities.RegistrantAggregate;
using WRO.Web.Data.Entities.ImageAggregate;
using WRO.Web.Models.Register;

namespace WRO.Web.Mappers;

public static class RegisterMapper
{
    public static Judge MapToJudge(this RegisterJudgeModel model)
    {
        return new(model.FirstName,
            model.LastName,
            model.PhoneNumber,
            model.IdentityNumber.ToUpper(),
            model.IdSerialNumber,
            model.Email,
            model.Profession,
            model.BankRekvizit,
            model.WroExperience,
            model.StartupExperience,
            model.ContestCategoryId,
            model.IdentityCardImage);
    }

    public static Volunteer MapToVolunteer(this RegisterVolunteerModel model)
    {
        return new(model.FirstName,
            model.LastName,
            model.PhoneNumber,
            model.IdentityNumber.ToUpper(),
            model.IdSerialNumber,
            model.Email,
            model.ProfessionAtUniversity,
            model.VolunteerExperience,
            model.KnownForeignLanguages,
            model.IdentityCardImage);
    }

    public static Team MapToTeam(this RegisterTeamModel model)
    {
        var coach = model.TeamCoach.MapToTeamCoach();
        var members = model.Members.Select(m => m.MapToTeamMember()).ToList();

        return new Team(model.Name, model.ContestCategoryId, coach, members);
    }

    public static TeamCoach MapToTeamCoach(this RegisterTeamModel.TeamCoachModel model)
    {
        return new(model.FirstName,
            model.LastName,
            model.PhoneNumber,
            model.IdentityNumber.ToUpper(),
            model.IdSerialNumber,
            model.Email,
            model.BirthDate,
            model.IdentityCardImage);
    }

    public static TeamMember MapToTeamMember(this RegisterTeamModel.TeamMemberModel model)
    {
        return new(model.FirstName,
            model.LastName,
            model.PhoneNumber,
            model.IdentityNumber.ToUpper(),
            model.IdSerialNumber,
            model.Instuition,
            model.BirthDate,
            model.IdentityCardImage);
    }
}
