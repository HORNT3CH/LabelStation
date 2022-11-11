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
    public class ReprintsController : Controller
    {
        private readonly ReprintContext _context;

        public ReprintsController(ReprintContext context)
        {
            _context = context;
        }

        // GET: Reprints
        public async Task<IActionResult> Index()
        {
              return View(await _context.Reprint.ToListAsync());
        }

        // GET: Reprints/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reprint == null)
            {
                return NotFound();
            }

            var reprint = await _context.Reprint
                .FirstOrDefaultAsync(m => m.ID == id);
            if (reprint == null)
            {
                return NotFound();
            }

            return View(reprint);
        }

        // GET: Reprints/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reprints/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LPNumber,PrinterName")] Reprint reprint)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reprint);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(reprint);
        }

        // GET: Reprints/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reprint == null)
            {
                return NotFound();
            }

            var reprint = await _context.Reprint.FindAsync(id);
            if (reprint == null)
            {
                return NotFound();
            }
            return View(reprint);
        }

        // POST: Reprints/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,LPNumber,PrinterName")] Reprint reprint)
        {
            if (id != reprint.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reprint);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReprintExists(reprint.ID))
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
            return View(reprint);
        }

        // GET: Reprints/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reprint == null)
            {
                return NotFound();
            }

            var reprint = await _context.Reprint
                .FirstOrDefaultAsync(m => m.ID == id);
            if (reprint == null)
            {
                return NotFound();
            }

            return View(reprint);
        }

        // POST: Reprints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reprint == null)
            {
                return Problem("Entity set 'ReprintContext.Reprint'  is null.");
            }
            var reprint = await _context.Reprint.FindAsync(id);
            if (reprint != null)
            {
                _context.Reprint.Remove(reprint);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReprintExists(int id)
        {
          return _context.Reprint.Any(e => e.ID == id);
        }
    }
}
