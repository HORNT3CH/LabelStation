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
    public class RWlabelsController : Controller
    {
        private readonly RWlabelContext _context;

        public RWlabelsController(RWlabelContext context)
        {
            _context = context;
        }

        // GET: RWlabels
        public async Task<IActionResult> Index()
        {
              return View(await _context.RWlabel.ToListAsync());
        }

        // GET: RWlabels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RWlabel == null)
            {
                return NotFound();
            }

            var rWlabel = await _context.RWlabel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rWlabel == null)
            {
                return NotFound();
            }

            return View(rWlabel);
        }

        // GET: RWlabels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RWlabels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PrintNumber")] RWlabel rWlabel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rWlabel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Hudson", "Home");
            }
            return View(rWlabel);
        }

        // GET: RWlabels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RWlabel == null)
            {
                return NotFound();
            }

            var rWlabel = await _context.RWlabel.FindAsync(id);
            if (rWlabel == null)
            {
                return NotFound();
            }
            return View(rWlabel);
        }

        // POST: RWlabels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PrintNumber")] RWlabel rWlabel)
        {
            if (id != rWlabel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rWlabel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RWlabelExists(rWlabel.ID))
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
            return View(rWlabel);
        }

        // GET: RWlabels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RWlabel == null)
            {
                return NotFound();
            }

            var rWlabel = await _context.RWlabel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rWlabel == null)
            {
                return NotFound();
            }

            return View(rWlabel);
        }

        // POST: RWlabels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RWlabel == null)
            {
                return Problem("Entity set 'RWlabelContext.RWlabel'  is null.");
            }
            var rWlabel = await _context.RWlabel.FindAsync(id);
            if (rWlabel != null)
            {
                _context.RWlabel.Remove(rWlabel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RWlabelExists(int id)
        {
          return _context.RWlabel.Any(e => e.ID == id);
        }
    }
}
