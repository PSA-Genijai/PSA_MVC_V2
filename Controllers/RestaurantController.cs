using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PSA_MVC_V2.Models.Database;
using System.Dynamic;

namespace PSA_MVC_V2.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly PSADB _context;

        public RestaurantController(PSADB context)
        {
            _context = context;
        }

        // GET: Restaurant
        public async Task<IActionResult> Index()
        {
            var pSADB = _context.Dishes.Include(d => d.FkAdditionalServicesaddServices);
            return View(await pSADB.ToListAsync());
        }

        // GET: Restaurant
        public async Task<IActionResult> RestaurantDishOrderView()
        {
            var pSADB = _context.Dishes.Include(d => d.FkAdditionalServicesaddServices);
            ViewData["Dishes"] = pSADB;

            return View();
        }

        public async Task<IActionResult> RestaurantMenuView(string v)
        {
            var pSADB = _context.Dishes.Include(d => d.FkAdditionalServicesaddServices);
            var pSADBi = _context.Ingredients.Include(d => d.FkDishdish);
            ViewData["Dishes"] = pSADB;
            ViewData["Ingredients"] = pSADBi;


            return View(await pSADB.ToListAsync());
        }

        // GET: Restaurant/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Dishes == null)
            {
                return NotFound();
            }

            var dish = await _context.Dishes
                .Include(d => d.FkAdditionalServicesaddServices)
                .FirstOrDefaultAsync(m => m.DishId == id);
            if (dish == null)
            {
                return NotFound();
            }

            return View(dish);
        }

        // GET: Restaurant/Create
        public IActionResult Create()
        {
            ViewData["FkAdditionalServicesaddServicesId"] = new SelectList(_context.AdditionalServices, "AddServicesId", "AddServicesId");
            return View();
        }

        // POST: Restaurant/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DishId,DishTitle,DishPrice,FkAdditionalServicesaddServicesId")] Dish dish)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dish);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkAdditionalServicesaddServicesId"] = new SelectList(_context.AdditionalServices, "AddServicesId", "AddServicesId", dish.FkAdditionalServicesaddServicesId);
            return View(dish);
        }

        // GET: Restaurant/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Dishes == null)
            {
                return NotFound();
            }

            var dish = await _context.Dishes.FindAsync(id);
            if (dish == null)
            {
                return NotFound();
            }
            ViewData["FkAdditionalServicesaddServicesId"] = new SelectList(_context.AdditionalServices, "AddServicesId", "AddServicesId", dish.FkAdditionalServicesaddServicesId);
            return View(dish);
        }

        // POST: Restaurant/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DishId,DishTitle,DishPrice,FkAdditionalServicesaddServicesId")] Dish dish)
        {
            if (id != dish.DishId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dish);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DishExists(dish.DishId))
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
            ViewData["FkAdditionalServicesaddServicesId"] = new SelectList(_context.AdditionalServices, "AddServicesId", "AddServicesId", dish.FkAdditionalServicesaddServicesId);
            return View(dish);
        }

        // GET: Restaurant/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Dishes == null)
            {
                return NotFound();
            }

            var dish = await _context.Dishes
                .Include(d => d.FkAdditionalServicesaddServices)
                .FirstOrDefaultAsync(m => m.DishId == id);
            if (dish == null)
            {
                return NotFound();
            }

            return View(dish);
        }

        // POST: Restaurant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Dishes == null)
            {
                return Problem("Entity set 'PSADB.Dishes'  is null.");
            }
            var dish = await _context.Dishes.FindAsync(id);
            if (dish != null)
            {
                _context.Dishes.Remove(dish);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DishExists(int id)
        {
          return (_context.Dishes?.Any(e => e.DishId == id)).GetValueOrDefault();
        }
    }
}
