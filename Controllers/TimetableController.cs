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
    public class TimetableController : Controller
    {
        private readonly TeacherAttendanceContext _context;

        public TimetableController(TeacherAttendanceContext context)
        {
            _context = context;
        }

        // GET: Timetable
        public async Task<IActionResult> Index()
        {
            var teacherAttendanceContext = _context.Timetables.Include(t => t.Class).Include(t => t.Subject).Include(t => t.Teacher);
            return View(await teacherAttendanceContext.ToListAsync());
        }

        // GET: Timetable/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timetable = await _context.Timetables
                .Include(t => t.Class)
                .Include(t => t.Subject)
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.Timetableid == id);
            if (timetable == null)
            {
                return NotFound();
            }

            return View(timetable);
        }

        // GET: Timetable/Create
        public IActionResult Create()
        {
            ViewData["Classid"] = new SelectList(_context.Classes, "Classid", "Classid");
            ViewData["Subjectid"] = new SelectList(_context.Subjects, "Subjectid", "Subjectid");
            ViewData["Teacherid"] = new SelectList(_context.Teachers, "Teacherid", "Teacherid");
            return View();
        }

        // POST: Timetable/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Timetableid,Teacherid,Classid,Subjectid,Day,Period")] Timetable timetable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timetable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Classid"] = new SelectList(_context.Classes, "Classid", "Classid", timetable.Classid);
            ViewData["Subjectid"] = new SelectList(_context.Subjects, "Subjectid", "Subjectid", timetable.Subjectid);
            ViewData["Teacherid"] = new SelectList(_context.Teachers, "Teacherid", "Teacherid", timetable.Teacherid);
            return View(timetable);
        }

        // GET: Timetable/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timetable = await _context.Timetables.FindAsync(id);
            if (timetable == null)
            {
                return NotFound();
            }
            ViewData["Classid"] = new SelectList(_context.Classes, "Classid", "Classid", timetable.Classid);
            ViewData["Subjectid"] = new SelectList(_context.Subjects, "Subjectid", "Subjectid", timetable.Subjectid);
            ViewData["Teacherid"] = new SelectList(_context.Teachers, "Teacherid", "Teacherid", timetable.Teacherid);
            return View(timetable);
        }

        // POST: Timetable/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Timetableid,Teacherid,Classid,Subjectid,Day,Period")] Timetable timetable)
        {
            if (id != timetable.Timetableid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timetable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimetableExists(timetable.Timetableid))
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
            ViewData["Classid"] = new SelectList(_context.Classes, "Classid", "Classid", timetable.Classid);
            ViewData["Subjectid"] = new SelectList(_context.Subjects, "Subjectid", "Subjectid", timetable.Subjectid);
            ViewData["Teacherid"] = new SelectList(_context.Teachers, "Teacherid", "Teacherid", timetable.Teacherid);
            return View(timetable);
        }

        // GET: Timetable/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timetable = await _context.Timetables
                .Include(t => t.Class)
                .Include(t => t.Subject)
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.Timetableid == id);
            if (timetable == null)
            {
                return NotFound();
            }

            return View(timetable);
        }

        // POST: Timetable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var timetable = await _context.Timetables.FindAsync(id);
            if (timetable != null)
            {
                _context.Timetables.Remove(timetable);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimetableExists(string id)
        {
            return _context.Timetables.Any(e => e.Timetableid == id);
        }
    }
}
