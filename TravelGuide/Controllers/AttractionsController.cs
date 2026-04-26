using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelGuide.Data;

namespace TravelGuide.Controllers;

public class AttractionsController : Controller
{
    private readonly AppDbContext _db;

    public AttractionsController(AppDbContext db) => _db = db;

    // GET /Attractions/Details/5  — подробная информация о достопримечательности
    public async Task<IActionResult> Details(int id)
    {
        var attraction = await _db.Attractions
            .Include(a => a.City)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (attraction == null) return NotFound();
        return View(attraction);
    }
}
