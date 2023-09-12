using DAI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DAI.Controllers
{
    public class GetOwnerInfoByLicensePlateController : Controller
    {
        private readonly DAIContext _context;
        public GetOwnerInfoByLicensePlateController(DAIContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Index(string LicensePlate = "IJ2345IJ")
        {
            var parameters = new[]
            {
                new SqlParameter("@LicensePlate", LicensePlate)
            };

            var query = @"EXEC GetOwnerInfoByLicensePlate @LicensePlate;";

            var clients = await _context.GetOwnerInfoByLicensePlates.FromSqlRaw(query, parameters).ToListAsync();

            return View(clients);
        }
    }
}
