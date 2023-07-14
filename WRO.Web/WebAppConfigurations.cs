using Microsoft.EntityFrameworkCore;
using WRO.Web.Data.Contexts;

namespace WRO.Web;

public static class WebAppConfigurations
{
    /// <summary>
    /// If UseInMemoryDb is true then will call the EnsureCreated method of DbContext,
    /// else will call the Migrate method of DbContext.
    /// For more information check the method inside.
    /// </summary>
    public static void ConfigureDatabase(this WebApplication app, IConfiguration configuration)
    {
        using var scope = app.Services.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        /*
         * The EnsureCreated method is for test purposes because it will only create the database if it doesn't exist.
         * No update will happen to the database when we change the DbContext.
         * For creating and also updating the database we use Migrate method.
         * This method equivalent to the update-database command of EF Core
         */

        if (configuration.GetValue<bool>("UseInMemoryDb"))
        {
            context.Database.EnsureCreated();
        }
        else context.Database.Migrate();
    }
}
