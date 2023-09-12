using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAI.Models;

namespace DAI.Controllers
{
    public class VehicleInspectionsController : Controller
    {
        private readonly DAIContext _context;

        public VehicleInspectionsController(DAIContext context)
        {
            _context = context;
        }

        // GET: VehicleInspections
        public async Task<IActionResult> Index()
        {
            var dAIContext = _context.VehicleInspections.Include(v => v.АвтоНаОглядNavigation);
            return View(await dAIContext.ToListAsync());
        }

        // GET: VehicleInspections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VehicleInspections == null)
            {
                return NotFound();
            }

            var vehicleInspection = await _context.VehicleInspections
                .Include(v => v.АвтоНаОглядNavigation)
                .FirstOrDefaultAsync(m => m.НомерОгляду == id);
            if (vehicleInspection == null)
            {
                return NotFound();
            }

            return View(vehicleInspection);
        }

        // GET: VehicleInspections/Create
        public IActionResult Create()
        {
            ViewData["АвтоНаОгляд"] = new SelectList(_context.Cars, "КодАвто", "КодАвто");
            return View();
        }

        // POST: VehicleInspections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("НомерОгляду,АвтоНаОгляд,НомерКвитанціїСплатиПодатку,СумаПлатежуЗаОгляд,ПеревіреноТехнічніХарактеристики,ДатаОгляду")] VehicleInspection vehicleInspection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleInspection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["АвтоНаОгляд"] = new SelectList(_context.Cars, "КодАвто", "КодАвто", vehicleInspection.АвтоНаОгляд);
            return View(vehicleInspection);
        }

        // GET: VehicleInspections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VehicleInspections == null)
            {
                return NotFound();
            }

            var vehicleInspection = await _context.VehicleInspections.FindAsync(id);
            if (vehicleInspection == null)
            {
                return NotFound();
            }
            ViewData["АвтоНаОгляд"] = new SelectList(_context.Cars, "КодАвто", "КодАвто", vehicleInspection.АвтоНаОгляд);
            return View(vehicleInspection);
        }

        // POST: VehicleInspections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("НомерОгляду,АвтоНаОгляд,НомерКвитанціїСплатиПодатку,СумаПлатежуЗаОгляд,ПеревіреноТехнічніХарактеристики,ДатаОгляду")] VehicleInspection vehicleInspection)
        {
            if (id != vehicleInspection.НомерОгляду)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleInspection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleInspectionExists(vehicleInspection.НомерОгляду))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["АвтоНаОгляд"] = new SelectList(_context.Cars, "КодАвто", "КодАвто", vehicleInspection.АвтоНаОгляд);
            return View(vehicleInspection);
        }

        // GET: VehicleInspections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VehicleInspections == null)
            {
                return NotFound();
            }

            var vehicleInspection = await _context.VehicleInspections
                .Include(v => v.АвтоНаОглядNavigation)
                .FirstOrDefaultAsync(m => m.НомерОгляду == id);
            if (vehicleInspection == null)
            {
                return NotFound();
            }

            return View(vehicleInspection);
        }

        // POST: VehicleInspections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VehicleInspections == null)
            {
                return Problem("Entity set 'DAIContext.VehicleInspections'  is null.");
            }
            var vehicleInspection = await _context.VehicleInspections.FindAsync(id);
            if (vehicleInspection != null)
            {
                _context.VehicleInspections.Remove(vehicleInspection);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleInspectionExists(int id)
        {
          return (_context.VehicleInspections?.Any(e => e.НомерОгляду == id)).GetValueOrDefault();
        }
    }
}
