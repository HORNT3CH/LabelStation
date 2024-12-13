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
using cloudscribe.Pagination.Models;
using System.Data;

namespace LabelStation.Controllers
{
    public class ItemNumbersController : Controller
    {
        private readonly ItemContext _context;

        public ItemNumbersController(ItemContext context)
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

        // GET: Item Numbers Hudson
        public IActionResult Index(string SearchText = "", int pg = 1, int pageSize = 20)
        {
            List<ItemNumber> itemnumbers;

            if (pg < 1) pg = 1;


            if (SearchText != "" && SearchText != null)
            {
                itemnumbers = _context.ItemNumber
                .Where(p => p.Item.Contains(SearchText))
                .ToList();
            }
            else
                itemnumbers = _context.ItemNumber.ToList();

            int recsCount = itemnumbers.Count();

            int recSkip = (pg - 1) * pageSize;

            List<ItemNumber> retItemNumbers = itemnumbers.Skip(recSkip).Take(pageSize).ToList();

            Pager SearchPager = new Pager(recsCount, pg, pageSize) { Action = "Index", Controller = "ItemNumbers", SearchText = SearchText };
            ViewBag.SearchPager = SearchPager;

            this.ViewBag.PageSizes = GetPageSizes(pageSize);

            return View(retItemNumbers.ToList());

        }

        // GET: Item Numbers Index Juarez
        public IActionResult Index_Juarez(string SearchText = "", int pg = 1, int pageSize = 5)
        {
            List<ItemNumber> itemnumbers;

            if (pg < 1) pg = 1;


            if (SearchText != "" && SearchText != null)
            {
                itemnumbers = _context.ItemNumber
                .Where(p => p.Item.Contains(SearchText))
                .ToList();
            }
            else
                itemnumbers = _context.ItemNumber.ToList();

            int recsCount = itemnumbers.Count();

            int recSkip = (pg - 1) * pageSize;

            List<ItemNumber> retItemNumbers = itemnumbers.Skip(recSkip).Take(pageSize).ToList();

            Pager SearchPager = new Pager(recsCount, pg, pageSize) { Action = "Index_Juarez", Controller = "ItemNumbers", SearchText = SearchText };
            ViewBag.SearchPager = SearchPager;

            this.ViewBag.PageSizes = GetPageSizes(pageSize);

            return View(retItemNumbers.ToList());

        }

        // GET: ItemNumbers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ItemNumber == null)
            {
                return NotFound();
            }

            var itemNumber = await _context.ItemNumber
                .FirstOrDefaultAsync(m => m.ID == id);
            if (itemNumber == null)
            {
                return NotFound();
            }

            return View(itemNumber);
        }

        // GET: ItemNumbers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemNumbers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Item,ItemDesc,ItemType")] ItemNumber itemNumber)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemNumber);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itemNumber);
        }

        // GET: ItemNumbers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ItemNumber == null)
            {
                return NotFound();
            }

            var itemNumber = await _context.ItemNumber.FindAsync(id);
            if (itemNumber == null)
            {
                return NotFound();
            }
            return View(itemNumber);
        }

        // POST: ItemNumbers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Item,ItemDesc,ItemType")] ItemNumber itemNumber)
        {
            if (id != itemNumber.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemNumber);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemNumberExists(itemNumber.ID))
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
            return View(itemNumber);
        }

        // GET: ItemNumbers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ItemNumber == null)
            {
                return NotFound();
            }

            var itemNumber = await _context.ItemNumber
                .FirstOrDefaultAsync(m => m.ID == id);
            if (itemNumber == null)
            {
                return NotFound();
            }

            return View(itemNumber);
        }

        // POST: ItemNumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ItemNumber == null)
            {
                return Problem("Entity set 'ItemContext.ItemNumber'  is null.");
            }
            var itemNumber = await _context.ItemNumber.FindAsync(id);
            if (itemNumber != null)
            {
                _context.ItemNumber.Remove(itemNumber);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemNumberExists(int id)
        {
            return _context.ItemNumber.Any(e => e.ID == id);
        }

        
        // GET: ItemNumbers/Details/5 - Juarez
        public async Task<IActionResult> Details_Juarez(int? id)
        {
            if (id == null || _context.ItemNumber == null)
            {
                return NotFound();
            }

            var itemNumber = await _context.ItemNumber
                .FirstOrDefaultAsync(m => m.ID == id);
            if (itemNumber == null)
            {
                return NotFound();
            }

            return View(itemNumber);
        }

        // GET: ItemNumbers/Create - Juarez
        public IActionResult Create_Juarez()
        {
            return View();
        }

        // POST: ItemNumbers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create_Juarez([Bind("ID,Item,ItemDesc,ItemType")] ItemNumber itemNumber)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemNumber);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itemNumber);
        }

        // GET: ItemNumbers/Edit/5 - Juarez
        public async Task<IActionResult> Edit_Juarez(int? id)
        {
            if (id == null || _context.ItemNumber == null)
            {
                return NotFound();
            }

            var itemNumber = await _context.ItemNumber.FindAsync(id);
            if (itemNumber == null)
            {
                return NotFound();
            }
            return View(itemNumber);
        }

        // POST: ItemNumbers/Edit/5 - Juarez
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit_Juarez(int id, [Bind("ID,Item,ItemDesc,ItemType")] ItemNumber itemNumber)
        {
            if (id != itemNumber.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemNumber);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemNumberExists(itemNumber.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index_Juarez", "ItemNumbers");
            }
            return View(itemNumber);
        }

        // GET: ItemNumbers/Delete/5 - Juarez
        public async Task<IActionResult> Delete_Juarez(int? id)
        {
            if (id == null || _context.ItemNumber == null)
            {
                return NotFound();
            }

            var itemNumber = await _context.ItemNumber
                .FirstOrDefaultAsync(m => m.ID == id);
            if (itemNumber == null)
            {
                return NotFound();
            }

            return View(itemNumber);
        }

        [HttpPost, ActionName("Delete_Juarez")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed_Juarez(int id)
        {
            if (_context.ItemNumber == null)
            {
                return Problem("Entity set 'ItemContext.ItemNumber'  is null.");
            }
            var itemNumber = await _context.ItemNumber.FindAsync(id);
            if (itemNumber != null)
            {
                _context.ItemNumber.Remove(itemNumber);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index_Juarez", "ItemNumbers");
        }
    }
}
