using System.ComponentModel.DataAnnotations.Schema;

namespace WRO.Web.Data.Entities.RegistrantAggregate;

public class Team : Entity, IAuditableEntity
{
    public Team() { }

    public Team(string name, Guid contestCategoryId,
        TeamCoach teamCoach,
        ICollection<TeamMember> members)
    {
        Name = name;
        ContestCategoryId = contestCategoryId;
        TeamCoach = teamCoach;
        Members = members;
    }

    /// <summary>
    /// Komanda adı
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Komandanın yarışdığı kateqoriya
    /// </summary>
    public Guid ContestCategoryId { get; set; }
    public ContestCategory ContestCategory { get; set; } = null!;

    /// <summary>
    /// Təlimçi
    /// </summary>
    public Guid TeamCoachId { get; set; }
    public TeamCoach TeamCoach { get; set; } = null!;

    /// <summary>
    /// Komanda üzvləri/iştirakçılar
    /// </summary>
    public ICollection<TeamMember> Members { get; set; } = null!;

    /// <summary>
    /// Registiration date
    /// </summary>
    public DateTime Created { get; set; }

    [NotMapped]
    public DateTime? LastModified { get; set; }

    /// <summary>
    /// Komandanın qalib olub olmadığını bildirən sütun. 
    /// Komanda qeydiyyatdan keçən zaman bu dəyər false olur.
    /// Bu sütunun dəyərini ancaq admin təyin edə bilər.
    /// </summary>
    public bool IsWinner { get; set; } = false;
}
