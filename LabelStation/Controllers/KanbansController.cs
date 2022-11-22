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

        // GET: Kanbans
        
        public IActionResult Index(int pg = 1, string SearchText = "")
        {
            if (SearchText != "" && SearchText != null)
            {
                List<Kanban> names = _context.Kanban.Where(p => p.ItemNumber.Contains(SearchText)).ToList();

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
                List<Kanban> names = _context.Kanban.ToList();

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
        public async Task<IActionResult> Create([Bind("ID,Print,BOMID,ItemNumber,ItemDescription,PrintQty,FullName,MachineNumber,ReOrderQty,OrderQty,LineLimit,ParentSKU,ParentDescription")] Kanban kanban)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kanban);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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
        public async Task<IActionResult> Edit(int id, [Bind("ID,Print,BOMID,ItemNumber,ItemDescription,PrintQty,FullName,MachineNumber,ReOrderQty,OrderQty,LineLimit,ParentSKU,ParentDescription")] Kanban kanban)
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
    }
}
