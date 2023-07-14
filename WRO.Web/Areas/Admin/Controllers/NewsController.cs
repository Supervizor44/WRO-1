using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using WRO.Web.Areas.Admin.Models.News;
using WRO.Web.Data.Contexts;
using WRO.Web.Data.Entities.ImageAggregate;
using WRO.Web.Data.Entities.NewsAggregate;
using WRO.Web.Helpers;
using WRO.Web.Mappers;
using WRO.Web.Models.News;
using WRO.Web.Security.Attributes;
using WRO.Web.Security.Constants;
using AdminMappers = WRO.Web.Areas.Admin.Mappers;

namespace WRO.Web.Areas.Admin.Controllers;

[Area("Admin")]
[AuthorizeRole(UserRole.Admin)]
public class NewsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly FormFileHelper _formFileHelper;
    private const string _newsImageDirectory = "images\\news";

    public NewsController(ApplicationDbContext context, FormFileHelper formFileHelper)
    {
        _context = context;
        _formFileHelper = formFileHelper;
    }

    public CultureInfo CurrentCulture => HttpContext.Features.Get<IRequestCultureFeature>()!.RequestCulture.Culture;

    public async Task<IActionResult> Index()
    {
        List<ListNewsModel> list = await _context.News
            .Select(NewsMapper.ProjectToListModel(CurrentCulture.Name))
            .OrderByDescending(x => x.LastModified)
            .ToListAsync();

        return View(list);
    }

    public async Task<IActionResult> Details(Guid? id)
    {
        if (id is null)
            return NotFound();

        SingleNewsModel? news = await _context.News
            .Select(NewsMapper.ProjectToSingleModel(CurrentCulture.Name))
            .FirstOrDefaultAsync(x => x.Id == id);

        if (news is null)
            return NotFound();

        return View(news);
    }

    public IActionResult Create()
    {
        ViewBag.Language = CurrentCulture.Name;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(UpsertNewsModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        _formFileHelper.Upload(model.Image, _newsImageDirectory, out string fileName, out string filePath);

        Image image = new(fileName, filePath);

        NewsContext context = new(model.Title, model.Body, CurrentCulture.Name);

        News news = new(image, new[] { context });

        _context.News.Add(news);

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id is null)
            return NotFound();

        UpsertNewsModel? news = await _context.News
            .Where(x => x.Id == id)
            .Select(AdminMappers.NewsMapper.ProjectToUpsertModel(CurrentCulture.Name))
            .FirstOrDefaultAsync();

        if (news is null)
            return NotFound();

        return View(news);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid? id, UpsertNewsModel model)
    {
        // If no image uploaded by user then don't validate image
        if (model.Image is null)
            ModelState[nameof(model.Image)]!.ValidationState = Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Skipped;

        if (!ModelState.IsValid)
            return View(model);

        if (id is null)
            return NotFound();

        // Find news by id if exists
        News? news = await _context.News
            .Include(x => x.Image)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (news is null)
            return NotFound();

        // If image uploaded by user then overwrite the current image in folder
        if (model.Image != null)
        {
            _formFileHelper.Overwrite(model.Image, news.Image.Path);
        }

        // Find the context of the news according to current culture
        var newsContext = await _context.NewsContexts
            .FirstOrDefaultAsync(x => x.NewsId == news.Id && x.Culture == CurrentCulture.Name);

        // If there is no context for current culture then create new one before modifying
        if (newsContext is null)
        {
            newsContext = new() { NewsId = id.Value, Culture = CurrentCulture.Name };
            _context.NewsContexts.Add(newsContext);
        }
        newsContext.Title = model.Title;
        newsContext.Body = model.Body;

        // We must set news' state manually
        _context.Entry(news).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Details), new { id });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id is null)
            return NotFound();

        News? news = await _context.News
            .Include(x => x.Image)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (news is null)
            return NotFound();

        _formFileHelper.Delete(news.Image.Path);

        _context.News.Remove(news);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
