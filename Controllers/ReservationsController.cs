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
    public class ReservationsController : Controller
    {
        private readonly PSADB _context;

        public ReservationsController(PSADB context)
        {
            _context = context;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {
            var pSADB = await _context.Reservations.Include(r => r.FkBillbill).Include(r => r.FkGuestg).Include(r => r.FkReservationStatusresStatus).Include(r => r.FkRoomidRoomNavigation).Include(r => r.FkWorkerw).ToListAsync();
            return View(pSADB);
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.FkBillbill)
                .Include(r => r.FkGuestg)
                .Include(r => r.FkReservationStatusresStatus)
                .Include(r => r.FkRoomidRoomNavigation)
                .Include(r => r.FkWorkerw)
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            ViewData["FkBillbillId"] = new SelectList(_context.Bills, "BillId", "BillId");
            ViewData["FkGuestgId"] = new SelectList(_context.Guests, "GId", "GId");
            ViewData["FkReservationStatusresStatusId"] = new SelectList(_context.ReservationStatuses, "ResStatusId", "ResStatusId");
            ViewData["FkRoomidRoom"] = new SelectList(_context.Rooms, "IdRoom", "IdRoom");
            ViewData["FkWorkerwId"] = new SelectList(_context.Workers, "WId", "WId");
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CreationDate,CheckinDate,CheckoutDate,Adults,Children,Price,FkBillbillId,FkGuestgId,FkRoomidRoom,FkWorkerwId,FkReservationStatusresStatusId")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkBillbillId"] = new SelectList(_context.Bills, "BillId", "BillId", reservation.FkBillbillId);
            ViewData["FkGuestgId"] = new SelectList(_context.Guests, "GId", "GId", reservation.FkGuestgId);
            ViewData["FkReservationStatusresStatusId"] = new SelectList(_context.ReservationStatuses, "ResStatusId", "ResStatusId", reservation.FkReservationStatusresStatusId);
            ViewData["FkRoomidRoom"] = new SelectList(_context.Rooms, "IdRoom", "IdRoom", reservation.FkRoomidRoom);
            ViewData["FkWorkerwId"] = new SelectList(_context.Workers, "WId", "WId", reservation.FkWorkerwId);
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            ViewData["FkBillbillId"] = new SelectList(_context.Bills, "BillId", "BillId", reservation.FkBillbillId);
            ViewData["FkGuestgId"] = new SelectList(_context.Guests, "GId", "GId", reservation.FkGuestgId);
            ViewData["FkReservationStatusresStatusId"] = new SelectList(_context.ReservationStatuses, "ResStatusId", "ResStatusId", reservation.FkReservationStatusresStatusId);
            ViewData["FkRoomidRoom"] = new SelectList(_context.Rooms, "IdRoom", "IdRoom", reservation.FkRoomidRoom);
            ViewData["FkWorkerwId"] = new SelectList(_context.Workers, "WId", "WId", reservation.FkWorkerwId);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservationId,CreationDate,CheckinDate,CheckoutDate,Adults,Children,Price,FkBillbillId,FkGuestgId,FkRoomidRoom,FkWorkerwId,FkReservationStatusresStatusId")] Reservation reservation)
        {
            if (id != reservation.ReservationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.ReservationId))
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
            ViewData["FkBillbillId"] = new SelectList(_context.Bills, "BillId", "BillId", reservation.FkBillbillId);
            ViewData["FkGuestgId"] = new SelectList(_context.Guests, "GId", "GId", reservation.FkGuestgId);
            ViewData["FkReservationStatusresStatusId"] = new SelectList(_context.ReservationStatuses, "ResStatusId", "ResStatusId", reservation.FkReservationStatusresStatusId);
            ViewData["FkRoomidRoom"] = new SelectList(_context.Rooms, "IdRoom", "IdRoom", reservation.FkRoomidRoom);
            ViewData["FkWorkerwId"] = new SelectList(_context.Workers, "WId", "WId", reservation.FkWorkerwId);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.FkBillbill)
                .Include(r => r.FkGuestg)
                .Include(r => r.FkReservationStatusresStatus)
                .Include(r => r.FkRoomidRoomNavigation)
                .Include(r => r.FkWorkerw)
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reservations == null)
            {
                return Problem("Entity set 'PSADB.Reservations'  is null.");
            }
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
          return (_context.Reservations?.Any(e => e.ReservationId == id)).GetValueOrDefault();
        }
    }
}
