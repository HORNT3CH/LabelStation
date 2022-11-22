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
    public class RailCarsController : Controller
    {
        private readonly RailCarContext _context;

        public RailCarsController(RailCarContext context)
        {
            _context = context;
        }

        // GET: RailCars
        public async Task<IActionResult> Index()
        {
              return View(await _context.RailCar.ToListAsync());
        }

        // GET: RailCars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RailCar == null)
            {
                return NotFound();
            }

            var railCar = await _context.RailCar
                .FirstOrDefaultAsync(m => m.ID == id);
            if (railCar == null)
            {
                return NotFound();
            }

            return View(railCar);
        }

        // GET: RailCars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RailCars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CarNumber,ItemNumber")] RailCar railCar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(railCar);
                await _context.SaveChangesAsync();
                return RedirectToAction("Hudson", "Home");
            }
            return View(railCar);
        }

        // GET: RailCars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RailCar == null)
            {
                return NotFound();
            }

            var railCar = await _context.RailCar.FindAsync(id);
            if (railCar == null)
            {
                return NotFound();
            }
            return View(railCar);
        }

        // POST: RailCars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CarNumber,ItemNumber")] RailCar railCar)
        {
            if (id != railCar.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(railCar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RailCarExists(railCar.ID))
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
            return View(railCar);
        }

        // GET: RailCars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RailCar == null)
            {
                return NotFound();
            }

            var railCar = await _context.RailCar
                .FirstOrDefaultAsync(m => m.ID == id);
            if (railCar == null)
            {
                return NotFound();
            }

            return View(railCar);
        }

        // POST: RailCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RailCar == null)
            {
                return Problem("Entity set 'RailCarContext.RailCar'  is null.");
            }
            var railCar = await _context.RailCar.FindAsync(id);
            if (railCar != null)
            {
                _context.RailCar.Remove(railCar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RailCarExists(int id)
        {
          return _context.RailCar.Any(e => e.ID == id);
        }
    }
}
