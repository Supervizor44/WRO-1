using Microsoft.AspNetCore.Identity;
using WRO.Web.Security.Constants;

namespace WRO.Web.Data.Entities.IdentityAggregate;

public abstract class AppUser : IdentityUser<Guid>
{
    private readonly PasswordHasher<AppUser> _hasher = new();

    public AppUser() { }

    public AppUser(string email, string password, UserRole role)
    {
        Id = Guid.NewGuid();
        Email = email;
        NormalizedEmail = email.ToUpperInvariant();
        UserName = email;
        NormalizedUserName = email.ToUpperInvariant();
        PasswordHash = _hasher.HashPassword(null!, password);
        SecurityStamp = Guid.NewGuid().ToString();
        Role = role;
    }

    public UserRole Role { get; set; }
}
