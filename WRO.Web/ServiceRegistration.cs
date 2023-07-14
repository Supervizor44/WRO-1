using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System.Globalization;
using WRO.Web.Data.Contexts;
using WRO.Web.Data.Entities.IdentityAggregate;
using WRO.Web.Helpers;
using WRO.Web.Localizer;
using WRO.Web.Security.Factories;

namespace WRO.Web;

public static class ServiceRegistration
{
    public static IMvcBuilder AddMvcServices(this IServiceCollection services)
    {
        return services.AddControllersWithViews()
            .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
            .AddDataAnnotationsLocalization(options =>
            {
                options.DataAnnotationLocalizerProvider = (type, factory) => factory.Create(typeof(Lang));
            });
    }

    public static IServiceCollection AddLocalizationServices(this IServiceCollection services)
    {
        services.AddSingleton<IStringLocalizerFactory>(provider =>
        {
            return new JsonStringLocalizerFactory(resourcePath: "Resources");
        });

        services.AddTransient(provider =>
        {
            var factory = provider.GetRequiredService<IStringLocalizerFactory>();
            return factory.Create(typeof(Lang));
        });

        services.Configure<RequestLocalizationOptions>(options =>
        {
            var cultures = JsonHelper.LoadCollection<string>("cultures", "Resources").Select(c => new CultureInfo(c)).ToList();

            options.DefaultRequestCulture = new RequestCulture("az");
            options.SupportedCultures = cultures;
            options.SupportedUICultures = cultures;

            var provider = options.RequestCultureProviders.OfType<AcceptLanguageHeaderRequestCultureProvider>().First();
            options.RequestCultureProviders.Remove(provider);
        });

        return services;
    }

    public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            if (configuration.GetValue<bool>("UseInMemoryDb"))
            {
                options.UseInMemoryDatabase("WRO_DB");
            }
            else
            {
                string connStr = configuration.GetConnectionString("WRO_DB");
                options.UseNpgsql(connStr);
            }
        });

        return services;
    }

    public static IServiceCollection AddSecurityServices(this IServiceCollection services)
    {
        services.AddIdentity<AppUser, IdentityRole<Guid>>(_ =>
        {
            _.Password.RequireNonAlphanumeric = false;
        })
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.ConfigureApplicationCookie(config =>
        {
            config.LoginPath = "/Auth/Login";
            config.AccessDeniedPath = "/Error/403";
            config.Cookie = new CookieBuilder
            {
                Name = "AspNetCoreIdentity",
                HttpOnly = false,
                SameSite = SameSiteMode.Lax,
                SecurePolicy = CookieSecurePolicy.Always
            };
            config.ExpireTimeSpan = TimeSpan.FromDays(1);
            config.SlidingExpiration = true;
        });

        services.AddScoped<IUserClaimsPrincipalFactory<AppUser>, AppUserClaimsPrincipalFactory>();

        return services;
    }

    public static IServiceCollection AddHelperServices(this IServiceCollection services)
    {
        services.AddSingleton<FormFileHelper>();
        return services;
    }
}