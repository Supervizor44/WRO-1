using Microsoft.EntityFrameworkCore;
using WRO.Web.Data.Entities.IdentityAggregate;

namespace WRO.Web.Data.Extensions;

public static class AppUserExtensions
{
    public static Task<AppUser?> FindByEmailAsync(this IQueryable<AppUser> users, string email)
    {
        return users.FirstOrDefaultAsync(x => x.Email == email);
    }
}
