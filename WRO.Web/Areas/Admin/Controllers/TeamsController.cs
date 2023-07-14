using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using WRO.Web.Areas.Admin.Mappers;
using WRO.Web.Areas.Admin.Models.Team;
using WRO.Web.Controllers.Extensions;
using WRO.Web.Data.Contexts;
using WRO.Web.Data.Entities.RegistrantAggregate;
using WRO.Web.Helpers;
using WRO.Web.Security.Attributes;
using WRO.Web.Security.Constants;

namespace WRO.Web.Areas.Admin.Controllers;

[Area("Admin")]
[AuthorizeRole(UserRole.Admin)]
public class TeamsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IStringLocalizer<Lang> _localizer;

    public TeamsController(ApplicationDbContext context, IStringLocalizer<Lang> localizer)
    {
        _context = context;
        _localizer = localizer;
    }

    public async Task<IActionResult> Index(int? year, Guid? category, bool? winners)
    {
        IQueryable<Team> query = _context.Teams.OrderByDescending(x => x.Created);

        if (year is not null)
            query = query.Where(x => x.Created.Year == year);

        if (category is not null)
            query = query.Where(x => x.ContestCategoryId == category);

        if (winners.GetValueOrDefault(false))
            query = query.Where(x => x.IsWinner);

        var result = await query.Select(TeamMapper.ProjectToListModel).ToListAsync();

        return View(result);
    }

    public async Task<IActionResult> Details(Guid? id)
    {
        if (id is null)
            return NotFound();

        SingleTeamModel? team = await _context.Teams
            .Select(TeamMapper.ProjectToSingleModel)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (team is null)
            return NotFound();

        return View(team);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id is null)
            return NotFound();

        Team? team = await _context.Teams.FindAsync(id);

        if (team is null)
            return NotFound();

        _context.Teams.Remove(team);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Excel(int? year)
    {
        IQueryable<SingleTeamModel> query = _context.Teams.Select(TeamMapper.ProjectToSingleModel);

        if (year is not null)
            query = query.Where(x => x.RegistrationDate.Year == year);

        IEnumerable<SingleTeamExcelModel> excelList = query.Select(TeamMapper.MapToExcelModel);

        return File(
            fileContents: ExcelHelper.SaveAsBytes(excelList, _localizer),
            contentType: ExcelHelper.ExcelMimeType,
            fileDownloadName: "teams.xlsx");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ToggleWinState(Guid? id)
    {
        if (id is null)
            return NotFound();

        Team? team = await _context.Teams.FindAsync(id);

        if (team is null)
            return NotFound();

        bool isAlreadyAnotherWinner = await _context.Teams
            .AnyAsync(x => x.Id != team.Id && x.ContestCategoryId == team.ContestCategoryId && x.Created.Year == team.Created.Year && x.IsWinner);

        if (isAlreadyAnotherWinner)
        {
            TempData.AlertError("Bu kateqoria və sezon üzrə qalib artıq mövcuddur.");
        }
        else
        {
            team.IsWinner = !team.IsWinner;
            await _context.SaveChangesAsync();
            TempData.AlertSuccess(team.IsWinner ? "Komanda qalib kimi təyin edildi" : "Komanda qaliblikdən çıxarıldı");
        }
        return RedirectToAction(nameof(Details), new { id });
    }
}
