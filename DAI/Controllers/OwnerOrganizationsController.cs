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
    public class OwnerOrganizationsController : Controller
    {
        private readonly DAIContext _context;

        public OwnerOrganizationsController(DAIContext context)
        {
            _context = context;
        }

        // GET: OwnerOrganizations
        public async Task<IActionResult> Index()
        {
              return _context.OwnerOrganizations != null ? 
                          View(await _context.OwnerOrganizations.ToListAsync()) :
                          Problem("Entity set 'DAIContext.OwnerOrganizations'  is null.");
        }

        // GET: OwnerOrganizations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OwnerOrganizations == null)
            {
                return NotFound();
            }

            var ownerOrganization = await _context.OwnerOrganizations
                .FirstOrDefaultAsync(m => m.НомерЗапису == id);
            if (ownerOrganization == null)
            {
                return NotFound();
            }

            return View(ownerOrganization);
        }

        // GET: OwnerOrganizations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OwnerOrganizations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("НомерЗапису,Імя,Прізвище,ПоБатькові,ДатаНародження,АдресаПроживанняВласника,СеріяПаспорта,НомерПаспорта,НазваОрганізації,Район,Адреса,Керівник")] OwnerOrganization ownerOrganization)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ownerOrganization);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ownerOrganization);
        }

        // GET: OwnerOrganizations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OwnerOrganizations == null)
            {
                return NotFound();
            }

            var ownerOrganization = await _context.OwnerOrganizations.FindAsync(id);
            if (ownerOrganization == null)
            {
                return NotFound();
            }
            return View(ownerOrganization);
        }

        // POST: OwnerOrganizations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("НомерЗапису,Імя,Прізвище,ПоБатькові,ДатаНародження,АдресаПроживанняВласника,СеріяПаспорта,НомерПаспорта,НазваОрганізації,Район,Адреса,Керівник")] OwnerOrganization ownerOrganization)
        {
            if (id != ownerOrganization.НомерЗапису)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ownerOrganization);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OwnerOrganizationExists(ownerOrganization.НомерЗапису))
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
            return View(ownerOrganization);
        }

        // GET: OwnerOrganizations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OwnerOrganizations == null)
            {
                return NotFound();
            }

            var ownerOrganization = await _context.OwnerOrganizations
                .FirstOrDefaultAsync(m => m.НомерЗапису == id);
            if (ownerOrganization == null)
            {
                return NotFound();
            }

            return View(ownerOrganization);
        }

        // POST: OwnerOrganizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OwnerOrganizations == null)
            {
                return Problem("Entity set 'DAIContext.OwnerOrganizations'  is null.");
            }
            var ownerOrganization = await _context.OwnerOrganizations.FindAsync(id);
            if (ownerOrganization != null)
            {
                _context.OwnerOrganizations.Remove(ownerOrganization);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OwnerOrganizationExists(int id)
        {
          return (_context.OwnerOrganizations?.Any(e => e.НомерЗапису == id)).GetValueOrDefault();
        }
    }
}
