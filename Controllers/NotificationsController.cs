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
    public class NotificationsController : Controller
    {
        private readonly PSADB _context;

        public NotificationsController(PSADB context)
        {
            _context = context;
        }

        // GET: Notifications
        public async Task<IActionResult> Index()
        {
            var pSADB = _context.Messages.Include(m => m.FkGuestg);
            return View(await pSADB.ToListAsync());
        }

        // GET: Notifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Messages == null)
            {
                return NotFound();
            }

            var message = await _context.Messages
                .Include(m => m.FkGuestg)
                .FirstOrDefaultAsync(m => m.Correspondence == id);
            if (message == null)
            {
                return NotFound();
            }
            message.Checked = true;
            _context.Update(message);
            await _context.SaveChangesAsync();

            return View(message);
        }
    }
}
