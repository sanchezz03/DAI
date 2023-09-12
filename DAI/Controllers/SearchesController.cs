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
    public class SearchesController : Controller
    {
        private readonly DAIContext _context;

        public SearchesController(DAIContext context)
        {
            _context = context;
        }

        // GET: Searches
        public async Task<IActionResult> Index()
        {
              return _context.Searches != null ? 
                          View(await _context.Searches.ToListAsync()) :
                          Problem("Entity set 'DAIContext.Searches'  is null.");
        }

        // GET: Searches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Searches == null)
            {
                return NotFound();
            }

            var search = await _context.Searches
                .FirstOrDefaultAsync(m => m.КодЗапису == id);
            if (search == null)
            {
                return NotFound();
            }

            return View(search);
        }

        // GET: Searches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Searches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("КодЗапису,КодАвто,КодВласника,ДатаПропажі,ВмістБагажуСалону")] Search search)
        {
            if (ModelState.IsValid)
            {
                _context.Add(search);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(search);
        }

        // GET: Searches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Searches == null)
            {
                return NotFound();
            }

            var search = await _context.Searches.FindAsync(id);
            if (search == null)
            {
                return NotFound();
            }
            return View(search);
        }

        // POST: Searches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("КодЗапису,КодАвто,КодВласника,ДатаПропажі,ВмістБагажуСалону")] Search search)
        {
            if (id != search.КодЗапису)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(search);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SearchExists(search.КодЗапису))
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
            return View(search);
        }

        // GET: Searches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Searches == null)
            {
                return NotFound();
            }

            var search = await _context.Searches
                .FirstOrDefaultAsync(m => m.КодЗапису == id);
            if (search == null)
            {
                return NotFound();
            }

            return View(search);
        }

        // POST: Searches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Searches == null)
            {
                return Problem("Entity set 'DAIContext.Searches'  is null.");
            }
            var search = await _context.Searches.FindAsync(id);
            if (search != null)
            {
                _context.Searches.Remove(search);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SearchExists(int id)
        {
          return (_context.Searches?.Any(e => e.КодЗапису == id)).GetValueOrDefault();
        }
    }
}
