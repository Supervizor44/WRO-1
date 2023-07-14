using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using WRO.Web.Areas.Admin.Models.Image;
using WRO.Web.Controllers.Attributes;
using WRO.Web.Data.Contexts;
using WRO.Web.Data.Entities.ImageAggregate;
using WRO.Web.Helpers;
using WRO.Web.Mappers;
using WRO.Web.Models.Image;
using WRO.Web.Security.Attributes;
using WRO.Web.Security.Constants;

namespace WRO.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AuthorizeRole(UserRole.Admin)]
    public class GalleryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly FormFileHelper _formFileHelper;
        private const string _galleryImageDirectory = "images\\gallery";

        public GalleryController(ApplicationDbContext context, FormFileHelper formFileHelper)
        {
            _context = context;
            _formFileHelper = formFileHelper;
        }

        public async Task<IActionResult> Index()
        {
            List<GalleryImageModel> list = await _context.GalleryImages
                .Select(GalleryImageMapper.ProjectToGalleryImageModel)
                .ToListAsync();

            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UpsertGalleryImageModel model)
        {
            if (!ModelState.IsValid)
                return View();

            foreach (var img in model.Images)
            {
                _formFileHelper.Upload(img, _galleryImageDirectory, out string fileName, out string filePath);

                GalleryImage image = new(fileName, filePath, model.Season);

                _context.GalleryImages.Add(image);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id is null)
                return NotFound();

            Image? image = await _context.Images.FindAsync(id);

            if (image is null)
                return NotFound();

            _formFileHelper.Delete(image.Path);

            _context.Images.Remove(image);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}

