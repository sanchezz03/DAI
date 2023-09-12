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
    public class CarNumberDirectoriesController : Controller
    {
        private readonly DAIContext _context;

        public CarNumberDirectoriesController(DAIContext context)
        {
            _context = context;
        }

        // GET: CarNumberDirectories
        public async Task<IActionResult> Index()
        {
            var dAIContext = _context.CarNumberDirectories.Include(c => c.НомерАвтоNavigation);
            return View(await dAIContext.ToListAsync());
        }

        // GET: CarNumberDirectories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarNumberDirectories == null)
            {
                return NotFound();
            }

            var carNumberDirectory = await _context.CarNumberDirectories
                .Include(c => c.НомерАвтоNavigation)
                .FirstOrDefaultAsync(m => m.КодЗапису == id);
            if (carNumberDirectory == null)
            {
                return NotFound();
            }

            return View(carNumberDirectory);
        }

        // GET: CarNumberDirectories/Create
        public IActionResult Create()
        {
            ViewData["НомерАвто"] = new SelectList(_context.Cars, "КодАвто", "КодАвто");
            return View();
        }

        // POST: CarNumberDirectories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("КодЗапису,НомерАвто,ФормаВластності,НомерВільний")] CarNumberDirectory carNumberDirectory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carNumberDirectory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["НомерАвто"] = new SelectList(_context.Cars, "КодАвто", "КодАвто", carNumberDirectory.НомерАвто);
            return View(carNumberDirectory);
        }

        // GET: CarNumberDirectories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarNumberDirectories == null)
            {
                return NotFound();
            }

            var carNumberDirectory = await _context.CarNumberDirectories.FindAsync(id);
            if (carNumberDirectory == null)
            {
                return NotFound();
            }
            ViewData["НомерАвто"] = new SelectList(_context.Cars, "КодАвто", "КодАвто", carNumberDirectory.НомерАвто);
            return View(carNumberDirectory);
        }

        // POST: CarNumberDirectories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("КодЗапису,НомерАвто,ФормаВластності,НомерВільний")] CarNumberDirectory carNumberDirectory)
        {
            if (id != carNumberDirectory.КодЗапису)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carNumberDirectory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarNumberDirectoryExists(carNumberDirectory.КодЗапису))
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
            ViewData["НомерАвто"] = new SelectList(_context.Cars, "КодАвто", "КодАвто", carNumberDirectory.НомерАвто);
            return View(carNumberDirectory);
        }

        // GET: CarNumberDirectories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarNumberDirectories == null)
            {
                return NotFound();
            }

            var carNumberDirectory = await _context.CarNumberDirectories
                .Include(c => c.НомерАвтоNavigation)
                .FirstOrDefaultAsync(m => m.КодЗапису == id);
            if (carNumberDirectory == null)
            {
                return NotFound();
            }

            return View(carNumberDirectory);
        }

        // POST: CarNumberDirectories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarNumberDirectories == null)
            {
                return Problem("Entity set 'DAIContext.CarNumberDirectories'  is null.");
            }
            var carNumberDirectory = await _context.CarNumberDirectories.FindAsync(id);
            if (carNumberDirectory != null)
            {
                _context.CarNumberDirectories.Remove(carNumberDirectory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarNumberDirectoryExists(int id)
        {
          return (_context.CarNumberDirectories?.Any(e => e.КодЗапису == id)).GetValueOrDefault();
        }
    }
}
