using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using WRO.Web.Controllers.Extensions;
using WRO.Web.Data.Contexts;
using WRO.Web.Data.Extensions;
using WRO.Web.Helpers;
using WRO.Web.Mappers;
using WRO.Web.Models.Register;
using WRO.Web.Data.Entities.ImageAggregate;
using WRO.Web.Data.Entities.RegistrantAggregate;
using System.ComponentModel.DataAnnotations;

namespace WRO.Web.Controllers;

public class RegisterController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IStringLocalizer<Lang> _localizer;
    private readonly FormFileHelper _formFileHelper;
    public RegisterController(ApplicationDbContext context, IStringLocalizer<Lang> localizer, FormFileHelper formFileHelper)
    {
        _context = context;
        _localizer = localizer;
        _formFileHelper = formFileHelper;
    }

    public IActionResult Judge()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Judge(RegisterJudgeModel model)
    {
        if (model.IdentityCardImageForm != null)
        {
            _formFileHelper.Upload(model.IdentityCardImageForm, "images\\identitycard\\judge", out string fileName, out string filePath);

            model.IdentityCardImage = new(fileName, filePath);
        }
        if (!ModelState.IsValid)
            return View(model);

        if (await _context.EmailExistsAtRegistrantsAsync(model.Email))
        {
            TempData.AlertError(_localizer["error_email_already_exists"]);
            return View(model);
        }

        if (await _context.IdentityNumberExistsAtRegistrantsAsync(model.IdentityNumber))
        {
            TempData.AlertError(_localizer["error_identity_number_already_exists"]);
            return View(model);
        }
        _context.Judges.Add(model.MapToJudge());
        await _context.SaveChangesAsync();

        TempData.AlertSuccess(_localizer["success_register_done"]);

        return Redirect("/");
    }

    public IActionResult Volunteer()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Volunteer(RegisterVolunteerModel model)
    {
        
        if (model.IdentityCardImageForm != null)
        {
            _formFileHelper.Upload(model.IdentityCardImageForm, "images\\identitycard\\volunteer", out string fileName, out string filePath);

            model.IdentityCardImage = new(fileName, filePath);
        }
        if (!ModelState.IsValid)
            return View(model);
        
        if (await _context.EmailExistsAtRegistrantsAsync(model.Email))
        {
            TempData.AlertError(_localizer["error_email_already_exists"]);
            return View(model);
        }

        if (await _context.IdentityNumberExistsAtRegistrantsAsync(model.IdentityNumber))
        {
            TempData.AlertError(_localizer["error_identity_number_already_exists"]);
            return View(model);
        }
        _context.Volunteers.Add(model.MapToVolunteer());
        await _context.SaveChangesAsync();

        TempData.AlertSuccess(_localizer["success_register_done"]);

        return Redirect("/");
    }

    public IActionResult Team(int memberCount)
    {
        int min = 2, max = 4; // minimum and maximum member counts
        ViewBag.MemberCount = min <= memberCount && memberCount <= max ? memberCount : min;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Team(RegisterTeamModel model)
    {
        var idnums = model.Members.Select(x => x.IdentityNumber).Append(model.TeamCoach.IdentityNumber);
        var set = new HashSet<string>(idnums);
        
        if (model.TeamCoach.IdentityCardImageForm != null)
        {
            _formFileHelper.Upload(model.TeamCoach.IdentityCardImageForm, "images\\identitycard\\teamcoach", out string fileName, out string filePath);

            model.TeamCoach.IdentityCardImage = new(fileName, filePath);
        }
        foreach (var member in model.Members)
        {
            if (member.IdentityCardImageForm != null)
            {
                _formFileHelper.Upload(member.IdentityCardImageForm, "images\\identitycard\\teammember", out string fileName, out string filePath);

                member.IdentityCardImage = new(fileName, filePath);
            }
        }
        if (set.Count != idnums.Count())
            ModelState.AddModelError("Members", _localizer["error_identity_number_duplicate"]);

        if (!ModelState.IsValid)
            return View(model);

        if (await _context.Teams.AnyAsync(x => x.Name == model.Name))
        {
            TempData.AlertError(_localizer["error_team_name_already_exists"]);
            return View(model);
        }

        if (await _context.EmailExistsAtRegistrantsAsync(model.TeamCoach.Email))
        {
            TempData.AlertError(_localizer["error_email_already_exists"]);
            return View(model);
        }

        if (await _context.IdentityNumberExistsAtRegistrantsAsync(model.TeamCoach.IdentityNumber))
        {
            TempData.AlertError(_localizer["error_identity_number_already_exists"]);
            return View(model);
        }

        foreach (var idnum in idnums)
            if (await _context.IdentityNumberExistsAtRegistrantsAsync(idnum))
            {
                TempData.AlertError(_localizer["error_identity_number_already_exists"]);
                return View(model);
            }

        _context.Teams.Add(model.MapToTeam());
        await _context.SaveChangesAsync();

        TempData.AlertSuccess(_localizer["success_register_done"]);

        return Redirect("/");
    }
}
