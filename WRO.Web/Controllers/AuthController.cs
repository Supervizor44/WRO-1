using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using WRO.Web.Controllers.Extensions;
using WRO.Web.Data.Contexts;
using WRO.Web.Data.Entities.IdentityAggregate;
using WRO.Web.Data.Extensions;
using WRO.Web.Models;

namespace WRO.Web.Controllers;

public class AuthController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IStringLocalizer<Lang> _localizer;

    public AuthController(ApplicationDbContext context,
        SignInManager<AppUser> signInManager,
        IStringLocalizer<Lang> localizer)
    {
        _context = context;
        _signInManager = signInManager;
        _localizer = localizer;
    }

    public IActionResult Login(string? returnUrl)
    {
        if (User.Identity?.IsAuthenticated ?? false)
            return Redirect("/");

        TempData["ReturnUrl"] = returnUrl;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginModel loginModel)
    {
        if (!ModelState.IsValid)
            return View(loginModel);

        AppUser? user = await _context.Users.FindByEmailAsync(loginModel.Email);

        if (user is not null)
        {
            var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, loginModel.RememberMe, true);

            if (result.Succeeded)
                return LocalRedirect(TempData["ReturnUrl"]?.ToString() ?? "/");
        }
        TempData.AlertError(_localizer["error_login_failed"]);
        return View(loginModel);
    }

    public async Task<IActionResult> Logout()
    {
        if (User.Identity?.IsAuthenticated ?? false)
        {
            await _signInManager.SignOutAsync();
        }
        return Redirect("/");
    }
}
