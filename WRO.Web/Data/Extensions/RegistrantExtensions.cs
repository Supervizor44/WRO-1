using Microsoft.EntityFrameworkCore;
using WRO.Web.Data.Contexts;
using WRO.Web.Data.Entities.RegistrantAggregate;

namespace WRO.Web.Data.Extensions;

public static class RegistrantExtensions
{
    public static async Task<bool> EmailExistsAtRegistrantsAsync(this ApplicationDbContext context, string email)
    {
        return await context.Judges.AnyAsync(x => x.Email == email)
            || await context.Volunteers.AnyAsync(x => x.Email == email)
            || await context.TeamCoaches.AnyAsync(x => x.Email == email);
    }

    public static async Task<bool> IdentityNumberExistsAtRegistrantsAsync(this ApplicationDbContext context, string identityNumber)
    {
        return await context.Judges.AnyAsync(x => x.IdentityNumber == identityNumber)
            || await context.Volunteers.AnyAsync(x => x.IdentityNumber == identityNumber)
            || await context.TeamCoaches.AnyAsync(x => x.IdentityNumber == identityNumber)
            || await context.TeamMembers.AnyAsync(x => x.IdentityNumber == identityNumber);
    }
}
