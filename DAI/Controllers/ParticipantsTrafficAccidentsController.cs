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
    public class ParticipantsTrafficAccidentsController : Controller
    {
        private readonly DAIContext _context;

        public ParticipantsTrafficAccidentsController(DAIContext context)
        {
            _context = context;
        }

        // GET: ParticipantsTrafficAccidents
        public async Task<IActionResult> Index()
        {
            var dAIContext = _context.ParticipantsTrafficAccidents.Include(p => p.НомерTrafficAccidentNavigation).Include(p => p.НомерАвтоNavigation).Include(p => p.ТипМашиниNavigation);
            return View(await dAIContext.ToListAsync());
        }

        // GET: ParticipantsTrafficAccidents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ParticipantsTrafficAccidents == null)
            {
                return NotFound();
            }

            var participantsTrafficAccident = await _context.ParticipantsTrafficAccidents
                .Include(p => p.НомерTrafficAccidentNavigation)
                .Include(p => p.НомерАвтоNavigation)
                .Include(p => p.ТипМашиниNavigation)
                .FirstOrDefaultAsync(m => m.НомерЗапису == id);
            if (participantsTrafficAccident == null)
            {
                return NotFound();
            }

            return View(participantsTrafficAccident);
        }

        // GET: ParticipantsTrafficAccidents/Create
        public IActionResult Create()
        {
            ViewData["НомерTrafficAccident"] = new SelectList(_context.TrafficAccidents, "НомерTrafficAccident", "НомерTrafficAccident");
            ViewData["НомерАвто"] = new SelectList(_context.Cars, "КодАвто", "КодАвто");
            ViewData["ТипМашини"] = new SelectList(_context.CarCategories, "КодЗапису", "КодЗапису");
            return View();
        }

        // POST: ParticipantsTrafficAccidents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("НомерЗапису,НомерTrafficAccident,НомерАвто,Серія,МаркаАвто,ТипМашини")] ParticipantsTrafficAccident participantsTrafficAccident)
        {
            if (ModelState.IsValid)
            {
                _context.Add(participantsTrafficAccident);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["НомерTrafficAccident"] = new SelectList(_context.TrafficAccidents, "НомерTrafficAccident", "НомерTrafficAccident", participantsTrafficAccident.НомерTrafficAccident);
            ViewData["НомерАвто"] = new SelectList(_context.Cars, "КодАвто", "КодАвто", participantsTrafficAccident.НомерАвто);
            ViewData["ТипМашини"] = new SelectList(_context.CarCategories, "КодЗапису", "КодЗапису", participantsTrafficAccident.ТипМашини);
            return View(participantsTrafficAccident);
        }

        // GET: ParticipantsTrafficAccidents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ParticipantsTrafficAccidents == null)
            {
                return NotFound();
            }

            var participantsTrafficAccident = await _context.ParticipantsTrafficAccidents.FindAsync(id);
            if (participantsTrafficAccident == null)
            {
                return NotFound();
            }
            ViewData["НомерTrafficAccident"] = new SelectList(_context.TrafficAccidents, "НомерTrafficAccident", "НомерTrafficAccident", participantsTrafficAccident.НомерTrafficAccident);
            ViewData["НомерАвто"] = new SelectList(_context.Cars, "КодАвто", "КодАвто", participantsTrafficAccident.НомерАвто);
            ViewData["ТипМашини"] = new SelectList(_context.CarCategories, "КодЗапису", "КодЗапису", participantsTrafficAccident.ТипМашини);
            return View(participantsTrafficAccident);
        }

        // POST: ParticipantsTrafficAccidents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("НомерЗапису,НомерTrafficAccident,НомерАвто,Серія,МаркаАвто,ТипМашини")] ParticipantsTrafficAccident participantsTrafficAccident)
        {
            if (id != participantsTrafficAccident.НомерЗапису)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(participantsTrafficAccident);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParticipantsTrafficAccidentExists(participantsTrafficAccident.НомерЗапису))
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
            ViewData["НомерTrafficAccident"] = new SelectList(_context.TrafficAccidents, "НомерTrafficAccident", "НомерTrafficAccident", participantsTrafficAccident.НомерTrafficAccident);
            ViewData["НомерАвто"] = new SelectList(_context.Cars, "КодАвто", "КодАвто", participantsTrafficAccident.НомерАвто);
            ViewData["ТипМашини"] = new SelectList(_context.CarCategories, "КодЗапису", "КодЗапису", participantsTrafficAccident.ТипМашини);
            return View(participantsTrafficAccident);
        }

        // GET: ParticipantsTrafficAccidents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ParticipantsTrafficAccidents == null)
            {
                return NotFound();
            }

            var participantsTrafficAccident = await _context.ParticipantsTrafficAccidents
                .Include(p => p.НомерTrafficAccidentNavigation)
                .Include(p => p.НомерАвтоNavigation)
                .Include(p => p.ТипМашиниNavigation)
                .FirstOrDefaultAsync(m => m.НомерЗапису == id);
            if (participantsTrafficAccident == null)
            {
                return NotFound();
            }

            return View(participantsTrafficAccident);
        }

        // POST: ParticipantsTrafficAccidents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ParticipantsTrafficAccidents == null)
            {
                return Problem("Entity set 'DAIContext.ParticipantsTrafficAccidents'  is null.");
            }
            var participantsTrafficAccident = await _context.ParticipantsTrafficAccidents.FindAsync(id);
            if (participantsTrafficAccident != null)
            {
                _context.ParticipantsTrafficAccidents.Remove(participantsTrafficAccident);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParticipantsTrafficAccidentExists(int id)
        {
          return (_context.ParticipantsTrafficAccidents?.Any(e => e.НомерЗапису == id)).GetValueOrDefault();
        }
    }
}
