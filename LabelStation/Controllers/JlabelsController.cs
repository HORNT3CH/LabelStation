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
    public class JlabelsController : Controller
    {
        private readonly JlabelContext _context;

        public JlabelsController(JlabelContext context)
        {
            _context = context;
        }

        // GET: Jlabels
        public async Task<IActionResult> Index()
        {
              return View(await _context.Jlabel.ToListAsync());
        }

        // GET: Jlabels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Jlabel == null)
            {
                return NotFound();
            }

            var jlabel = await _context.Jlabel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (jlabel == null)
            {
                return NotFound();
            }

            return View(jlabel);
        }

        // GET: Jlabels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jlabels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PrintNumber")] Jlabel jlabel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jlabel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Juarez", "Home");
            }
            return View(jlabel);
        }

        // GET: Jlabels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Jlabel == null)
            {
                return NotFound();
            }

            var jlabel = await _context.Jlabel.FindAsync(id);
            if (jlabel == null)
            {
                return NotFound();
            }
            return View(jlabel);
        }

        // POST: Jlabels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PrintNumber")] Jlabel jlabel)
        {
            if (id != jlabel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jlabel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JlabelExists(jlabel.ID))
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
            return View(jlabel);
        }

        // GET: Jlabels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Jlabel == null)
            {
                return NotFound();
            }

            var jlabel = await _context.Jlabel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (jlabel == null)
            {
                return NotFound();
            }

            return View(jlabel);
        }

        // POST: Jlabels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Jlabel == null)
            {
                return Problem("Entity set 'JlabelContext.Jlabel'  is null.");
            }
            var jlabel = await _context.Jlabel.FindAsync(id);
            if (jlabel != null)
            {
                _context.Jlabel.Remove(jlabel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JlabelExists(int id)
        {
          return _context.Jlabel.Any(e => e.ID == id);
        }
    }
}
