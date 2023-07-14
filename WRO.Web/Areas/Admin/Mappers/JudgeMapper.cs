using System.Linq.Expressions;
using WRO.Web.Areas.Admin.Models.Judge;
using WRO.Web.Data.Entities.RegistrantAggregate;

namespace WRO.Web.Areas.Admin.Mappers;

public static class JudgeMapper
{
    public readonly static Expression<Func<Judge, ListJudgeModel>> ProjectToListModel =
        judge => new ListJudgeModel
        {
            Id = judge.Id,
            FullName = $"{judge.FirstName} {judge.LastName}",
            PhoneNumber = judge.PhoneNumber,
            Email = judge.Email,
            RegistrationDate = judge.Created
        };

    public readonly static Expression<Func<Judge, SingleJudgeModel>> ProjectToSingleModel =
        judge => new SingleJudgeModel
        {
            Id = judge.Id,
            FullName = $"{judge.FirstName} {judge.LastName}",
            PhoneNumber = judge.PhoneNumber,
            Email = judge.Email,
            IdentityNumber = judge.IdentityNumber,
            Profession = judge.Profession,
            WroExperince = judge.WroExperince,
            BankRekvizit = judge.BankRekvizit,
            StartupExperince = judge.StartupExperince,
            ContestCategoryName = judge.ContestCategory.Name,
            RegistrationDate = judge.Created,
            ImagePath = judge.IdentityCardImage.Path
        };
}
