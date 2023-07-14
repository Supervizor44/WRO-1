using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using WRO.Web.Areas.Admin.Mappers;
using WRO.Web.Areas.Admin.Models.Volunteer;
using WRO.Web.Data.Contexts;
using WRO.Web.Data.Entities.RegistrantAggregate;
using WRO.Web.Helpers;
using WRO.Web.Security.Attributes;
using WRO.Web.Security.Constants;

namespace WRO.Web.Areas.Admin.Controllers;

[Area("Admin")]
[AuthorizeRole(UserRole.Admin)]
public class VolunteersController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IStringLocalizer<Lang> _localizer;

    public VolunteersController(ApplicationDbContext context, IStringLocalizer<Lang> localizer)
    {
        _context = context;
        _localizer = localizer;
    }

    public async Task<IActionResult> Index(int? year)
    {
        IQueryable<ListVolunteerModel> query = _context.Volunteers
            .Select(VolunteerMapper.ProjectToListModel)
            .OrderByDescending(x => x.RegistrationDate);

        if (year is not null)
            query = query.Where(x => x.RegistrationDate.Year == year);

        return View(await query.ToListAsync());
    }

    public async Task<IActionResult> Details(Guid? id)
    {
        if (id is null)
            return NotFound();

        SingleVolunteerModel? volunteer = await _context.Volunteers
            .Select(VolunteerMapper.ProjectToSingleModel)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (volunteer is null)
            return NotFound();

        return View(volunteer);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id is null)
            return NotFound();

        Volunteer? volunteer = await _context.Volunteers.FindAsync(id);

        if (volunteer is null)
            return NotFound();

        _context.Volunteers.Remove(volunteer);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Excel(int? year)
    {
        IQueryable<SingleVolunteerModel> query = _context.Volunteers.Select(VolunteerMapper.ProjectToSingleModel);

        if (year is not null)
            query = query.Where(x => x.RegistrationDate.Year == year);

        return File(
            fileContents: ExcelHelper.SaveAsBytes(query, _localizer),
            contentType: ExcelHelper.ExcelMimeType,
            fileDownloadName: "volunteers.xlsx");
    }
}