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
    public class OrderController : Controller
    {
        private readonly PSADB _context;

        public OrderController(PSADB context)
        {
            _context = context;
        }

        // GET: Order
        public async Task<IActionResult> Index()
        {
            var pSADB = _context.AdditionalServices.Include(a => a.FkReservationreservation);
            return View(await pSADB.ToListAsync());
        }

        // GET: Order/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AdditionalServices == null)
            {
                return NotFound();
            }

            var additionalService = await _context.AdditionalServices
                .Include(a => a.FkReservationreservation)
                .FirstOrDefaultAsync(m => m.AddServicesId == id);
            if (additionalService == null)
            {
                return NotFound();
            }

            return View(additionalService);
        }

        // GET: Order/Create
        public IActionResult Create()
        {
            ViewData["FkReservationreservationId"] = new SelectList(_context.Reservations, "ReservationId", "ReservationId");
            return View();
        }

        // POST: Order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AddServicesId,AddServicesPrice,FkReservationreservationId")] AdditionalService additionalService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(additionalService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkReservationreservationId"] = new SelectList(_context.Reservations, "ReservationId", "ReservationId", additionalService.FkReservationreservationId);
            return View(additionalService);
        }

        //// GET: Order/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.AdditionalServices == null)
        //    {
        //        return NotFound();
        //    }

        //    var additionalService = await _context.AdditionalServices.FindAsync(id);
        //    if (additionalService == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["FkReservationreservationId"] = new SelectList(_context.Reservations, "ReservationId", "ReservationId", additionalService.FkReservationreservationId);
        //    return View(additionalService);
        //}

        // POST: Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("AddServicesId,AddServicesPrice,FkReservationreservationId")] AdditionalService additionalService)
        //{
        //    if (id != additionalService.AddServicesId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(additionalService);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!AdditionalServiceExists(additionalService.AddServicesId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["FkReservationreservationId"] = new SelectList(_context.Reservations, "ReservationId", "ReservationId", additionalService.FkReservationreservationId);
        //    return View(additionalService);
        //}

        //// GET: Order/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.AdditionalServices == null)
        //    {
        //        return NotFound();
        //    }

        //    var additionalService = await _context.AdditionalServices
        //        .Include(a => a.FkReservationreservation)
        //        .FirstOrDefaultAsync(m => m.AddServicesId == id);
        //    if (additionalService == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(additionalService);
        //}

        // POST: Order/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.AdditionalServices == null)
        //    {
        //        return Problem("Entity set 'PSADB.AdditionalServices'  is null.");
        //    }
        //    var additionalService = await _context.AdditionalServices.FindAsync(id);
        //    if (additionalService != null)
        //    {
        //        _context.AdditionalServices.Remove(additionalService);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool AdditionalServiceExists(int id)
        //{
        //  return (_context.AdditionalServices?.Any(e => e.AddServicesId == id)).GetValueOrDefault();
        //}
    }
}
