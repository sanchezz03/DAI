using DAI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DAI.Controllers
{
    public class GetPopularTheftMethodsController : Controller
    {
        private readonly DAIContext _context;
        public GetPopularTheftMethodsController(DAIContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Index()
        {
            var query = @"SELECT * FROM GetPopularTheftMethods();";

            var clients = await _context.GetPopularTheftMethods.FromSqlRaw(query).ToListAsync();

            return View(clients);
        }
    }
}
