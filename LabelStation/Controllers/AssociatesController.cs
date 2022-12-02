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
    public class AssociatesController : Controller
    {
        private readonly AssociatesContext _context;

        public AssociatesController(AssociatesContext context)
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

        // GET: Associates
        public IActionResult Index(string SearchText = "", int pg = 1, int pageSize = 5)
        {
            List<Associates> associates;

            if (pg < 1) pg = 1;


            if (SearchText != "" && SearchText != null)
            {
                associates = _context.Associates
                .Where(p => p.FullName.Contains(SearchText))
                .ToList();
            }
            else
                associates = _context.Associates.ToList();

            int recsCount = associates.Count();

            int recSkip = (pg - 1) * pageSize;

            List<Associates> retAssociates = associates.Skip(recSkip).Take(pageSize).OrderBy(m => m.FullName).ToList();

            Pager SearchPager = new Pager(recsCount, pg, pageSize) { Action = "Index", Controller = "Associates", SearchText = SearchText };
            ViewBag.SearchPager = SearchPager;

            this.ViewBag.PageSizes = GetPageSizes(pageSize);

            return View(retAssociates.ToList());

        }

        // GET: Associates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Associates == null)
            {
                return NotFound();
            }

            var associates = await _context.Associates
                .FirstOrDefaultAsync(m => m.ID == id);
            if (associates == null)
            {
                return NotFound();
            }

            return View(associates);
        }

        // GET: Associates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Associates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FullName")] Associates associates)
        {
            if (ModelState.IsValid)
            {
                _context.Add(associates);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(associates);
        }

        // GET: Associates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Associates == null)
            {
                return NotFound();
            }

            var associates = await _context.Associates.FindAsync(id);
            if (associates == null)
            {
                return NotFound();
            }
            return View(associates);
        }

        // POST: Associates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FullName")] Associates associates)
        {
            if (id != associates.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(associates);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssociatesExists(associates.ID))
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
            return View(associates);
        }

        // GET: Associates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Associates == null)
            {
                return NotFound();
            }

            var associates = await _context.Associates
                .FirstOrDefaultAsync(m => m.ID == id);
            if (associates == null)
            {
                return NotFound();
            }

            return View(associates);
        }

        // POST: Associates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Associates == null)
            {
                return Problem("Entity set 'AssociatesContext.Associates'  is null.");
            }
            var associates = await _context.Associates.FindAsync(id);
            if (associates != null)
            {
                _context.Associates.Remove(associates);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssociatesExists(int id)
        {
          return _context.Associates.Any(e => e.ID == id);
        }

        // GET: Associates Index Juarez
        public IActionResult Index_Juarez(string SearchText = "", int pg = 1, int pageSize = 5)
        {
            List<Associates> associates;

            if (pg < 1) pg = 1;


            if (SearchText != "" && SearchText != null)
            {
                associates = _context.Associates
                .Where(p => p.FullName.Contains(SearchText))                
                .ToList();
            }
            else
                associates = _context.Associates.ToList();

            int recsCount = associates.Count();

            int recSkip = (pg - 1) * pageSize;

            List<Associates> retAssociates = associates.Skip(recSkip).Take(pageSize).OrderBy(m => m.FullName).ToList();

            Pager SearchPager = new Pager(recsCount, pg, pageSize) { Action = "Index_Juarez", Controller = "Associates", SearchText = SearchText };
            ViewBag.SearchPager = SearchPager;

            this.ViewBag.PageSizes = GetPageSizes(pageSize);

            return View(retAssociates.ToList());

        }

        // GET: Associates/Details/5 Juarez
        public async Task<IActionResult> Details_Juarez(int? id)
        {
            if (id == null || _context.Associates == null)
            {
                return NotFound();
            }

            var associates = await _context.Associates
                .FirstOrDefaultAsync(m => m.ID == id);
            if (associates == null)
            {
                return NotFound();
            }

            return View(associates);
        }

        // GET: Associates/Create
        public IActionResult Create_Juarez()
        {
            return View();
        }

        // POST: Associates/Create Juarez
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create_Juarez([Bind("ID,FullName")] Associates associates)
        {
            if (ModelState.IsValid)
            {
                _context.Add(associates);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(associates);
        }

        // GET: Associates/Edit/5
        public async Task<IActionResult> Edit_Juarez(int? id)
        {
            if (id == null || _context.Associates == null)
            {
                return NotFound();
            }

            var associates = await _context.Associates.FindAsync(id);
            if (associates == null)
            {
                return NotFound();
            }
            return View(associates);
        }

        // POST: Associates/Edit/5 Juarez
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit_Juarez(int id, [Bind("ID,FullName")] Associates associates)
        {
            if (id != associates.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(associates);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssociatesExists(associates.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index_Juarez", "Associates");
            }
            return View(associates);
        }

        // GET: Associates/Delete/5 Juarez
        public async Task<IActionResult> Delete_Juarez(int? id)
        {
            if (id == null || _context.Associates == null)
            {
                return NotFound();
            }

            var associates = await _context.Associates
                .FirstOrDefaultAsync(m => m.ID == id);
            if (associates == null)
            {
                return NotFound();
            }

            return View(associates);
        }

        // POST: Associates/Delete/5
        [HttpPost, ActionName("Delete_Juarez")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed_Juarez(int id)
        {
            if (_context.Associates == null)
            {
                return Problem("Entity set 'AssociatesContext.Associates'  is null.");
            }
            var associates = await _context.Associates.FindAsync(id);
            if (associates != null)
            {
                _context.Associates.Remove(associates);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index_Juarez", "Associates");
        }
    }
}
