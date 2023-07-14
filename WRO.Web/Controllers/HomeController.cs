using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace WRO.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    /// <summary>
    /// Bu method sistemin dilini dəyişmək üçün nəzərdə tutulub.
    /// </summary>
    /// <param name="culture">Dəyişilmək istənən dil. Bu dəyər kiçik fontda olur.</param>
    /// <param name="returnUrl">
    /// Sistem dilinin dəyişildiyi səhifədir. 
    /// Dil dəyişəndən sonra bu səhifəyə redirect olunur.</param>
    /// <returns></returns>
    public IActionResult SetLang(string culture, string? returnUrl)
    {
        Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1),
                IsEssential = true,  //critical settings to apply new culture
                Path = "/",
                HttpOnly = false,
            }
        );

        return LocalRedirect(returnUrl ?? "/");
    }
}
