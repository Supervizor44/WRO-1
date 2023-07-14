using WRO.Web.Data.Entities.ImageAggregate;
namespace WRO.Web.Data.Entities.RegistrantAggregate;

/// <summary>
/// Komand üzvü (iştirakçı)
/// </summary>
public class TeamMember : Registrant
{
    public TeamMember() { }

    public TeamMember(string firstName, string lastName, string phoneNumber, string identityNumber,string idSerialNumber,
        string instuition, DateTime birthDate,IdentityCardImage identityCardImage)
        : base(firstName, lastName, phoneNumber, identityNumber,idSerialNumber,identityCardImage)
    {
        Instuition = instuition;
        BirthDate = birthDate;
    }

    /// <summary>
    /// Komanda üzvünün oxuduğu təhsil müəssisəsi
    /// </summary>
    public string Instuition { get; set; } = string.Empty;
    /// <summary>
    /// Doğum tarixi
    /// </summary>
    public DateTime BirthDate { get; set; }

    public Guid TeamId { get; set; }
    public Team Team { get; set; } = null!;
}
