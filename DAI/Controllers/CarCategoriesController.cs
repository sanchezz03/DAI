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
    public class CarCategoriesController : Controller
    {
        private readonly DAIContext _context;

        public CarCategoriesController(DAIContext context)
        {
            _context = context;
        }

        // GET: CarCategories
        public async Task<IActionResult> Index()
        {
            var dAIContext = _context.CarCategories.Include(c => c.КатегоріяВодіяNavigation);
            return View(await dAIContext.ToListAsync());
        }

        // GET: CarCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarCategories == null)
            {
                return NotFound();
            }

            var carCategory = await _context.CarCategories
                .Include(c => c.КатегоріяВодіяNavigation)
                .FirstOrDefaultAsync(m => m.КодЗапису == id);
            if (carCategory == null)
            {
                return NotFound();
            }

            return View(carCategory);
        }

        // GET: CarCategories/Create
        public IActionResult Create()
        {
            ViewData["КатегоріяВодія"] = new SelectList(_context.DriverCategories, "КодЗапису", "КодЗапису");
            return View();
        }

        // POST: CarCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("КодЗапису,НазваКатегорії,КатегоріяВодія")] CarCategory carCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["КатегоріяВодія"] = new SelectList(_context.DriverCategories, "КодЗапису", "КодЗапису", carCategory.КатегоріяВодія);
            return View(carCategory);
        }

        // GET: CarCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarCategories == null)
            {
                return NotFound();
            }

            var carCategory = await _context.CarCategories.FindAsync(id);
            if (carCategory == null)
            {
                return NotFound();
            }
            ViewData["КатегоріяВодія"] = new SelectList(_context.DriverCategories, "КодЗапису", "КодЗапису", carCategory.КатегоріяВодія);
            return View(carCategory);
        }

        // POST: CarCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("КодЗапису,НазваКатегорії,КатегоріяВодія")] CarCategory carCategory)
        {
            if (id != carCategory.КодЗапису)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarCategoryExists(carCategory.КодЗапису))
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
            ViewData["КатегоріяВодія"] = new SelectList(_context.DriverCategories, "КодЗапису", "КодЗапису", carCategory.КатегоріяВодія);
            return View(carCategory);
        }

        // GET: CarCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarCategories == null)
            {
                return NotFound();
            }

            var carCategory = await _context.CarCategories
                .Include(c => c.КатегоріяВодіяNavigation)
                .FirstOrDefaultAsync(m => m.КодЗапису == id);
            if (carCategory == null)
            {
                return NotFound();
            }

            return View(carCategory);
        }

        // POST: CarCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarCategories == null)
            {
                return Problem("Entity set 'DAIContext.CarCategories'  is null.");
            }
            var carCategory = await _context.CarCategories.FindAsync(id);
            if (carCategory != null)
            {
                _context.CarCategories.Remove(carCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarCategoryExists(int id)
        {
          return (_context.CarCategories?.Any(e => e.КодЗапису == id)).GetValueOrDefault();
        }
    }
}
