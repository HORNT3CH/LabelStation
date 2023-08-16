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
    public class NameBadgesController : Controller
    {
        private readonly NameBadgesContext _context;

        public NameBadgesController(NameBadgesContext context)
        {
            _context = context;
        }

        // GET: NameBadges
        public async Task<IActionResult> Index()
        {
              return _context.NameBadge != null ? 
                          View(await _context.NameBadge.ToListAsync()) :
                          Problem("Entity set 'NameBadgesContext.NameBadge'  is null.");
        }

        // GET: NameBadges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NameBadge == null)
            {
                return NotFound();
            }

            var nameBadge = await _context.NameBadge
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nameBadge == null)
            {
                return NotFound();
            }

            return View(nameBadge);
        }

        // GET: NameBadges/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NameBadges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PrintName,HJUser,PrinterName")] NameBadge nameBadge)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nameBadge);
                await _context.SaveChangesAsync();
                return RedirectToAction("Hudson", "Home");
            }
            return View(nameBadge);
        }

        // GET: NameBadges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NameBadge == null)
            {
                return NotFound();
            }

            var nameBadge = await _context.NameBadge.FindAsync(id);
            if (nameBadge == null)
            {
                return NotFound();
            }
            return View(nameBadge);
        }

        // POST: NameBadges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PrintName,HJUser,PrinterName")] NameBadge nameBadge)
        {
            if (id != nameBadge.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nameBadge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NameBadgeExists(nameBadge.ID))
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
            return View(nameBadge);
        }

        // GET: NameBadges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NameBadge == null)
            {
                return NotFound();
            }

            var nameBadge = await _context.NameBadge
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nameBadge == null)
            {
                return NotFound();
            }

            return View(nameBadge);
        }

        // POST: NameBadges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NameBadge == null)
            {
                return Problem("Entity set 'NameBadgesContext.NameBadge'  is null.");
            }
            var nameBadge = await _context.NameBadge.FindAsync(id);
            if (nameBadge != null)
            {
                _context.NameBadge.Remove(nameBadge);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NameBadgeExists(int id)
        {
          return (_context.NameBadge?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
