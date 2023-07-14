using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WRO.Web.Models;

namespace WRO.Web.Controllers;

public class ErrorController : Controller
{
    [HttpGet("Error/{code}")]
    public IActionResult Error(int code)
    {
        if (code == 404)
            return View("NotFound");

        // see: cookie configuration at service registration
        else if (code == 403)
            return View("Forbidden");

        return Error();
    }

    [HttpGet("Error")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
