using Microsoft.AspNetCore.Mvc;
using WRO.Web.Security.Attributes;
using WRO.Web.Security.Constants;

namespace WRO.Web.Areas.Admin.Controllers;

[Area("Admin")]
[AuthorizeRole(UserRole.Admin)]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
