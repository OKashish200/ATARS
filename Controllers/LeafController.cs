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
    public class LeafController : Controller
    {
        private readonly TeacherAttendanceContext _context;

        public LeafController(TeacherAttendanceContext context)
        {
            _context = context;
        }

        // GET: Leaf
        public async Task<IActionResult> Index()
        {
            var teacherAttendanceContext = _context.Leaves.Include(l => l.Teacher);
            return View(await teacherAttendanceContext.ToListAsync());
        }

        // GET: Leaf/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaf = await _context.Leaves
                .Include(l => l.Teacher)
                .FirstOrDefaultAsync(m => m.Leaveid == id);
            if (leaf == null)
            {
                return NotFound();
            }

            return View(leaf);
        }

        // GET: Leaf/Create
        public IActionResult Create()
        {
            ViewData["Teacherid"] = new SelectList(_context.Teachers, "Teacherid", "Teacherid");
            return View();
        }

        // POST: Leaf/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Leaveid,Teacherid,Startdate,Enddate,Reason,Status")] Leaf leaf)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leaf);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Teacherid"] = new SelectList(_context.Teachers, "Teacherid", "Teacherid", leaf.Teacherid);
            return View(leaf);
        }

        // GET: Leaf/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaf = await _context.Leaves.FindAsync(id);
            if (leaf == null)
            {
                return NotFound();
            }
            ViewData["Teacherid"] = new SelectList(_context.Teachers, "Teacherid", "Teacherid", leaf.Teacherid);
            return View(leaf);
        }

        // POST: Leaf/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Leaveid,Teacherid,Startdate,Enddate,Reason,Status")] Leaf leaf)
        {
            if (id != leaf.Leaveid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaf);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeafExists(leaf.Leaveid))
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
            ViewData["Teacherid"] = new SelectList(_context.Teachers, "Teacherid", "Teacherid", leaf.Teacherid);
            return View(leaf);
        }

        // GET: Leaf/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaf = await _context.Leaves
                .Include(l => l.Teacher)
                .FirstOrDefaultAsync(m => m.Leaveid == id);
            if (leaf == null)
            {
                return NotFound();
            }

            return View(leaf);
        }

        // POST: Leaf/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var leaf = await _context.Leaves.FindAsync(id);
            if (leaf != null)
            {
                _context.Leaves.Remove(leaf);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeafExists(string id)
        {
            return _context.Leaves.Any(e => e.Leaveid == id);
        }
    }
}
