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
    public class PlabelsController : Controller
    {
        private readonly PlabelContext _context;

        public PlabelsController(PlabelContext context)
        {
            _context = context;
        }

        // GET: Plabels
        public async Task<IActionResult> Index()
        {
              return View(await _context.Plabel.ToListAsync());
        }

        // GET: Plabels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Plabel == null)
            {
                return NotFound();
            }

            var plabel = await _context.Plabel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (plabel == null)
            {
                return NotFound();
            }

            return View(plabel);
        }

        // GET: Plabels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Plabels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PrintNumber")] Plabel plabel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plabel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Hudson", "Home");
            }
            return View(plabel);
        }

        // GET: Plabels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Plabel == null)
            {
                return NotFound();
            }

            var plabel = await _context.Plabel.FindAsync(id);
            if (plabel == null)
            {
                return NotFound();
            }
            return View(plabel);
        }

        // POST: Plabels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PrintNumber")] Plabel plabel)
        {
            if (id != plabel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plabel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlabelExists(plabel.ID))
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
            return View(plabel);
        }

        // GET: Plabels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Plabel == null)
            {
                return NotFound();
            }

            var plabel = await _context.Plabel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (plabel == null)
            {
                return NotFound();
            }

            return View(plabel);
        }

        // POST: Plabels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Plabel == null)
            {
                return Problem("Entity set 'PlabelContext.Plabel'  is null.");
            }
            var plabel = await _context.Plabel.FindAsync(id);
            if (plabel != null)
            {
                _context.Plabel.Remove(plabel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlabelExists(int id)
        {
          return _context.Plabel.Any(e => e.ID == id);
        }
    }
}
