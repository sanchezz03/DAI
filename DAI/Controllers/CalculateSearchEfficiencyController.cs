using DAI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DAI.Controllers
{
    public class CalculateSearchEfficiencyController : Controller
    {
        private readonly DAIContext _context;
        public CalculateSearchEfficiencyController(DAIContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Index()
        {
            var query = @"SELECT dbo.CalculateSearchEfficiency() AS SearchEfficiency;";

            var clients = await _context.CalculateSearchEfficiencies.FromSqlRaw(query).ToListAsync();

            return View(clients);
        }
    }
}
