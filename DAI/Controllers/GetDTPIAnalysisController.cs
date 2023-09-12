using DAI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DAI.Controllers
{
    public class GetDTPIAnalysisController : Controller
    {
        private readonly DAIContext _context;
        public GetDTPIAnalysisController(DAIContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Index()
        {
            var query = @"SELECT * FROM GetDTPIAnalysis();";

            var clients = await _context.GetDTPIAnalysiss.FromSqlRaw(query).ToListAsync();

            return View(clients);
        }
    }
}
