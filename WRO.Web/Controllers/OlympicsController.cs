using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WRO.Web.Areas.Admin.Models.Team;
using WRO.Web.Data.Contexts;
using WRO.Web.Data.Entities.RegistrantAggregate;
using WRO.Web.Mappers;

namespace WRO.Web.Controllers;

public class OlympicsController : Controller
{
    private readonly ApplicationDbContext _context;

    public OlympicsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(int? year, Guid? category)
    {
        IQueryable<Team> query = _context.Teams
            .Where(x => x.IsWinner)
            .OrderByDescending(x => x.Created.Year)
            .ThenBy(x => x.Name);

        //List<string> orders = new() { "-created.year", "name" };
        //Order<Team> order = Order<Team>.Desc(x => x.Created.Year);
        //List<Order<Team>> orders = Order<Team>.Desc(x => x.Created.Year).Asc(x => x.Name);

        if (year is not null)
            query = query.Where(x => x.Created.Year == year);

        if (category is not null)
            query = query.Where(x => x.ContestCategoryId == category);

        var result = await query.Select(TeamMapper.ProjectToWinnerModel).ToListAsync();

        return View(result);
    }
    public async Task<IActionResult> Members(string? name)
    {
        if (name is null)
            return NotFound();

        SingleTeamModel? team = await _context.Teams
            .Select(TeamMapper.ProjectToSingleModel)
            .FirstOrDefaultAsync(x => x.Name == name);

        if (team is null)
            return NotFound();

        return View(team);
    }
}

public class TeamFilter
{
    public string? Name { get; set; }
    public Guid? ContestCategoryId { get; set; }
    public bool? IsWinner { get; set; }
}

public enum OrderState : sbyte
{
    Asc = 1, Desc = -1
}

public class Order<T>
{
    protected Order(Expression<Func<T, object>> by, OrderState state)
    {
        By = by;
        State = state;
    }

    public Expression<Func<T, object>> By { get; }
    public OrderState State { get; }

    public static Order<T> Asc(Expression<Func<T, object>> by) => new(by, OrderState.Asc);
    public static Order<T> Desc(Expression<Func<T, object>> by) => new(by, OrderState.Desc);
}

public static class OrderExtensions
{
    public static List<Order<T>> Asc<T>(this Order<T> order, Expression<Func<T, object>> by)
    {
        return new() { order, Order<T>.Asc(by) };
    }

    public static List<Order<T>> Asc<T>(this List<Order<T>> order, Expression<Func<T, object>> by)
    {
        order.Add(Order<T>.Asc(by));
        return order;
    }

    public static List<Order<T>> Desc<T>(this Order<T> order, Expression<Func<T, object>> by)
    {
        return new() { order, Order<T>.Desc(by) };
    }

    public static List<Order<T>> Desc<T>(this List<Order<T>> order, Expression<Func<T, object>> by)
    {
        order.Add(Order<T>.Desc(by));
        return order;
    }
}