#nullable disable
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

        private List<SelectListItem> GetPageSizes(int selectedPageSize = 5)
        {
            var pagesSizes = new List<SelectListItem>();

            if (selectedPageSize == 5)
                pagesSizes.Add(new SelectListItem("5", "5", true));
            else
                pagesSizes.Add(new SelectListItem("5", "5"));

            for (int lp = 10; lp <= 100; lp += 10)
            {
                if (lp == selectedPageSize)
                { pagesSizes.Add(new SelectListItem(lp.ToString(), lp.ToString(), true)); }
                else
                    pagesSizes.Add(new SelectListItem(lp.ToString(), lp.ToString()));
            }

            return pagesSizes;
        }

        // GET: BULabels
        public IActionResult Index(string SearchText = "", int pg = 1, int pageSize = 5)
        {
            List<BULabel> backupLabels;

            if (pg < 1) pg = 1;


            if (SearchText != "" && SearchText != null)
            {
                backupLabels = _context.BULabel
                .Where(p => p.ItemNumber.Contains(SearchText))
                .ToList();
            }
            else
                backupLabels = _context.BULabel.ToList();

            int recsCount = backupLabels.Count();

            int recSkip = (pg - 1) * pageSize;

            List<BULabel> retBackup = backupLabels.Skip(recSkip).Take(pageSize).ToList();

            Pager SearchPager = new Pager(recsCount, pg, pageSize) { Action = "Index", Controller = "BULabels", SearchText = SearchText };
            ViewBag.SearchPager = SearchPager;

            this.ViewBag.PageSizes = GetPageSizes(pageSize);

            return View(retBackup.ToList());

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
