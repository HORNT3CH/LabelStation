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
        //private IEnumerable<Kanban> kanbans;

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
        public IActionResult Index(string SearchText = "", int pg = 1, int pageSize = 20)
        {
            List<Kanban> itemnumbers;

            if (pg < 1) pg = 1;


            if (SearchText != "" && SearchText != null)
            {
                itemnumbers = _context.Kanban
                .Where(p => p.ParentSKU.Equals(SearchText))
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
        public async Task<IActionResult> Create([Bind("ID,BOMID,ParentSKU,ItemNumber,Print,FullName,MachineNumber,ReOrderQty,OrderQty,LineLimit,ItemDescription,PrintQty,ParentDescription,PrinterName")] Kanban kanban)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kanban);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kanban);
        }

        // Get EditList for Kanban Print Multiple at a time
        public IActionResult EditList(string SearchText = "", int pg = 1, int pageSize = 20)
        {
            List<Kanban> kanbans;

            if (pg < 1) pg = 1;


            if (SearchText != "" && SearchText != null)
            {
                kanbans = _context.Kanban
                .Where(p => p.ParentSKU.Equals(SearchText))
                .ToList();
            }
            else
                kanbans = _context.Kanban.ToList();

            int recsCount = kanbans.Count();

            int recSkip = (pg - 1) * pageSize;

            List<Kanban> retItemNumbers = kanbans.Skip(recSkip).Take(pageSize).ToList();

            Pager SearchPager = new Pager(recsCount, pg, pageSize) { Action = "EditList", Controller = "Kanbans", SearchText = SearchText };
            ViewBag.SearchPager = SearchPager;

            this.ViewBag.PageSizes = GetPageSizes(pageSize);

            return View(retItemNumbers.ToList());

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditListPost(int ID, List<Kanban> kanbans)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    foreach (Kanban kan in kanbans)
                    {
                        _context.Update(kan);
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
            }

            return RedirectToAction(nameof(EditList));
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
        public async Task<IActionResult> Edit(int id, [Bind("ID,BOMID,ParentSKU,ItemNumber,Print,FullName,MachineNumber,ReOrderQty,OrderQty,LineLimit,ItemDescription,PrintQty,ParentDescription,PrinterName")] Kanban kanban)
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

        // GET: Kanbans/ChangeMachine/5
        public async Task<IActionResult> ChangeMachine(int? id)
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

            // Get list of distinct ParentSKUs
            ViewBag.parent = new SelectList(_context.Kanban.Select(p => p.ParentSKU).Distinct().ToList(), kanban.ParentSKU);

            // Get list of BOMIDs associated with the selected ParentSKU
            ViewBag.bom = new SelectList(_context.Kanban.Where(p => p.ParentSKU == kanban.ParentSKU).Select(p => p.BOMID).Distinct().ToList(), kanban.BOMID);

            // Get list of machines from the Machines table            
            ViewBag.Machine = new SelectList(_context.Machines.ToList().OrderBy(m => m.MachineDepartment), "MachineNumber", "MachineNumber");

            return View(kanban);
        }

        // POST: Kanbans/ChangeMachine/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeMachine(int id, [Bind("ID,BOMID,ParentSKU,ParentDescription,MachineNumber,FullName,Print")] Kanban kanban)
        {
            if (id != kanban.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Retrieve all Kanban entries that have the same ParentSKU and BOMID as the current entry
                    var kanbansToUpdate = _context.Kanban
                        .Where(p => p.ParentSKU == kanban.ParentSKU && p.BOMID == kanban.BOMID)
                        .ToList();

                    // Update properties for each matching record
                    foreach (var item in kanbansToUpdate)
                    {
                        item.Print = kanban.Print;
                        item.FullName = kanban.FullName;
                        item.MachineNumber = kanban.MachineNumber;                        
                    }

                    // Save changes to all records
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

            // Re-populate ViewBags in case of validation errors
            ViewBag.parent = new SelectList(_context.Kanban.Select(p => p.ParentSKU).Distinct().ToList(), kanban.ParentSKU);
            ViewBag.bom = new SelectList(_context.Kanban.Where(p => p.ParentSKU == kanban.ParentSKU).Select(p => p.BOMID).Distinct().ToList(), kanban.BOMID);

            return View(kanban);
        }


        public JsonResult GetBomByParentSKU(string parentSKU)
        {
            var bomItems = _context.Kanban
                .Where(p => p.ParentSKU == parentSKU)
                .Select(p => new { Value = p.BOMID, Text = p.BOMID })
                .Distinct()
                .ToList();

            return Json(bomItems);
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
                .Where(p => p.ParentSKU.Contains(SearchText))
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
            return RedirectToAction(nameof(EditList));
        }

        // POST: Kanbans/Edit/5 Juarez
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit_Juarez(int id, [Bind("ID,BOMID,ParentSKU,ItemNumber,Print,FullName,MachineNumber,ReOrderQty,OrderQty,LineLimit,ItemDescription,PrintQty,ParentDescription,PrinterName")] Kanban kanban)
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
        
    }
}
