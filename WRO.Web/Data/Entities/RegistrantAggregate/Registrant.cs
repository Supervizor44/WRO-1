using WRO.Web.Data.Entities.ImageAggregate;

namespace WRO.Web.Data.Entities.RegistrantAggregate;

/// <summary>
/// WRO üçün qeydiyyatdan keçən istifadəçilərin base class-ı.
/// Bu class AppUser ilə səhv salınmamalıdı. AppUser üçün login imkanı 
/// olduğu halda bu class-dan törənmişlər sadəcə qeydiyyatdan keçmək istəyən 
/// istifadəçilərin məlumatlarını saxlayır
/// </summary>
public abstract class Registrant : Entity
{
    public Registrant() { }

    public Registrant(string firstName, string lastName, string phoneNumber, string identityNumber,string idSerialNumber, IdentityCardImage identityCardImage)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        IdentityNumber = identityNumber;
        IdSerialNumber = idSerialNumber;
        IdentityCardImage = identityCardImage;
    }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    /// <summary>
    /// Şəxsiyyət vəsiqəsinin 7 rəqəmli FİN kodu
    /// </summary>
    public string IdentityNumber { get; set; } = string.Empty;

    public string IdSerialNumber { get; set; } = string.Empty;

    public IdentityCardImage IdentityCardImage { get; set; } = null!;    

    
}
