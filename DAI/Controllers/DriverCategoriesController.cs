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
    public class DriverCategoriesController : Controller
    {
        private readonly DAIContext _context;

        public DriverCategoriesController(DAIContext context)
        {
            _context = context;
        }

        // GET: DriverCategories
        public async Task<IActionResult> Index()
        {
              return _context.DriverCategories != null ? 
                          View(await _context.DriverCategories.ToListAsync()) :
                          Problem("Entity set 'DAIContext.DriverCategories'  is null.");
        }

        // GET: DriverCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DriverCategories == null)
            {
                return NotFound();
            }

            var driverCategory = await _context.DriverCategories
                .FirstOrDefaultAsync(m => m.КодЗапису == id);
            if (driverCategory == null)
            {
                return NotFound();
            }

            return View(driverCategory);
        }

        // GET: DriverCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DriverCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("КодЗапису,НазваКатегорії,Опис")] DriverCategory driverCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(driverCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(driverCategory);
        }

        // GET: DriverCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DriverCategories == null)
            {
                return NotFound();
            }

            var driverCategory = await _context.DriverCategories.FindAsync(id);
            if (driverCategory == null)
            {
                return NotFound();
            }
            return View(driverCategory);
        }

        // POST: DriverCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("КодЗапису,НазваКатегорії,Опис")] DriverCategory driverCategory)
        {
            if (id != driverCategory.КодЗапису)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(driverCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriverCategoryExists(driverCategory.КодЗапису))
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
            return View(driverCategory);
        }

        // GET: DriverCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DriverCategories == null)
            {
                return NotFound();
            }

            var driverCategory = await _context.DriverCategories
                .FirstOrDefaultAsync(m => m.КодЗапису == id);
            if (driverCategory == null)
            {
                return NotFound();
            }

            return View(driverCategory);
        }

        // POST: DriverCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DriverCategories == null)
            {
                return Problem("Entity set 'DAIContext.DriverCategories'  is null.");
            }
            var driverCategory = await _context.DriverCategories.FindAsync(id);
            if (driverCategory != null)
            {
                _context.DriverCategories.Remove(driverCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DriverCategoryExists(int id)
        {
          return (_context.DriverCategories?.Any(e => e.КодЗапису == id)).GetValueOrDefault();
        }
    }
}
