using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PSA_MVC_V2.Models.Database;

namespace PSA_MVC_V2.Controllers
{
    public class GuideController : Controller
    {
        private readonly PSADB _context;

        public GuideController(PSADB context)
        {
            _context = context;
        }

        // GET: Guide
        public async Task<IActionResult> Index()
        {
            var pSADB = await _context.Excursions.Include(e => e.FkAdditionalServicesaddServices).ToListAsync();
            return View(pSADB);//CheckProblems
        }

        // GET: CheckProblems
        public async Task<IActionResult> CheckProblems()
        {
            await Task.Delay(1000);
            TempData["ProblemResult"] = "No problems detected";
            return RedirectToAction(nameof(Index));
        }

        // GET: Guide/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Excursions == null)
            {
                return NotFound();
            }

            var excursion = await _context.Excursions
                .Include(e => e.FkAdditionalServicesaddServices)
                .FirstOrDefaultAsync(m => m.ExId == id);
            if (excursion == null)
            {
                return NotFound();
            }

            return View(excursion);
        }

        // GET: Guide/Create
        public IActionResult Create()
        {
            ViewData["FkAdditionalServicesaddServicesId"] = new SelectList(_context.AdditionalServices, "AddServicesId", "AddServicesId");
            return View();
        }

        // POST: Guide/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExTitle,ExPrice,ExDate,FkAdditionalServicesaddServicesId")] Excursion excursion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(excursion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkAdditionalServicesaddServicesId"] = new SelectList(_context.AdditionalServices, "AddServicesId", "AddServicesId", excursion.FkAdditionalServicesaddServicesId);
            return View(excursion);
        }

        // GET: Guide/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Excursions == null)
            {
                return NotFound();
            }

            var excursion = await _context.Excursions.FindAsync(id);
            if (excursion == null)
            {
                return NotFound();
            }
            ViewData["FkAdditionalServicesaddServicesId"] = new SelectList(_context.AdditionalServices, "AddServicesId", "AddServicesId", excursion.FkAdditionalServicesaddServicesId);
            return View(excursion);
        }

        // POST: Guide/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExId,ExTitle,ExPrice,ExDate,FkAdditionalServicesaddServicesId")] Excursion excursion)
        {
            if (id != excursion.ExId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(excursion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExcursionExists(excursion.ExId))
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
            ViewData["FkAdditionalServicesaddServicesId"] = new SelectList(_context.AdditionalServices, "AddServicesId", "AddServicesId", excursion.FkAdditionalServicesaddServicesId);
            return View(excursion);
        }

        // GET: Guide/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Excursions == null)
            {
                return NotFound();
            }

            var excursion = await _context.Excursions
                .Include(e => e.FkAdditionalServicesaddServices)
                .FirstOrDefaultAsync(m => m.ExId == id);
            if (excursion == null)
            {
                return NotFound();
            }

            return View(excursion);
        }

        // POST: Guide/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Excursions == null)
            {
                return Problem("Entity set 'PSADB.Excursions'  is null.");
            }
            var excursion = await _context.Excursions.FindAsync(id);
            if (excursion != null)
            {
                _context.Excursions.Remove(excursion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExcursionExists(int id)
        {
          return (_context.Excursions?.Any(e => e.ExId == id)).GetValueOrDefault();
        }
    }
}
