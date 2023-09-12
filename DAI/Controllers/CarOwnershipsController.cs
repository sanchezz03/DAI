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
    public class CarOwnershipsController : Controller
    {
        private readonly DAIContext _context;

        public CarOwnershipsController(DAIContext context)
        {
            _context = context;
        }

        // GET: CarOwnerships
        public async Task<IActionResult> Index()
        {
            var dAIContext = _context.CarOwnerships.Include(c => c.КодАвтоNavigation).Include(c => c.КодВласникаNavigation);
            return View(await dAIContext.ToListAsync());
        }

        // GET: CarOwnerships/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarOwnerships == null)
            {
                return NotFound();
            }

            var carOwnership = await _context.CarOwnerships
                .Include(c => c.КодАвтоNavigation)
                .Include(c => c.КодВласникаNavigation)
                .FirstOrDefaultAsync(m => m.КодЗапису == id);
            if (carOwnership == null)
            {
                return NotFound();
            }

            return View(carOwnership);
        }

        // GET: CarOwnerships/Create
        public IActionResult Create()
        {
            ViewData["КодАвто"] = new SelectList(_context.CarNumberDirectories, "КодЗапису", "КодЗапису");
            ViewData["КодВласника"] = new SelectList(_context.OwnerOrganizations, "НомерЗапису", "НомерЗапису");
            return View();
        }

        // POST: CarOwnerships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("КодЗапису,КодВласника,КодАвто")] CarOwnership carOwnership)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carOwnership);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["КодАвто"] = new SelectList(_context.CarNumberDirectories, "КодЗапису", "КодЗапису", carOwnership.КодАвто);
            ViewData["КодВласника"] = new SelectList(_context.OwnerOrganizations, "НомерЗапису", "НомерЗапису", carOwnership.КодВласника);
            return View(carOwnership);
        }

        // GET: CarOwnerships/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarOwnerships == null)
            {
                return NotFound();
            }

            var carOwnership = await _context.CarOwnerships.FindAsync(id);
            if (carOwnership == null)
            {
                return NotFound();
            }
            ViewData["КодАвто"] = new SelectList(_context.CarNumberDirectories, "КодЗапису", "КодЗапису", carOwnership.КодАвто);
            ViewData["КодВласника"] = new SelectList(_context.OwnerOrganizations, "НомерЗапису", "НомерЗапису", carOwnership.КодВласника);
            return View(carOwnership);
        }

        // POST: CarOwnerships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("КодЗапису,КодВласника,КодАвто")] CarOwnership carOwnership)
        {
            if (id != carOwnership.КодЗапису)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carOwnership);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarOwnershipExists(carOwnership.КодЗапису))
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
            ViewData["КодАвто"] = new SelectList(_context.CarNumberDirectories, "КодЗапису", "КодЗапису", carOwnership.КодАвто);
            ViewData["КодВласника"] = new SelectList(_context.OwnerOrganizations, "НомерЗапису", "НомерЗапису", carOwnership.КодВласника);
            return View(carOwnership);
        }

        // GET: CarOwnerships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarOwnerships == null)
            {
                return NotFound();
            }

            var carOwnership = await _context.CarOwnerships
                .Include(c => c.КодАвтоNavigation)
                .Include(c => c.КодВласникаNavigation)
                .FirstOrDefaultAsync(m => m.КодЗапису == id);
            if (carOwnership == null)
            {
                return NotFound();
            }

            return View(carOwnership);
        }

        // POST: CarOwnerships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarOwnerships == null)
            {
                return Problem("Entity set 'DAIContext.CarOwnerships'  is null.");
            }
            var carOwnership = await _context.CarOwnerships.FindAsync(id);
            if (carOwnership != null)
            {
                _context.CarOwnerships.Remove(carOwnership);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarOwnershipExists(int id)
        {
          return (_context.CarOwnerships?.Any(e => e.КодЗапису == id)).GetValueOrDefault();
        }
    }
}
