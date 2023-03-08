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
    public class SkuCardsController : Controller
    {
        private readonly SkuCardsContext _context;

        public SkuCardsController(SkuCardsContext context)
        {
            _context = context;
        }

        // GET: SkuCards
        public async Task<IActionResult> Index()
        {
              return View(await _context.SkuCard.ToListAsync());
        }

        // GET: SkuCards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SkuCard == null)
            {
                return NotFound();
            }

            var skuCard = await _context.SkuCard
                .FirstOrDefaultAsync(m => m.SkuCardId == id);
            if (skuCard == null)
            {
                return NotFound();
            }

            return View(skuCard);
        }

        // GET: SkuCards/Create
        public IActionResult Create()
        {
            ViewBag.ItemNumbers = new SelectList(_context.ItemNumber.ToList().Where(m => m.ItemType == "FG").OrderBy(m => m.Item), "Item", "Item");
            ViewBag.ItemDescriptions = new SelectList(_context.ItemNumber.ToList().Where(m => m.ItemType == "FG").OrderBy(m => m.ItemDesc), "ItemDesc", "ItemDesc");
            return View();
        }

        // POST: SkuCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SkuCardId,ItemNumber,PrinterName,ItemDescription")] SkuCard skuCard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skuCard);
                await _context.SaveChangesAsync();
                return RedirectToAction("Hudson", "Home");
            }
            return View(skuCard);
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

        // GET: SkuCards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SkuCard == null)
            {
                return NotFound();
            }

            var skuCard = await _context.SkuCard.FindAsync(id);
            if (skuCard == null)
            {
                return NotFound();
            }
            return View(skuCard);
        }

        // POST: SkuCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SkuCardId,ItemNumber,PrinterName,ItemDescription")] SkuCard skuCard)
        {
            if (id != skuCard.SkuCardId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skuCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkuCardExists(skuCard.SkuCardId))
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
            return View(skuCard);
        }

        // GET: SkuCards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SkuCard == null)
            {
                return NotFound();
            }

            var skuCard = await _context.SkuCard
                .FirstOrDefaultAsync(m => m.SkuCardId == id);
            if (skuCard == null)
            {
                return NotFound();
            }

            return View(skuCard);
        }

        // POST: SkuCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SkuCard == null)
            {
                return Problem("Entity set 'SkuCardsContext.SkuCard'  is null.");
            }
            var skuCard = await _context.SkuCard.FindAsync(id);
            if (skuCard != null)
            {
                _context.SkuCard.Remove(skuCard);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkuCardExists(int id)
        {
          return _context.SkuCard.Any(e => e.SkuCardId == id);
        }
    }
}
