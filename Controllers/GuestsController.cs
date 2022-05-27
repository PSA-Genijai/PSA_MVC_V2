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
    public class GuestsController : Controller
    {
        private readonly PSADB _context;

        public GuestsController(PSADB context)
        {
            _context = context;
        }

        // GET: Guests
        public async Task<IActionResult> Index()
        {
              return _context.Guests != null ? 
                          View(await _context.Guests.ToListAsync()) :
                          Problem("Entity set 'PSADB.Guests'  is null.");
        }

        public async Task<IActionResult> Details(string id)
        {

            if (id == null || _context.Guests == null)
            {
                return NotFound();
            }

            var guest = await _context.Guests
                .FirstOrDefaultAsync(m => m.GNickname == id);
            if (guest == null)
            {
                return NotFound();
            }

            return View(guest);
        }

        public IActionResult Login()
        {
            if (WorkersController.isLoggedIn(HttpContext))
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        // POST: Guests/Login
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("GNickname,GPassword,GEmail")] Guest guest)
        {

            var foundUser = _context.Guests.FirstOrDefault(y=>y.GNickname == guest.GNickname && y.GPassword == guest.GPassword);
            if(foundUser == null)
            {
                return View(guest);
            }

            HttpContext.Session.SetInt32(SessionValues.UserName, foundUser.GId);
            HttpContext.Session.SetString(SessionValues.UserName, foundUser.GNickname);
            HttpContext.Session.SetString(SessionValues.UserType, "Client");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View();
        }

        // GET: Guests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Guests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GId,GNickname,GPassword,GName,GLastname,GEmail,GBirthDate,GAdress,GPhoneNumber,GGender")] Guest guest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(guest);
        }

        // GET: Guests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Guests == null)
            {
                return NotFound();
            }

            var guest = await _context.Guests.FindAsync(id);
            if (guest == null)
            {
                return NotFound();
            }
            return View(guest);
        }

        // POST: Guests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GId,GNickname,GPassword,GName,GLastname,GEmail,GBirthDate,GAdress,GPhoneNumber,GGender")] Guest guest)
        {
            if (id != guest.GId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuestExists(guest.GId))
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
            return View(guest);
        }

        // GET: Guests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Guests == null)
            {
                return NotFound();
            }

            var guest = await _context.Guests
                .FirstOrDefaultAsync(m => m.GId == id);
            if (guest == null)
            {
                return NotFound();
            }

            return View(guest);
        }

        // POST: Guests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Guests == null)
            {
                return Problem("Entity set 'PSADB.Guests'  is null.");
            }
            var guest = await _context.Guests.FindAsync(id);
            if (guest != null)
            {
                _context.Guests.Remove(guest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuestExists(int id)
        {
          return (_context.Guests?.Any(e => e.GId == id)).GetValueOrDefault();
        }
    }
}
