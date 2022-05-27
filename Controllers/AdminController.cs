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
    public class AdminController : Controller
    {
        private readonly PSADB _context;

        public AdminController(PSADB context)
        {
            _context = context;
        }

        // GET: Workers
        public async Task<IActionResult> Index()
        {
            var pSADB = _context.Workers.Include(w => w.FkMessageCorrespondenceNavigation).Include(w => w.FkWorkerTypeworkerType);
            return View(await pSADB.ToListAsync());
        }

        // GET: Workers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Workers == null)
            {
                return NotFound();
            }

            var worker = await _context.Workers
                .Include(w => w.FkMessageCorrespondenceNavigation)
                .Include(w => w.FkWorkerTypeworkerType)
                .FirstOrDefaultAsync(m => m.WNickname == id);
            if (worker == null)
            {
                return NotFound();
            }

            return View(worker);
        }

        // GET: Workers/Create
        public IActionResult Create()
        {
            ViewData["FkMessageCorrespondence"] = new SelectList(_context.Messages, "Correspondence", "Correspondence");
            ViewData["FkWorkerTypeworkerTypeId"] = new SelectList(_context.WorkerTypes, "WorkerTypeId", "WorkerTypeId");
            return View();
        }

        // POST: Workers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WId,WNickname,WPassword,WName,WLastname,WEmail,WBirthDate,WAdress,WPhoneNumber,WGender,FkWorkerTypeworkerTypeId,FkMessageCorrespondence")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(worker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkMessageCorrespondence"] = new SelectList(_context.Messages, "Correspondence", "Correspondence", worker.FkMessageCorrespondence);
            ViewData["FkWorkerTypeworkerTypeId"] = new SelectList(_context.WorkerTypes, "WorkerTypeId", "WorkerTypeId", worker.FkWorkerTypeworkerTypeId);
            return View(worker);
        }

        public IActionResult Login()
        {
            if (isLoggedIn(HttpContext))
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // POST: Workers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("WId,WNickname,WPassword,WName,WLastname,WEmail,WBirthDate,WAdress,WPhoneNumber,WGender,FkWorkerTypeworkerTypeId,FkMessageCorrespondence")] Worker worker)
        {
            var foundUser = _context.Workers.Where(x=>x.WNickname == worker.WNickname && x.WPassword == worker.WPassword).FirstOrDefault();
            if(foundUser == null)
            {
                return View(worker);
            }

            HttpContext.Session.SetInt32(SessionValues.UserName, foundUser.WId);
            HttpContext.Session.SetString(SessionValues.UserName, foundUser.WNickname);
            HttpContext.Session.SetString(SessionValues.UserType, foundUser.FkWorkerTypeworkerType != null ? foundUser.FkWorkerTypeworkerType.WorkerType1 : "Admin");

            return RedirectToAction(nameof(Index));
        }

        // GET: Workers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Workers == null)
            {
                return NotFound();
            }

            var worker = await _context.Workers.FindAsync(id);
            if (worker == null)
            {
                return NotFound();
            }
            ViewData["FkMessageCorrespondence"] = new SelectList(_context.Messages, "Correspondence", "Correspondence", worker.FkMessageCorrespondence);
            ViewData["FkWorkerTypeworkerTypeId"] = new SelectList(_context.WorkerTypes, "WorkerTypeId", "WorkerTypeId", worker.FkWorkerTypeworkerTypeId);
            return View(worker);
        }

        // POST: Workers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WId,WNickname,WPassword,WName,WLastname,WEmail,WBirthDate,WAdress,WPhoneNumber,WGender,FkWorkerTypeworkerTypeId,FkMessageCorrespondence")] Worker worker)
        {
            if (id != worker.WId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(worker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkerExists(worker.WId))
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
            ViewData["FkMessageCorrespondence"] = new SelectList(_context.Messages, "Correspondence", "Correspondence", worker.FkMessageCorrespondence);
            ViewData["FkWorkerTypeworkerTypeId"] = new SelectList(_context.WorkerTypes, "WorkerTypeId", "WorkerTypeId", worker.FkWorkerTypeworkerTypeId);
            return View(worker);
        }

        // GET: Workers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Workers == null)
            {
                return NotFound();
            }

            var worker = await _context.Workers
                .Include(w => w.FkMessageCorrespondenceNavigation)
                .Include(w => w.FkWorkerTypeworkerType)
                .FirstOrDefaultAsync(m => m.WId == id);
            if (worker == null)
            {
                return NotFound();
            }

            return View(worker);
        }

        // POST: Workers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Workers == null)
            {
                return Problem("Entity set 'PSADB.Workers'  is null.");
            }
            var worker = await _context.Workers.FindAsync(id);
            if (worker != null)
            {
                _context.Workers.Remove(worker);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkerExists(int id)
        {
          return (_context.Workers?.Any(e => e.WId == id)).GetValueOrDefault();
        }

        public static bool isLoggedIn(HttpContext httpContext)
        {
            return httpContext.Session.TryGetValue(SessionValues.UserName, out var userName);
        }
    }
}
