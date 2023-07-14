using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using WRO.Web.Data.Entities.IdentityAggregate;

namespace WRO.Web.Security.Factories;

/// <summary>Custom ClaimsPrincipalFactory</summary>
public class AppUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<AppUser>
{
    public AppUserClaimsPrincipalFactory(UserManager<AppUser> userManager, IOptions<IdentityOptions> optionsAccessor)
        : base(userManager, optionsAccessor)
    {
    }

    public override async Task<ClaimsPrincipal> CreateAsync(AppUser user)
    {
        ClaimsPrincipal principal = await base.CreateAsync(user);
        ClaimsIdentity identity = (principal.Identity as ClaimsIdentity)!;

        identity.AddClaim(new Claim(ClaimTypes.Role, user.Role.ToString()));

        return principal;
    }
}
