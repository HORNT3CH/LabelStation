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
    public class ScanLabelsController : Controller
    {
        private readonly ScanLabelsContext _context;

        public ScanLabelsController(ScanLabelsContext context)
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

        // GET: ScanLabels
        public IActionResult Index(string SearchText = "", int pg = 1, int pageSize = 5)
        {
            List<ScanLabel> scanLabels;

            if (pg < 1) pg = 1;


            if (SearchText != "" && SearchText != null)
            {
                scanLabels = _context.ScanLabel
                .Where(p => p.ItemNumber.Contains(SearchText))
                .ToList();
            }
            else
                scanLabels = _context.ScanLabel.ToList();

            int recsCount = scanLabels.Count();

            int recSkip = (pg - 1) * pageSize;

            List<ScanLabel> retScanLabels = scanLabels.Skip(recSkip).Take(pageSize).ToList();

            Pager SearchPager = new Pager(recsCount, pg, pageSize) { Action = "Index", Controller = "ScanLabels", SearchText = SearchText };
            ViewBag.SearchPager = SearchPager;

            this.ViewBag.PageSizes = GetPageSizes(pageSize);

            return View(retScanLabels.ToList());

        }

        // GET: SkuCards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ScanLabel == null)
            {
                return NotFound();
            }

            var scanLabel = await _context.ScanLabel
                .FirstOrDefaultAsync(m => m.ScanLabelId == id);
            if (scanLabel == null)
            {
                return NotFound();
            }

            return View(scanLabel);
        }

        // GET: ScanLabels/Create
        public IActionResult Create()
        {
            ViewBag.ItemNumbers = new SelectList(_context.ItemNumber.ToList().Where(m => m.ItemType == "FG").OrderBy(m => m.Item), "Item", "Item");
            ViewBag.ItemDescriptions = new SelectList(_context.ItemNumber.ToList().Where(m => m.ItemType == "FG").OrderBy(m => m.ItemDesc), "ItemDesc", "ItemDesc");
            return View();
        }

        // POST: ScanLabels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ScanLabelId,ItemNumber,ItemDescription,PrintLabel,ImageLocation")] ScanLabel scanLabel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scanLabel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(scanLabel);
        }        

        // POST: AJAX call to database to get matching description of Item
        public JsonResult GetOptions(string option1Value)
        {
            var options2 = _context.ItemNumber.Where(p => p.Item == option1Value).ToList();
            var options2List = new List<SelectListItem>();

            foreach (var option in options2)
            {
                options2List.Add(new SelectListItem { Value = option.ItemDesc, Text = option.ItemDesc });
            }

            return Json(options2List);
        }

        // Get EditList for Scan Labels Print Multiple at a time
        public IActionResult EditList(string SearchText = "", int pg = 1, int pageSize = 5)
        {
            List<ScanLabel> scanLabel;

            if (pg < 1) pg = 1;


            if (SearchText != "" && SearchText != null)
            {
                scanLabel = _context.ScanLabel
                .Where(p => p.ItemNumber.Contains(SearchText))
                .ToList();
            }
            else
                scanLabel = _context.ScanLabel.ToList();

            int recsCount = scanLabel.Count();

            int recSkip = (pg - 1) * pageSize;

            List<ScanLabel> retScanLabel = scanLabel.Skip(recSkip).Take(pageSize).ToList();

            Pager SearchPager = new Pager(recsCount, pg, pageSize) { Action = "EditList", Controller = "ScanLabels", SearchText = SearchText };
            ViewBag.SearchPager = SearchPager;

            this.ViewBag.PageSizes = GetPageSizes(pageSize);

            return View(retScanLabel.ToList());

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditListPost(int ScanLabelId, List<ScanLabel> scanLabel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    foreach (ScanLabel scan in scanLabel)
                    {
                        _context.Update(scan);
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
            }

            return RedirectToAction("Hudson", "Home");
        }

        // GET: ScanLabels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ScanLabel == null)
            {
                return NotFound();
            }

            var scanLabel = await _context.ScanLabel.FindAsync(id);
            if (scanLabel == null)
            {
                return NotFound();
            }
            return View(scanLabel);
        }

        // POST: ScanLabels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ScanLabelId,ItemNumber,ItemDescription,PrintLabel,ImageLocation")] ScanLabel scanLabel)
        {
            if (id != scanLabel.ScanLabelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scanLabel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScanLabelExists(scanLabel.ScanLabelId))
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
            return View(scanLabel);
        }

        // GET: ScanLabels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ScanLabel == null)
            {
                return NotFound();
            }

            var scanLabel = await _context.ScanLabel
                .FirstOrDefaultAsync(m => m.ScanLabelId == id);
            if (scanLabel == null)
            {
                return NotFound();
            }

            return View(scanLabel);
        }

        // POST: ScanLabels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ScanLabel == null)
            {
                return Problem("Entity set 'ScanLabelsContext.ScanLabel'  is null.");
            }
            var scanLabel = await _context.ScanLabel.FindAsync(id);
            if (scanLabel != null)
            {
                _context.ScanLabel.Remove(scanLabel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScanLabelExists(int id)
        {
          return _context.ScanLabel.Any(e => e.ScanLabelId == id);
        }
    }
}
