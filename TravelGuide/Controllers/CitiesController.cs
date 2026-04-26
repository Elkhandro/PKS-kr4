using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelGuide.Data;

namespace TravelGuide.Controllers;

public class CitiesController : Controller
{
    private readonly AppDbContext _db;

    public CitiesController(AppDbContext db) => _db = db;

    // GET /Cities  — список городов с поиском
    public async Task<IActionResult> Index(string? search)
    {
        ViewBag.Search = search;
        var query = _db.Cities.Include(c => c.Attractions).AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
            query = query.Where(c => c.Name.ToLower().Contains(search.ToLower()));

        var cities = await query.OrderBy(c => c.Name).ToListAsync();
        return View(cities);
    }

    // GET /Cities/Details/5  — подробная информация о городе
    public async Task<IActionResult> Details(int id)
    {
        var city = await _db.Cities
            .Include(c => c.Attractions)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (city == null) return NotFound();
        return View(city);
    }
}
