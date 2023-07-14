using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using WRO.Web.Data.Contexts;
using WRO.Web.Mappers;

namespace WRO.Web.Controllers;

public class NewsController : Controller
{
    private readonly ApplicationDbContext _context;

    public NewsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public CultureInfo CurrentCulture => HttpContext.Features.Get<IRequestCultureFeature>()!.RequestCulture.Culture;

    public async Task<IActionResult> Index()
    {
        var list = await _context.News
            .Select(NewsMapper.ProjectToListModel(CurrentCulture.Name))
            .OrderByDescending(x => x.LastModified)
            .ToListAsync();

        return View(list);
    }
}
