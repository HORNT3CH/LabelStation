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
    public class HlabelsController : Controller
    {
        private readonly HLabelContext _context;

        public HlabelsController(HLabelContext context)
        {
            _context = context;
        }

        // GET: Hlabels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hlabel.ToListAsync());
        }

        // GET: Hlabels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hlabel == null)
            {
                return NotFound();
            }

            var hlabel = await _context.Hlabel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hlabel == null)
            {
                return NotFound();
            }

            return View(hlabel);
        }

        // GET: Hlabels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hlabels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PrintNumber")] Hlabel hlabel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hlabel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hlabel);
        }

        // GET: Hlabels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hlabel == null)
            {
                return NotFound();
            }

            var hlabel = await _context.Hlabel.FindAsync(id);
            if (hlabel == null)
            {
                return NotFound();
            }
            return View(hlabel);
        }

        // POST: Hlabels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PrintNumber")] Hlabel hlabel)
        {
            if (id != hlabel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hlabel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HlabelExists(hlabel.ID))
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
            return View(hlabel);
        }

        // GET: Hlabels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hlabel == null)
            {
                return NotFound();
            }

            var hlabel = await _context.Hlabel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hlabel == null)
            {
                return NotFound();
            }

            return View(hlabel);
        }

        // POST: Hlabels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hlabel == null)
            {
                return Problem("Entity set 'HLabelContext.Hlabel'  is null.");
            }
            var hlabel = await _context.Hlabel.FindAsync(id);
            if (hlabel != null)
            {
                _context.Hlabel.Remove(hlabel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HlabelExists(int id)
        {
            return _context.Hlabel.Any(e => e.ID == id);
        }
    }
}
