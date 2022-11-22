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

        // GET: ItemNumbers 
        public IActionResult Index(int pg = 1, string SearchText = "")
        {
            if (SearchText != "" && SearchText != null)
            {
                List<ItemNumber> names = _context.ItemNumber.Where(p => p.Item.Contains(SearchText)).ToList();

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
                List<ItemNumber> items = _context.ItemNumber.ToList();

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

        // GET: ItemNumbers - Juarez Index
        public IActionResult Index_Juarez(int pg = 1, string SearchText = "")
        {
            if (SearchText != "" && SearchText != null)
            {
                List<ItemNumber> names = _context.ItemNumber.Where(p => p.Item.Contains(SearchText)).ToList();

                const int pageSize = 10;
                if (pg < 1)
                {
                    pg = 1;
                }

                int recsCount = names.Count();

                var juarezPager = new Pager(recsCount, pg, pageSize);

                int recSkip = (pg - 1) * pageSize;

                var juarezData = names.Skip(recSkip).Take(juarezPager.PageSize).ToList();

                this.ViewBag.Pager = juarezPager;

                return View(juarezData);
            }
            else
            {
                List<ItemNumber> items = _context.ItemNumber.ToList();

                const int pageSize = 10;
                if (pg < 1)
                {
                    pg = 1;
                }

                int recsCount = items.Count();

                var juarezPager = new Pager(recsCount, pg, pageSize);

                int recSkip = (pg - 1) * pageSize;

                var juarezData = items.Skip(recSkip).Take(juarezPager.PageSize).ToList();

                this.ViewBag.Pager = juarezPager;

                return View(juarezData);
            }
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
        public async Task<IActionResult> Create([Bind("ID,Item,ItemDesc")] ItemNumber itemNumber)
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
        public async Task<IActionResult> Edit(int id, [Bind("ID,Item,ItemDesc")] ItemNumber itemNumber)
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
        public async Task<IActionResult> Create_Juarez([Bind("ID,Item,ItemDesc")] ItemNumber itemNumber)
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
        public async Task<IActionResult> Edit_Juarez(int id, [Bind("ID,Item,ItemDesc")] ItemNumber itemNumber)
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
    }
}
