using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using LabelStation.Data;
using LabelStation.Models;
using LabelStation.ViewModels;


namespace LabelStation.Controllers
{
    public class PWPLabelsController : Controller
    {
        private readonly PWPLabelsContext _context;

        public PWPLabelsController(PWPLabelsContext context)
        {
            _context = context;
        }

        // GET: PWPLabels
        public async Task<IActionResult> Index()
        {
              return View(await _context.PWPLabels.ToListAsync());
        }

        // GET: PWPLabels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PWPLabels == null)
            {
                return NotFound();
            }

            var pWPLabels = await _context.PWPLabels
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pWPLabels == null)
            {
                return NotFound();
            }

            return View(pWPLabels);
        }

        // GET: PWPLabels/Create
        public IActionResult Create()
        {
            ViewBag.ItemNumbers = new SelectList(_context.ItemNumber.ToList().OrderBy(m => m.Item), "Item", "Item");
            ViewBag.Associates = new SelectList(_context.Associates.ToList().OrderBy(m => m.FullName), "FullName", "FullName");
            return View();
        }


        // POST: PWPLabels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,ItemNumber,ProductionDate,CodePartA,CodePartB,CodePartC,Shift,PrintQty,MachineNumber,PrinterName")] PWPLabels pWPLabels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pWPLabels);
                await _context.SaveChangesAsync();
                return RedirectToAction("Juarez", "Home");
            }
            return View(pWPLabels);
        }

        // PWPLabels/Juarez_PWP
        public IActionResult Juarez_PWP()
        {
            ViewBag.ItemNumbers = new SelectList(_context.ItemNumber.ToList().OrderBy(m => m.Item), "Item", "Item");
            ViewBag.Associates = new SelectList(_context.Associates.ToList().OrderBy(m => m.FullName), "FullName", "FullName");
            return View();
        }

        // POST: PWPLabels/Juarez_PWP
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Juarez_PWP([Bind("ID,Name,ItemNumber,ProductionDate,CodePartA,CodePartB,CodePartC,Shift,PrintQty,MachineNumber,PrinterName")] PWPLabels pWPLabels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pWPLabels);
                await _context.SaveChangesAsync();
                return RedirectToAction("Juarez", "Home");
            }
            return View(pWPLabels);
        }


        // GET: PWPLabels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PWPLabels == null)
            {
                return NotFound();
            }

            var pWPLabels = await _context.PWPLabels.FindAsync(id);
            if (pWPLabels == null)
            {
                return NotFound();
            }
            return View(pWPLabels);
        }

        // POST: PWPLabels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,ItemNumber,ProductionDate,CodePartA,CodePartB,CodePartC,Shift,PrintQty,MachineNumber")] PWPLabels pWPLabels)
        {
            if (id != pWPLabels.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pWPLabels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PWPLabelsExists(pWPLabels.ID))
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
            return View(pWPLabels);
        }

        // GET: PWPLabels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PWPLabels == null)
            {
                return NotFound();
            }

            var pWPLabels = await _context.PWPLabels
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pWPLabels == null)
            {
                return NotFound();
            }

            return View(pWPLabels);
        }

        // POST: PWPLabels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PWPLabels == null)
            {
                return Problem("Entity set 'PWPLabelsContext.PWPLabels'  is null.");
            }
            var pWPLabels = await _context.PWPLabels.FindAsync(id);
            if (pWPLabels != null)
            {
                _context.PWPLabels.Remove(pWPLabels);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PWPLabelsExists(int id)
        {
          return _context.PWPLabels.Any(e => e.ID == id);
        }
    }
}
