using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeacherAttendance.Models;

namespace TeacherAttendance.Controllers
{
    public class AdminuserController : Controller
    {
        private readonly TeacherAttendanceContext _context;

        public AdminuserController(TeacherAttendanceContext context)
        {
            _context = context;
        }

        // GET: Adminuser
        public async Task<IActionResult> Index()
        {
            return View(await _context.Adminusers.ToListAsync());
        }

        // GET: Adminuser/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminuser = await _context.Adminusers
                .FirstOrDefaultAsync(m => m.Adminid == id);
            if (adminuser == null)
            {
                return NotFound();
            }

            return View(adminuser);
        }

        // GET: Adminuser/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Adminuser/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Adminid,Username,Password,Role")] Adminuser adminuser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminuser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adminuser);
        }

        // GET: Adminuser/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminuser = await _context.Adminusers.FindAsync(id);
            if (adminuser == null)
            {
                return NotFound();
            }
            return View(adminuser);
        }

        // POST: Adminuser/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Adminid,Username,Password,Role")] Adminuser adminuser)
        {
            if (id != adminuser.Adminid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminuser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminuserExists(adminuser.Adminid))
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
            return View(adminuser);
        }

        // GET: Adminuser/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminuser = await _context.Adminusers
                .FirstOrDefaultAsync(m => m.Adminid == id);
            if (adminuser == null)
            {
                return NotFound();
            }

            return View(adminuser);
        }

        // POST: Adminuser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var adminuser = await _context.Adminusers.FindAsync(id);
            if (adminuser != null)
            {
                _context.Adminusers.Remove(adminuser);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminuserExists(string id)
        {
            return _context.Adminusers.Any(e => e.Adminid == id);
        }
    }
}
