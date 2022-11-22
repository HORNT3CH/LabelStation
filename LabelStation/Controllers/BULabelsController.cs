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
    public class BULabelsController : Controller
    {
        private readonly BULabelsContext _context;

        public BULabelsController(BULabelsContext context)
        {
            _context = context;
        }

        // GET: BULabels

        public IActionResult Index(int pg = 1, string SearchText = "")
        {
            if (SearchText != "" && SearchText != null)
            {
                List<BULabel> names = _context.BULabel.Where(p => p.ItemNumber.Contains(SearchText)).ToList();

                const int pageSize = 10;
                if (pg < 1)
                {
                    pg = 1;
                }

                int recsCount = names.Count();

                var pager = new Pager(recsCount, pg, pageSize);

                int recSkip = (pg - 1) * pageSize;

                var data = names.Skip(recSkip).Take(pager.PageSize).ToList();

                this.ViewBag.Pager = pager;

                return View(data);
            }
            else
            {
                List<BULabel> items = _context.BULabel.ToList();

                const int pageSize = 10;
                if (pg < 1)
                {
                    pg = 1;
                }

                int recsCount = items.Count();

                var pager = new Pager(recsCount, pg, pageSize);

                int recSkip = (pg - 1) * pageSize;

                var data = items.Skip(recSkip).Take(pager.PageSize).ToList();

                this.ViewBag.Pager = pager;

                return View(data);
            }
        }

        // GET: BULabels/BackupReprint
        public async Task<IActionResult> BackupReprint(int? id)
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
        public async Task<IActionResult> BackupReprint(int id, [Bind("ID,ItemNumber,ItemDescription,Print,Standard,Quantity,LPNumber,IsReprint")] BULabel bULabel)
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
        public async Task<IActionResult> Create([Bind("ID,ItemNumber,ItemDescription,Print,Standard,Quantity")] BULabel bULabel)
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
        public async Task<IActionResult> Edit(int id, [Bind("ID,ItemNumber,ItemDescription,Print,Standard,Quantity")] BULabel bULabel)
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
                return Problem("Entity set 'BULabelsContext.BULabel'  is null.");
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
