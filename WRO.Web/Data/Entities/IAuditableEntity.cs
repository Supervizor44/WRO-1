namespace WRO.Web.Data.Entities;

public interface IAuditableEntity
{
    public DateTime Created { get; set; }
    public DateTime? LastModified { get; set; }
}
