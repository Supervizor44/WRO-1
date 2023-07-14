using WRO.Web.Data.Entities.ImageAggregate;

namespace WRO.Web.Data.Entities.RegistrantAggregate;

/// <summary>
/// Komanda koçu (təlimçi)
/// </summary>
public class TeamCoach : Registrant
{
    public TeamCoach() { }

    public TeamCoach(string firstName, string lastName, string phoneNumber, string identityNumber,string idSerialNumber,
        string email, DateTime birthDate, IdentityCardImage identityCardImage)
        : base(firstName, lastName, phoneNumber, identityNumber,idSerialNumber,identityCardImage)
    {
        Email = email;
        BirthDate = birthDate;
    }

    /// <summary>
    /// Təlimçinin e-poçtu
    /// </summary>
    public string Email { get; set; } = string.Empty;
    /// <summary>
    /// Təlimçinin doğum tarixi
    /// </summary>
    public DateTime BirthDate { get; set; }
}
