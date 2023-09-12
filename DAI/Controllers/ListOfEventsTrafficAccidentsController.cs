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
    public class ListOfEventsTrafficAccidentsController : Controller
    {
        private readonly DAIContext _context;

        public ListOfEventsTrafficAccidentsController(DAIContext context)
        {
            _context = context;
        }

        // GET: ListOfEventsTrafficAccidents
        public async Task<IActionResult> Index()
        {
            var dAIContext = _context.ListOfEventsTrafficAccidents.Include(l => l.КодКатегоріїПодіїNavigation).Include(l => l.НомерTrafficAccidentNavigation);
            return View(await dAIContext.ToListAsync());
        }

        // GET: ListOfEventsTrafficAccidents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ListOfEventsTrafficAccidents == null)
            {
                return NotFound();
            }

            var listOfEventsTrafficAccident = await _context.ListOfEventsTrafficAccidents
                .Include(l => l.КодКатегоріїПодіїNavigation)
                .Include(l => l.НомерTrafficAccidentNavigation)
                .FirstOrDefaultAsync(m => m.КодЗапису == id);
            if (listOfEventsTrafficAccident == null)
            {
                return NotFound();
            }

            return View(listOfEventsTrafficAccident);
        }

        // GET: ListOfEventsTrafficAccidents/Create
        public IActionResult Create()
        {
            ViewData["КодКатегоріїПодії"] = new SelectList(_context.КатегоріїПодійs, "КодКатегорії", "КодКатегорії");
            ViewData["НомерTrafficAccident"] = new SelectList(_context.TrafficAccidents, "НомерTrafficAccident", "НомерTrafficAccident");
            return View();
        }

        // POST: ListOfEventsTrafficAccidents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("КодЗапису,НомерTrafficAccident,КодКатегоріїПодії")] ListOfEventsTrafficAccident listOfEventsTrafficAccident)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listOfEventsTrafficAccident);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["КодКатегоріїПодії"] = new SelectList(_context.КатегоріїПодійs, "КодКатегорії", "КодКатегорії", listOfEventsTrafficAccident.КодКатегоріїПодії);
            ViewData["НомерTrafficAccident"] = new SelectList(_context.TrafficAccidents, "НомерTrafficAccident", "НомерTrafficAccident", listOfEventsTrafficAccident.НомерTrafficAccident);
            return View(listOfEventsTrafficAccident);
        }

        // GET: ListOfEventsTrafficAccidents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ListOfEventsTrafficAccidents == null)
            {
                return NotFound();
            }

            var listOfEventsTrafficAccident = await _context.ListOfEventsTrafficAccidents.FindAsync(id);
            if (listOfEventsTrafficAccident == null)
            {
                return NotFound();
            }
            ViewData["КодКатегоріїПодії"] = new SelectList(_context.КатегоріїПодійs, "КодКатегорії", "КодКатегорії", listOfEventsTrafficAccident.КодКатегоріїПодії);
            ViewData["НомерTrafficAccident"] = new SelectList(_context.TrafficAccidents, "НомерTrafficAccident", "НомерTrafficAccident", listOfEventsTrafficAccident.НомерTrafficAccident);
            return View(listOfEventsTrafficAccident);
        }

        // POST: ListOfEventsTrafficAccidents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("КодЗапису,НомерTrafficAccident,КодКатегоріїПодії")] ListOfEventsTrafficAccident listOfEventsTrafficAccident)
        {
            if (id != listOfEventsTrafficAccident.КодЗапису)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listOfEventsTrafficAccident);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListOfEventsTrafficAccidentExists(listOfEventsTrafficAccident.КодЗапису))
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
            ViewData["КодКатегоріїПодії"] = new SelectList(_context.КатегоріїПодійs, "КодКатегорії", "КодКатегорії", listOfEventsTrafficAccident.КодКатегоріїПодії);
            ViewData["НомерTrafficAccident"] = new SelectList(_context.TrafficAccidents, "НомерTrafficAccident", "НомерTrafficAccident", listOfEventsTrafficAccident.НомерTrafficAccident);
            return View(listOfEventsTrafficAccident);
        }

        // GET: ListOfEventsTrafficAccidents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ListOfEventsTrafficAccidents == null)
            {
                return NotFound();
            }

            var listOfEventsTrafficAccident = await _context.ListOfEventsTrafficAccidents
                .Include(l => l.КодКатегоріїПодіїNavigation)
                .Include(l => l.НомерTrafficAccidentNavigation)
                .FirstOrDefaultAsync(m => m.КодЗапису == id);
            if (listOfEventsTrafficAccident == null)
            {
                return NotFound();
            }

            return View(listOfEventsTrafficAccident);
        }

        // POST: ListOfEventsTrafficAccidents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ListOfEventsTrafficAccidents == null)
            {
                return Problem("Entity set 'DAIContext.ListOfEventsTrafficAccidents'  is null.");
            }
            var listOfEventsTrafficAccident = await _context.ListOfEventsTrafficAccidents.FindAsync(id);
            if (listOfEventsTrafficAccident != null)
            {
                _context.ListOfEventsTrafficAccidents.Remove(listOfEventsTrafficAccident);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListOfEventsTrafficAccidentExists(int id)
        {
          return (_context.ListOfEventsTrafficAccidents?.Any(e => e.КодЗапису == id)).GetValueOrDefault();
        }
    }
}
