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
    public class KanbansController : Controller
    {
        private readonly KanbanContext _context;

        public KanbansController(KanbanContext context)
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

        // GET: Kanban
        public IActionResult Index(string SearchText = "", int pg = 1, int pageSize = 5)
        {
            List<Kanban> itemnumbers;

            if (pg < 1) pg = 1;


            if (SearchText != "" && SearchText != null)
            {
                itemnumbers = _context.Kanban
                .Where(p => p.ItemNumber.Contains(SearchText))
                .ToList();
            }
            else
                itemnumbers = _context.Kanban.ToList();

            int recsCount = itemnumbers.Count();

            int recSkip = (pg - 1) * pageSize;

            List<Kanban> retItemNumbers = itemnumbers.Skip(recSkip).Take(pageSize).ToList();

            Pager SearchPager = new Pager(recsCount, pg, pageSize) { Action = "Index", Controller = "Kanbans", SearchText = SearchText };
            ViewBag.SearchPager = SearchPager;

            this.ViewBag.PageSizes = GetPageSizes(pageSize);

            return View(retItemNumbers.ToList());

        }

        // GET: Kanbans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kanbans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Print,BOMID,ItemNumber,ItemDescription,PrintQty,FullName,MachineNumber,ReOrderQty,OrderQty,LineLimit,ParentSKU,ParentDescription,PrinterName")] Kanban kanban)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kanban);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kanban);
        }

        // GET: Kanbans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Kanban == null)
            {
                return NotFound();
            }

            var kanban = await _context.Kanban
                .FirstOrDefaultAsync(m => m.ID == id);
            if (kanban == null)
            {
                return NotFound();
            }

            return View(kanban);
        }        

        // GET: Kanbans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Kanban == null)
            {
                return NotFound();
            }

            var kanban = await _context.Kanban.FindAsync(id);
            if (kanban == null)
            {
                return NotFound();
            }
            return View(kanban);
        }

        // POST: Kanbans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Print,BOMID,ItemNumber,ItemDescription,PrintQty,FullName,MachineNumber,ReOrderQty,OrderQty,LineLimit,ParentSKU,ParentDescription,PrinterName")] Kanban kanban)
        {
            if (id != kanban.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kanban);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KanbanExists(kanban.ID))
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
            return View(kanban);
        }

        // GET: Kanbans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Kanban == null)
            {
                return NotFound();
            }

            var kanban = await _context.Kanban
                .FirstOrDefaultAsync(m => m.ID == id);
            if (kanban == null)
            {
                return NotFound();
            }

            return View(kanban);
        }

        // POST: Kanbans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Kanban == null)
            {
                return Problem("Entity set 'KanbanContext.Kanban'  is null.");
            }
            var kanban = await _context.Kanban.FindAsync(id);
            if (kanban != null)
            {
                _context.Kanban.Remove(kanban);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KanbanExists(int id)
        {
          return _context.Kanban.Any(e => e.ID == id);
        }

        // GET: Kanban Juarez
        public IActionResult Index_Juarez(string SearchText = "", int pg = 1, int pageSize = 5)
        {
            List<Kanban> itemnumbers;

            if (pg < 1) pg = 1;


            if (SearchText != "" && SearchText != null)
            {
                itemnumbers = _context.Kanban
                .Where(p => p.ItemNumber.Contains(SearchText))
                .ToList();
            }
            else
                itemnumbers = _context.Kanban.ToList();

            int recsCount = itemnumbers.Count();

            int recSkip = (pg - 1) * pageSize;

            List<Kanban> retItemNumbers = itemnumbers.Skip(recSkip).Take(pageSize).ToList();

            Pager SearchPager = new Pager(recsCount, pg, pageSize) { Action = "Index_Juarez", Controller = "Kanbans", SearchText = SearchText };
            ViewBag.SearchPager = SearchPager;

            this.ViewBag.PageSizes = GetPageSizes(pageSize);

            return View(retItemNumbers.ToList());

        }

        // GET: Kanbans/Create/Juarez
        public IActionResult Create_Juarez()
        {
            return View();
        }

        // POST: Kanbans/Create/Juarez
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create_Juarez([Bind("ID,Print,BOMID,ItemNumber,ItemDescription,PrintQty,FullName,MachineNumber,ReOrderQty,OrderQty,LineLimit,ParentSKU,ParentDescription,PrinterName")] Kanban kanban)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kanban);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kanban);
        }

        // GET: Kanbans/Edit/5 Juarez
        public async Task<IActionResult> Edit_Juarez(int? id)
        {
            if (id == null || _context.Kanban == null)
            {
                return NotFound();
            }

            var kanban = await _context.Kanban.FindAsync(id);
            if (kanban == null)
            {
                return NotFound();
            }
            return View(kanban);
        }

        // POST: Kanbans/Edit/5 Juarez
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit_Juarez(int id, [Bind("ID,Print,BOMID,ItemNumber,ItemDescription,PrintQty,FullName,MachineNumber,ReOrderQty,OrderQty,LineLimit,ParentSKU,ParentDescription,PrinterName")] Kanban kanban)
        {
            if (id != kanban.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kanban);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KanbanExists(kanban.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index_Juarez", "Kanbans");
            }
            return View(kanban);
        }

        // POST: Kanbans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed_Juarez(int id)
        {
            if (_context.Kanban == null)
            {
                return Problem("Entity set 'KanbanContext.Kanban'  is null.");
            }
            var kanban = await _context.Kanban.FindAsync(id);
            if (kanban != null)
            {
                _context.Kanban.Remove(kanban);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index_Juarez", "Kanbans");
        }
    }
}
