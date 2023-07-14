using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WRO.Web.Areas.Admin.Models.ContactUs;
using WRO.Web.Data.Contexts;
using WRO.Web.Data.Entities;
using WRO.Web.Security.Attributes;
using WRO.Web.Security.Constants;
using WRO.Web.Areas.Admin.Mappers;
using WRO.Web.Controllers.Extensions;

namespace WRO.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AuthorizeRole(UserRole.Admin)]
    public class ContactUsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactUsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ContactUsModel? contactus = await _context.ContactUs
                .Select(ContactUsMapper.ProjectToModel)
                .FirstOrDefaultAsync();

            return View(contactus);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ContactUsModel model)
        {                     
           // if (!ModelState.IsValid)
            //    return View(model);

            ContactUs? contactUs = await _context.ContactUs.FirstOrDefaultAsync();

            if (contactUs == null)
            {
                _context.ContactUs.Add(contactUs = new());
            }

            model.MapToContactUs(contactUs);

            #region Example
            // UPDATE ContactUs SET PhoneNumber = @p0
            // contactus.PhoneNumber = model.PhoneNumber;

            // UPDATE ContactUs SET PhoneNumber = @p0, Email = @p1, Email2 = @p2
            // _context.Entry(contactus).State = EntityState.Modified; // <- bu bütün property-lərin update olmasına səbəb olur.
            // bu isə gərəksiz update-ə və performans itkisinə səbəb ola bilər.

            // _context.Update(contactus); // <- bu yuxarıdakı ilə eynidir. state-i modified edir.
            #endregion

            await _context.SaveChangesAsync();

            TempData.AlertSuccess("Uğurla yadda saxlanıldı");

            return RedirectToAction(nameof(Index));
        }
    }
}
