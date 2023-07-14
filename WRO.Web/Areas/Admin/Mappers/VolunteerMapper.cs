using System.Linq.Expressions;
using WRO.Web.Areas.Admin.Models.Volunteer;
using WRO.Web.Data.Entities.RegistrantAggregate;
namespace WRO.Web.Areas.Admin.Mappers;

public class VolunteerMapper
{
    public readonly static Expression<Func<Volunteer, ListVolunteerModel>> ProjectToListModel =
        volunteer => new ListVolunteerModel
        {
            Id = volunteer.Id,
            FullName = $"{volunteer.FirstName} {volunteer.LastName}",
            PhoneNumber = volunteer.PhoneNumber,
            Email = volunteer.Email,
            RegistrationDate = volunteer.Created
        };

    public readonly static Expression<Func<Volunteer, SingleVolunteerModel>> ProjectToSingleModel =
        volunteer => new SingleVolunteerModel
        {
            Id = volunteer.Id,
            FullName = $"{volunteer.FirstName} {volunteer.LastName}",
            PhoneNumber = volunteer.PhoneNumber,
            Email = volunteer.Email,
            IdentityNumber = volunteer.IdentityNumber,
            IdSerialNumber = volunteer.IdSerialNumber,
            VolunteerExperince = volunteer.VolunteerExperience,
            ProfessionAtUniversity = volunteer.ProfessionAtUniversity,
            KnownForeignLanguages = volunteer.KnownForeignLanguages,
            RegistrationDate = volunteer.Created,
            ImagePath = volunteer.IdentityCardImage.Path
        };
}
