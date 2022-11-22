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

        // GET: Associates
        public IActionResult Index(int pg = 1, string SearchText = "")
        {
            if (SearchText != "" && SearchText != null)
            {
                List<Associates> names = _context.Associates.Where(p => p.FullName.Contains(SearchText)).ToList();

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
                List<Associates> names = _context.Associates.ToList();

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

        // Juarez Create
        public IActionResult Index_Juarez(int pg = 1, string SearchText1 = "")
        {
            if (SearchText1 != "" && SearchText1 != null)
            {
                List<Associates> names1 = _context.Associates.Where(p => p.FullName.Contains(SearchText1)).ToList();

                const int pageSize = 10;
                if (pg < 1)
                {
                    pg = 1;
                }

                int recsCount = names1.Count();

                var pager1 = new Pager(recsCount, pg, pageSize);

                int recSkip = (pg - 1) * pageSize;

                var data = names1.Skip(recSkip).Take(pager1.PageSize).ToList();

                this.ViewBag.Pager = pager1;

                return View(data);
            }
            else
            {
                List<Associates> names1 = _context.Associates.ToList();

                const int pageSize = 10;
                if (pg < 1)
                {
                    pg = 1;
                }

                int recsCount = names1.Count();

                var pager1 = new Pager(recsCount, pg, pageSize);

                int recSkip = (pg - 1) * pageSize;

                var data = names1.Skip(recSkip).Take(pager1.PageSize).ToList();

                this.ViewBag.Pager = pager1;

                return View(data);
            }
        }

        // GET: Associates/Details/5
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

        // POST: Associates/Create
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

        // POST: Associates/Edit/5
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
                return RedirectToAction(nameof(Index));
            }
            return View(associates);
        }

        // GET: Associates/Delete/5
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
    }
}
