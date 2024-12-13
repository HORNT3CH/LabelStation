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
    public class HorticulturalContainersController : Controller
    {
        private readonly HorticulturalContainersContext _context;

        public HorticulturalContainersController(HorticulturalContainersContext context)
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

        // GET: FlowerPots
        public IActionResult Index(string SearchText = "", int pg = 1, int pageSize = 20)
        {
            List<HorticulturalContainers> horticulturalcontainers;

            if (pg < 1) pg = 1;


            if (SearchText != "" && SearchText != null)
            {
                horticulturalcontainers = _context.HorticulturalContainers
                .Where(p => p.LTPartNumber.Contains(SearchText))
                .ToList();
            }
            else
                horticulturalcontainers = _context.HorticulturalContainers.ToList();

            int recsCount = horticulturalcontainers.Count();

            int recSkip = (pg - 1) * pageSize;

            List<HorticulturalContainers> retHortContainers = horticulturalcontainers.Skip(recSkip).Take(pageSize).ToList();

            Pager SearchPager = new Pager(recsCount, pg, pageSize) { Action = "Index", Controller = "HorticulturalContainers", SearchText = SearchText };
            ViewBag.SearchPager = SearchPager;

            this.ViewBag.PageSizes = GetPageSizes(pageSize);

            return View(retHortContainers.ToList());

        }

        // GET: HorticulturalContainers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HorticulturalContainers == null)
            {
                return NotFound();
            }

            var horticulturalContainers = await _context.HorticulturalContainers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (horticulturalContainers == null)
            {
                return NotFound();
            }

            return View(horticulturalContainers);
        }

        // GET: HorticulturalContainers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HorticulturalContainers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LTPartNumber,CustomerPartNumber,Description,Barcode,PackAmount,Quantity,Print")] HorticulturalContainers horticulturalContainers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(horticulturalContainers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(horticulturalContainers);
        }

        // GET: HorticulturalContainers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HorticulturalContainers == null)
            {
                return NotFound();
            }

            var horticulturalContainers = await _context.HorticulturalContainers.FindAsync(id);
            if (horticulturalContainers == null)
            {
                return NotFound();
            }
            return View(horticulturalContainers);
        }

        // POST: HorticulturalContainers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LTPartNumber,CustomerPartNumber,Description,Barcode,PackAmount,Quantity,Print")] HorticulturalContainers horticulturalContainers)
        {
            if (id != horticulturalContainers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horticulturalContainers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HorticulturalContainersExists(horticulturalContainers.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Hudson", "Home");
            }
            return View(horticulturalContainers);
        }

        // GET: HorticulturalContainers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HorticulturalContainers == null)
            {
                return NotFound();
            }

            var horticulturalContainers = await _context.HorticulturalContainers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (horticulturalContainers == null)
            {
                return NotFound();
            }

            return View(horticulturalContainers);
        }

        // POST: HorticulturalContainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HorticulturalContainers == null)
            {
                return Problem("Entity set 'HorticulturalContainersContext.HorticulturalContainers'  is null.");
            }
            var horticulturalContainers = await _context.HorticulturalContainers.FindAsync(id);
            if (horticulturalContainers != null)
            {
                _context.HorticulturalContainers.Remove(horticulturalContainers);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HorticulturalContainersExists(int id)
        {
          return (_context.HorticulturalContainers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
