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
    public class WlabelsController : Controller
    {
        private readonly WlabelContext _context;

        public WlabelsController(WlabelContext context)
        {
            _context = context;
        }

        // GET: Wlabels
        public async Task<IActionResult> Index()
        {
              return View(await _context.Wlabel.ToListAsync());
        }

        // GET: Wlabels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Wlabel == null)
            {
                return NotFound();
            }

            var wlabel = await _context.Wlabel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (wlabel == null)
            {
                return NotFound();
            }

            return View(wlabel);
        }

        // GET: Wlabels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Wlabels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PrintNumber,PrinterName")] Wlabel wlabel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wlabel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Hudson", "Home");
            }
            return View(wlabel);
        }

        // GET: Wlabels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Wlabel == null)
            {
                return NotFound();
            }

            var wlabel = await _context.Wlabel.FindAsync(id);
            if (wlabel == null)
            {
                return NotFound();
            }
            return View(wlabel);
        }

        // POST: Wlabels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PrintNumber,PrinterName")] Wlabel wlabel)
        {
            if (id != wlabel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wlabel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WlabelExists(wlabel.ID))
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
            return View(wlabel);
        }

        // GET: Wlabels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Wlabel == null)
            {
                return NotFound();
            }

            var wlabel = await _context.Wlabel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (wlabel == null)
            {
                return NotFound();
            }

            return View(wlabel);
        }

        // POST: Wlabels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Wlabel == null)
            {
                return Problem("Entity set 'WlabelContext.Wlabel'  is null.");
            }
            var wlabel = await _context.Wlabel.FindAsync(id);
            if (wlabel != null)
            {
                _context.Wlabel.Remove(wlabel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WlabelExists(int id)
        {
          return _context.Wlabel.Any(e => e.ID == id);
        }
    }
}
