using DAI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DAI.Controllers
{
    public class WantedCarController : Controller
    {
        private readonly DAIContext _context;
        public WantedCarController(DAIContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Index()
        {
            var query = @"SELECT * FROM GetWantedCarsList();";

            var clients = await _context.WantedCars.FromSqlRaw(query).ToListAsync();

            return View(clients);
        }
    }
}
