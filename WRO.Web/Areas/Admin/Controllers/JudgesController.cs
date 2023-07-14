using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using WRO.Web.Areas.Admin.Mappers;
using WRO.Web.Areas.Admin.Models.Judge;
using WRO.Web.Data.Contexts;
using WRO.Web.Data.Entities.RegistrantAggregate;
using WRO.Web.Helpers;
using WRO.Web.Security.Attributes;
using WRO.Web.Security.Constants;

namespace WRO.Web.Areas.Admin.Controllers;

[Area("Admin")]
[AuthorizeRole(UserRole.Admin)]
public class JudgesController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IStringLocalizer<Lang> _localizer;

    public JudgesController(ApplicationDbContext context, IStringLocalizer<Lang> localizer)
    {
        _context = context;
        _localizer = localizer;
    }

    public async Task<IActionResult> Index(int? year)
    {
        #region example
        // Delegate - IEnumerable ilə işləyir, Method və ya lambda referansını daşıyır
        // Func<Judge, string> func = j => j.Email;

        // Expression, IQueryable ilə işləyir, Lambda məlumatını daşıyır, Method referansını daşıya bilmir
        // Expression<Func<Judge, string>> exp = j => j.Email;


        //_context.Judges.Select(j => new ListJudgeModel
        //{
        //    Id = j.Id,
        //    FullName = $"{j.FirstName} {j.LastName}",
        //    Email = j.Email,
        //    PhoneNumber = j.PhoneNumber
        //});
        #endregion

        IQueryable<ListJudgeModel> query = _context.Judges
            .Select(JudgeMapper.ProjectToListModel)
            .OrderByDescending(x => x.RegistrationDate);

        if (year is not null)
            query = query.Where(x => x.RegistrationDate.Year == year);

        return View(await query.ToListAsync());
    }

    public async Task<IActionResult> Details(Guid? id)
    {
        if (id is null)
            return NotFound();

        SingleJudgeModel? judge = await _context.Judges
            .Select(JudgeMapper.ProjectToSingleModel)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (judge is null)
            return NotFound();

        return View(judge);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id is null)
            return NotFound();

        Judge? judge = await _context.Judges.FindAsync(id);

        if (judge is null)
            return NotFound();

        _context.Judges.Remove(judge);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Excel(int? year)
    {
        IQueryable<SingleJudgeModel> query = _context.Judges.Select(JudgeMapper.ProjectToSingleModel);

        if (year is not null)
            query = query.Where(x => x.RegistrationDate.Year == year);

        return File(
            fileContents: ExcelHelper.SaveAsBytes(query, _localizer),
            contentType: ExcelHelper.ExcelMimeType,
            fileDownloadName: "judges.xlsx");
    }
}
