using WRO.Web.Security.Constants;

namespace WRO.Web.Data.Entities.IdentityAggregate;

public class Admin : AppUser
{
    public Admin() { }

    public Admin(string email, string password) : base(email, password, UserRole.Admin)
    { }
}
