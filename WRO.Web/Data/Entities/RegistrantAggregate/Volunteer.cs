using System.ComponentModel.DataAnnotations.Schema;
using WRO.Web.Data.Entities.ImageAggregate;
namespace WRO.Web.Data.Entities.RegistrantAggregate;

public class Volunteer : Registrant, IAuditableEntity
{
    public Volunteer() { }

    public Volunteer(string firstName, string lastName, string phoneNumber, string identityNumber, string idSerialNumber,
        string email, string professionAtUniversity, string volunteerExperience, string knownForeignLanguages, IdentityCardImage identityCardImage)
        : base(firstName, lastName, phoneNumber, identityNumber,idSerialNumber, identityCardImage)
    {
        IdentityNumber = identityNumber;
        IdSerialNumber = idSerialNumber;
        Email = email;
        ProfessionAtUniversity = professionAtUniversity;
        VolunteerExperience = volunteerExperience;
        KnownForeignLanguages = knownForeignLanguages;
        IdentityCardImage = identityCardImage;
    }


    /// <summary>
    /// E-poçt ünvanı
    /// </summary>
    public string Email { get; set; } = string.Empty;
    /// <summary>
    /// Oxunulan universitet və ixtisas. (Məs: İqtisad Universiteti, Marketinq)
    /// </summary>
    public string ProfessionAtUniversity { get; set; } = string.Empty;
    /// <summary>
    /// Könüllük üzrə təcrübəsi. Yoxdursa, qeyd olunmalıdır
    /// </summary>
    public string VolunteerExperience { get; set; } = string.Empty;
    /// <summary>
    /// Bilinən xarici dillər. (Məs: İngilis dili, Rus dili, Türk dili)
    /// Bu məlumat istənilən şəkildə yazıla bilər. Bunun üçün listə ehtiyac yoxdur.
    /// </summary>
    public string KnownForeignLanguages { get; set; } = string.Empty;

    /// <summary>
    /// Registration date
    /// </summary>
    public DateTime Created { get; set; }

    [NotMapped]
    public DateTime? LastModified { get; set; }
}
