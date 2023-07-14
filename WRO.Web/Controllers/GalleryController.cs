using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WRO.Web.Data.Contexts;
using WRO.Web.Mappers;
using WRO.Web.Models.Image;

namespace WRO.Web.Controllers;

public class GalleryController : Controller
{
    private readonly ApplicationDbContext _context;

    public GalleryController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(int? year)
    {
        List<ImageModel> list = await _context.GalleryImages
            .Where(x => x.Season == (year ?? DateTime.Now.Year))
            .Select(GalleryImageMapper.ProjectToImageModel)
            .ToListAsync();

        return View(list);
    }
}
