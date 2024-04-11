using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LabelStation.Data;
using LabelStation.Models;

namespace LabelStation.Controllers
{
    public class HorticulturalContainersController : Controller
    {
        private readonly HorticulturalContainersContext _context;

        public HorticulturalContainersController(HorticulturalContainersContext context)
        {
            _context = context;
        }

        // GET: HorticulturalContainers
        public async Task<IActionResult> Index()
        {
              return _context.HorticulturalContainers != null ? 
                          View(await _context.HorticulturalContainers.ToListAsync()) :
                          Problem("Entity set 'HorticulturalContainersContext.HorticulturalContainers'  is null.");
        }

        // GET: HorticulturalContainers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HorticulturalContainers == null)
            {
                return NotFound();
            }

            var horticulturalContainers = await _context.HorticulturalContainers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (horticulturalContainers == null)
            {
                return NotFound();
            }

            return View(horticulturalContainers);
        }

        // GET: HorticulturalContainers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HorticulturalContainers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LTPartNumber,CustomerPartNumber,Description,Barcode,PackAmount,Quantity,Print")] HorticulturalContainers horticulturalContainers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(horticulturalContainers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(horticulturalContainers);
        }

        // GET: HorticulturalContainers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HorticulturalContainers == null)
            {
                return NotFound();
            }

            var horticulturalContainers = await _context.HorticulturalContainers.FindAsync(id);
            if (horticulturalContainers == null)
            {
                return NotFound();
            }
            return View(horticulturalContainers);
        }

        // POST: HorticulturalContainers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LTPartNumber,CustomerPartNumber,Description,Barcode,PackAmount,Quantity,Print")] HorticulturalContainers horticulturalContainers)
        {
            if (id != horticulturalContainers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horticulturalContainers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HorticulturalContainersExists(horticulturalContainers.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Hudson", "Home");
            }
            return View(horticulturalContainers);
        }

        // GET: HorticulturalContainers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HorticulturalContainers == null)
            {
                return NotFound();
            }

            var horticulturalContainers = await _context.HorticulturalContainers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (horticulturalContainers == null)
            {
                return NotFound();
            }

            return View(horticulturalContainers);
        }

        // POST: HorticulturalContainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HorticulturalContainers == null)
            {
                return Problem("Entity set 'HorticulturalContainersContext.HorticulturalContainers'  is null.");
            }
            var horticulturalContainers = await _context.HorticulturalContainers.FindAsync(id);
            if (horticulturalContainers != null)
            {
                _context.HorticulturalContainers.Remove(horticulturalContainers);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HorticulturalContainersExists(int id)
        {
          return (_context.HorticulturalContainers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
