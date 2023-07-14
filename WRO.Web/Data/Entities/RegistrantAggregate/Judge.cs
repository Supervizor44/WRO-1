using System.ComponentModel.DataAnnotations.Schema;
using WRO.Web.Data.Entities.ImageAggregate;
namespace WRO.Web.Data.Entities.RegistrantAggregate;

public class Judge : Registrant, IAuditableEntity
{
    public Judge() { }

    public Judge(string firstName, string lastName, string phoneNumber, string identityNumber, string idSerialNumber, 
        string email, string profession, string bankRekvizit,
        string wroExperience, string startupExperience, Guid contestCategoryId, IdentityCardImage identityCardImage)
        : base(firstName, lastName, phoneNumber, identityNumber, idSerialNumber, identityCardImage)
    {
        Email = email;
        Profession = profession;
        BankRekvizit = bankRekvizit;
        WroExperince = wroExperience;
        StartupExperince = startupExperience;
        ContestCategoryId = contestCategoryId;
        IdentityCardImage = identityCardImage;
    }

    /// <summary>
    /// E-poçt ünvanı
    /// </summary>
    public string Email { get; set; } = string.Empty;
    /// <summary>
    /// Hakimin ixtisası
    /// </summary>
    public string Profession { get; set; } = string.Empty;
    /// <summary>
    /// Hakimin bank rekvizitləri. Bu pul köçürülməsi üçün nəzərdə tutulmuş bank hesab(lar)ıdır.
    /// </summary>
    public string BankRekvizit { get; set; } = string.Empty;
    /// <summary>
    /// Hakimin əvvəlki wro təcrübəsi. Yoxdursa, istifadəçi qeyd etməlidir.
    /// </summary>
    public string WroExperince { get; set; } = string.Empty;
    /// <summary>
    /// Hakimin startup(biznes) ilə bağlı təcrübəsi. Yoxdursa, qeyd etməlidir.
    /// </summary>
    public string StartupExperince { get; set; } = string.Empty;
    /// <summary>
    /// Hakimlik olunan kateqoriya. Kateqoriyalar databazada saxlanılır.
    /// </summary>
    public Guid ContestCategoryId { get; set; }
    public ContestCategory ContestCategory { get; set; } = null!;

    /// <summary>
    /// Registration date
    /// </summary>
    public DateTime Created { get; set; }

    [NotMapped]
    public DateTime? LastModified { get; set; }
}