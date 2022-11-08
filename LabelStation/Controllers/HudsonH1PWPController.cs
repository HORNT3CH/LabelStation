using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LabelStation.Data;
using LabelStation.Models;
using cloudscribe.Pagination.Models;

namespace LabelStation.Controllers
{
    public class HudsonH1PWPController : Controller
    {
        private readonly HudsonH1PWPContext _context;

        public HudsonH1PWPController(HudsonH1PWPContext context)
        {
            _context = context;
        }

        // GET: HudsonH1PWP
        public async Task<IActionResult> Index()
        {
            return View(await _context.HudsonH1PWP.ToListAsync());
        }


        // GET: HudsonH1PWP/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HudsonH1PWP == null)
            {
                return NotFound();
            }

            var hudsonH1PWP = await _context.HudsonH1PWP
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hudsonH1PWP == null)
            {
                return NotFound();
            }

            return View(hudsonH1PWP);
        }

        // GET: HudsonH1PWP/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HudsonH1PWP/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,ItemNumber,ProductionDate,CodePartA,CodePartB,CodePartC,Shift,PrintQty,MachineNumber")] HudsonH1PWP hudsonH1PWP)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hudsonH1PWP);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hudsonH1PWP);
        }

        // GET: HudsonH1PWP/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HudsonH1PWP == null)
            {
                return NotFound();
            }

            var hudsonH1PWP = await _context.HudsonH1PWP.FindAsync(id);
            if (hudsonH1PWP == null)
            {
                return NotFound();
            }
            return View(hudsonH1PWP);
        }

        // POST: HudsonH1PWP/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,ItemNumber,ProductionDate,CodePartA,CodePartB,CodePartC,Shift,PrintQty,MachineNumber")] HudsonH1PWP hudsonH1PWP)
        {
            if (id != hudsonH1PWP.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hudsonH1PWP);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HudsonH1PWPExists(hudsonH1PWP.ID))
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
            return View(hudsonH1PWP);
        }

        // GET: HudsonH1PWP/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HudsonH1PWP == null)
            {
                return NotFound();
            }

            var hudsonH1PWP = await _context.HudsonH1PWP
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hudsonH1PWP == null)
            {
                return NotFound();
            }

            return View(hudsonH1PWP);
        }

        // POST: HudsonH1PWP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HudsonH1PWP == null)
            {
                return Problem("Entity set 'HudsonH1PWPContext.HudsonH1PWP'  is null.");
            }
            var hudsonH1PWP = await _context.HudsonH1PWP.FindAsync(id);
            if (hudsonH1PWP != null)
            {
                _context.HudsonH1PWP.Remove(hudsonH1PWP);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HudsonH1PWPExists(int id)
        {
          return _context.HudsonH1PWP.Any(e => e.ID == id);
        }
    }
}
