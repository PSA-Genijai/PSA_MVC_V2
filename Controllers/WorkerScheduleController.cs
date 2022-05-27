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
    public class WorkerScheduleController : Controller
    {
        private readonly PSADB _context;

        public WorkerScheduleController(PSADB context)
        {
            _context = context;
        }

        // GET: WorkerSchedule
        public async Task<IActionResult> Index()
        {
            var pSADB = _context.WorkerSchedules.Include(w => w.FkTimeTable);
            return View(await pSADB.ToListAsync());
        }


        // GET: WorkerSchedule/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WorkerSchedules == null)
            {
                return NotFound();
            }

            var workerSchedule = await _context.WorkerSchedules
                .Include(w => w.FkTimeTable)
                .FirstOrDefaultAsync(m => m.WorkerScheduleId == id);
            if (workerSchedule == null)
            {
                return NotFound();
            }

            return View(workerSchedule);
        }

        // GET: WorkerSchedule/Create
        public IActionResult Create()
        {
            ViewData["FkTimeTableId"] = new SelectList(_context.TimeTables, "TimeTableId", "TimeTableId");
            return View();
        }

        // POST: WorkerSchedule/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkerScheduleId,SName,SType,FkTimeTableId")] WorkerSchedule workerSchedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workerSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkTimeTableId"] = new SelectList(_context.TimeTables, "TimeTableId", "TimeTableId", workerSchedule.FkTimeTableId);
            return View(workerSchedule);
        }

        // GET: WorkerSchedule/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WorkerSchedules == null)
            {
                return NotFound();
            }

            var workerSchedule = await _context.WorkerSchedules.FindAsync(id);
            if (workerSchedule == null)
            {
                return NotFound();
            }
            ViewData["FkTimeTableId"] = new SelectList(_context.TimeTables, "TimeTableId", "TimeTableId", workerSchedule.FkTimeTableId);
            return View(workerSchedule);
        }

        // POST: WorkerSchedule/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkerScheduleId,SName,SType,FkTimeTableId")] WorkerSchedule workerSchedule)
        {
            if (id != workerSchedule.WorkerScheduleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workerSchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkerScheduleExists(workerSchedule.WorkerScheduleId))
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
            ViewData["FkTimeTableId"] = new SelectList(_context.TimeTables, "TimeTableId", "TimeTableId", workerSchedule.FkTimeTableId);
            return View(workerSchedule);
        }

        // GET: WorkerSchedule/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WorkerSchedules == null)
            {
                return NotFound();
            }

            var workerSchedule = await _context.WorkerSchedules
                .Include(w => w.FkTimeTable)
                .FirstOrDefaultAsync(m => m.WorkerScheduleId == id);
            if (workerSchedule == null)
            {
                return NotFound();
            }

            return View(workerSchedule);
        }

        // POST: WorkerSchedule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WorkerSchedules == null)
            {
                return Problem("Entity set 'PSADB.WorkerSchedules'  is null.");
            }
            var workerSchedule = await _context.WorkerSchedules.FindAsync(id);
            if (workerSchedule != null)
            {
                _context.WorkerSchedules.Remove(workerSchedule);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkerScheduleExists(int id)
        {
          return (_context.WorkerSchedules?.Any(e => e.WorkerScheduleId == id)).GetValueOrDefault();
        }
    }
}
