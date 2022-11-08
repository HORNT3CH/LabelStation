using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LabelStation.Data;
using LabelStation.Models;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http.Features;

namespace LabelStation.Controllers
{
    public class BULabelsController : Controller
    {
        private readonly BULabelContext _context;

        public BULabelsController(BULabelContext context)
        {
            _context = context;
        }

        // GET: BULabels
        public async Task<IActionResult> Index()
        {
              return View(await _context.BULabel.ToListAsync());
        }

        // GET: BULabels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BULabel == null)
            {
                return NotFound();
            }

            var bULabel = await _context.BULabel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bULabel == null)
            {
                return NotFound();
            }

            return View(bULabel);
        }

        // GET: BULabels/Create
        public IActionResult Create()
        {            
            return View();
        }

        // POST: BULabels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Print,ItemNumber,ItemDescription,Quantity,Standard")] BULabel bULabel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bULabel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bULabel);
        }

        // GET: BULabels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BULabel == null)
            {
                return NotFound();
            }

            var bULabel = await _context.BULabel.FindAsync(id);
            if (bULabel == null)
            {
                return NotFound();
            }
            return View(bULabel);
        }

        // POST: BULabels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Print,ItemNumber,ItemDescription,Quantity,Standard")] BULabel bULabel)
        {
            if (id != bULabel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bULabel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BULabelExists(bULabel.ID))
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
            return View(bULabel);
        }

        // GET: BULabels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BULabel == null)
            {
                return NotFound();
            }

            var bULabel = await _context.BULabel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bULabel == null)
            {
                return NotFound();
            }

            return View(bULabel);
        }

        // POST: BULabels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BULabel == null)
            {
                return Problem("Entity set 'BULabelContext.BULabel'  is null.");
            }
            var bULabel = await _context.BULabel.FindAsync(id);
            if (bULabel != null)
            {
                _context.BULabel.Remove(bULabel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BULabelExists(int id)
        {
          return _context.BULabel.Any(e => e.ID == id);
        }
    }
}
