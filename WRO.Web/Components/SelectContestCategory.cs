using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WRO.Web.Data.Contexts;

namespace WRO.Web.Components;

public class SelectContestCategory : ViewComponent
{
    private readonly ApplicationDbContext _context;

    public SelectContestCategory(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync(Guid selectedCategoryId, bool setQueryString = false)
    {
        ViewBag.SelectedCategoryId = selectedCategoryId;
        ViewBag.SetQueryString = setQueryString;
        var list = await _context.ContestCategories.OrderBy(x => x.Name).ToListAsync();
        return View(list);
    }
}
