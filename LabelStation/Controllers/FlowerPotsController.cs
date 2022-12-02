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
    public class FlowerPotsController : Controller
    {
        private readonly FlowerPotsContext _context;

        public FlowerPotsController(FlowerPotsContext context)
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
        public IActionResult Index(string SearchText = "", int pg = 1, int pageSize = 5)
        {
            List<FlowerPots> flowerpots;

            if (pg < 1) pg = 1;


            if (SearchText != "" && SearchText != null)
            {
                flowerpots = _context.FlowerPots
                .Where(p => p.PotNumber.Contains(SearchText))
                .ToList();
            }
            else
                flowerpots = _context.FlowerPots.ToList();

            int recsCount = flowerpots.Count();

            int recSkip = (pg - 1) * pageSize;

            List<FlowerPots> retFlowerPots = flowerpots.Skip(recSkip).Take(pageSize).ToList();

            Pager SearchPager = new Pager(recsCount, pg, pageSize) { Action = "Index", Controller = "FlowerPots", SearchText = SearchText };
            ViewBag.SearchPager = SearchPager;

            this.ViewBag.PageSizes = GetPageSizes(pageSize);

            return View(retFlowerPots.ToList());

        }

        // GET: FlowerPots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FlowerPots == null)
            {
                return NotFound();
            }

            var flowerPots = await _context.FlowerPots
                .FirstOrDefaultAsync(m => m.ID == id);
            if (flowerPots == null)
            {
                return NotFound();
            }

            return View(flowerPots);
        }

        // GET: FlowerPots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FlowerPots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PotNumber,PotDescription,ParentPartPacking,PartNumber,UPC,Quantity,Label,Print,PrintQuantity")] FlowerPots flowerPots)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flowerPots);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flowerPots);
        }

        // GET: FlowerPots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FlowerPots == null)
            {
                return NotFound();
            }

            var flowerPots = await _context.FlowerPots.FindAsync(id);
            if (flowerPots == null)
            {
                return NotFound();
            }
            return View(flowerPots);
        }

        // POST: FlowerPots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PotNumber,PotDescription,ParentPartPacking,PartNumber,UPC,Quantity,Label,Print,PrintQuantity")] FlowerPots flowerPots)
        {
            if (id != flowerPots.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flowerPots);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlowerPotsExists(flowerPots.ID))
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
            return View(flowerPots);
        }

        // GET: FlowerPots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FlowerPots == null)
            {
                return NotFound();
            }

            var flowerPots = await _context.FlowerPots
                .FirstOrDefaultAsync(m => m.ID == id);
            if (flowerPots == null)
            {
                return NotFound();
            }

            return View(flowerPots);
        }

        // POST: FlowerPots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FlowerPots == null)
            {
                return Problem("Entity set 'FlowerPotsContext.FlowerPots'  is null.");
            }
            var flowerPots = await _context.FlowerPots.FindAsync(id);
            if (flowerPots != null)
            {
                _context.FlowerPots.Remove(flowerPots);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlowerPotsExists(int id)
        {
          return _context.FlowerPots.Any(e => e.ID == id);
        }
    }
}
