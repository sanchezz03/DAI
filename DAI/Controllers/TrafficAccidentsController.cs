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
    public class TrafficAccidentsController : Controller
    {
        private readonly DAIContext _context;

        public TrafficAccidentsController(DAIContext context)
        {
            _context = context;
        }

        // GET: TrafficAccidents
        public async Task<IActionResult> Index()
        {
              return _context.TrafficAccidents != null ? 
                          View(await _context.TrafficAccidents.ToListAsync()) :
                          Problem("Entity set 'DAIContext.TrafficAccidents'  is null.");
        }

        // GET: TrafficAccidents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TrafficAccidents == null)
            {
                return NotFound();
            }

            var trafficAccident = await _context.TrafficAccidents
                .FirstOrDefaultAsync(m => m.НомерTrafficAccident == id);
            if (trafficAccident == null)
            {
                return NotFound();
            }

            return View(trafficAccident);
        }

        // GET: TrafficAccidents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrafficAccidents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("НомерTrafficAccident,ДатаTrafficAccident,МісцеПодії,КороткийЗміст,КількістьПостраждалих,СумаЗбитків,Причина,ДорожніУмови,ЗникненняВинуватця")] TrafficAccident trafficAccident)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trafficAccident);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trafficAccident);
        }

        // GET: TrafficAccidents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TrafficAccidents == null)
            {
                return NotFound();
            }

            var trafficAccident = await _context.TrafficAccidents.FindAsync(id);
            if (trafficAccident == null)
            {
                return NotFound();
            }
            return View(trafficAccident);
        }

        // POST: TrafficAccidents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("НомерTrafficAccident,ДатаTrafficAccident,МісцеПодії,КороткийЗміст,КількістьПостраждалих,СумаЗбитків,Причина,ДорожніУмови,ЗникненняВинуватця")] TrafficAccident trafficAccident)
        {
            if (id != trafficAccident.НомерTrafficAccident)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trafficAccident);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrafficAccidentExists(trafficAccident.НомерTrafficAccident))
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
            return View(trafficAccident);
        }

        // GET: TrafficAccidents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TrafficAccidents == null)
            {
                return NotFound();
            }

            var trafficAccident = await _context.TrafficAccidents
                .FirstOrDefaultAsync(m => m.НомерTrafficAccident == id);
            if (trafficAccident == null)
            {
                return NotFound();
            }

            return View(trafficAccident);
        }

        // POST: TrafficAccidents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TrafficAccidents == null)
            {
                return Problem("Entity set 'DAIContext.TrafficAccidents'  is null.");
            }
            var trafficAccident = await _context.TrafficAccidents.FindAsync(id);
            if (trafficAccident != null)
            {
                _context.TrafficAccidents.Remove(trafficAccident);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrafficAccidentExists(int id)
        {
          return (_context.TrafficAccidents?.Any(e => e.НомерTrafficAccident == id)).GetValueOrDefault();
        }
    }
}
