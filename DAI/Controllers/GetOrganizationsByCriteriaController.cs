using DAI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DAI.Controllers
{
    public class GetOrganizationsByCriteriaController : Controller
    {
        private readonly DAIContext _context;
        public GetOrganizationsByCriteriaController(DAIContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Index(string series = "ЕЕ456789")
        {
            var parameters = new[]
            {
                new SqlParameter("@Series", series)
            };

            var query = @"EXEC GetOrganizationsByCriteria @Series;";

            var clients = await _context.GetOrganizationsByCriterias.FromSqlRaw(query, parameters).ToListAsync();

            return View(clients);
        }
    }
}
