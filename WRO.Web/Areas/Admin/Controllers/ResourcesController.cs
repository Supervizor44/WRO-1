using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System.Collections;
using System.Globalization;
using System.Resources;
using WRO.Web.Controllers.Extensions;
using WRO.Web.Helpers;
using WRO.Web.Localizer;
using WRO.Web.Security.Attributes;
using WRO.Web.Security.Constants;

namespace WRO.Web.Areas.Admin.Controllers;

[Area("Admin")]
[AuthorizeRole(UserRole.Admin)]
public class ResourcesController : Controller
{
    private readonly IOptions<RequestLocalizationOptions> _localizationOptions;
    private readonly IStringLocalizer<Lang> _localizer;
    private readonly IStringLocalizerFactory _localizerFactory;

    public ResourcesController(IOptions<RequestLocalizationOptions> localizationOptions, 
        IStringLocalizer<Lang> localizer, IStringLocalizerFactory localizerFactory)
    {

        _localizationOptions = localizationOptions;
        _localizer = localizer;
        _localizerFactory = localizerFactory;
    }
    
    public IActionResult Index()
    {
        IDictionary<string, Dictionary<string, string>> data = JsonHelper.LoadCollection<string>("cultures", "Resources")
            .ToDictionary(c => c, c => _localizerFactory.Create(nameof(Lang), c).GetAllStrings().ToDictionary(x => x.Name, x => x.Value));

        return View(data);
    }

    public IActionResult Edit(string culture, string key)
    {
        string value = _localizerFactory.Create(nameof(Lang), culture)[key];
        return View((culture, key, value));
    }

    [HttpPost]
    public IActionResult Edit(string culture, string key, string value)
    {
        string name = $"{nameof(Lang)}.{culture}", dir = "Resources";

        var pairs = JsonHelper.Load<Dictionary<string, string>>(name, dir)!;
        pairs[key] = value;
        JsonHelper.Save(pairs, name, dir);

        // remove from cache
        (_localizerFactory as JsonStringLocalizerFactory)!.Remove(name);

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Create()
    {
        ViewBag.DefaultResource = _localizerFactory.Create(nameof(Lang), "az").GetAllStrings().ToDictionary(x => x.Name, x => x.Value);
        return View();
    }

    [HttpPost]
    public IActionResult Create(string culture, IDictionary<string, string> pairs)
    {
        pairs.Remove("culture");
        pairs.Remove("__RequestVerificationToken");

        var cultures = JsonHelper.LoadCollection<string>("cultures", "Resources");

        if (cultures.Contains(culture))
        {
            TempData.AlertError("This culture already exists");
            ViewBag.DefaultResource = _localizerFactory.Create(nameof(Lang), "az").GetAllStrings().ToDictionary(x => x.Name, x => x.Value);
            return View(pairs);
        }

        JsonHelper.Save(pairs, $"{nameof(Lang)}.{culture}", "Resources");
        JsonHelper.Save(cultures = cultures.Append(culture), "cultures", "Resources");

        _localizationOptions.Value.AddSupportedCultures(cultures.ToArray());
        _localizationOptions.Value.AddSupportedUICultures(cultures.ToArray());

        TempData.AlertSuccess("Culture created succesfully");
        return RedirectToAction(nameof(Index));
    }
}
