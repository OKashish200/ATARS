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
    public class AttendanceController : Controller
    {
        private readonly TeacherAttendanceContext _context;

        public AttendanceController(TeacherAttendanceContext context)
        {
            _context = context;
        }

        // GET: Attendance
        public async Task<IActionResult> Index()
        {
            var teacherAttendanceContext = _context.Attendances.Include(a => a.Subject).Include(a => a.Teacher);
            return View(await teacherAttendanceContext.ToListAsync());
        }

        // GET: Attendance/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendances
                .Include(a => a.Subject)
                .Include(a => a.Teacher)
                .FirstOrDefaultAsync(m => m.Recordid == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        // GET: Attendance/Create
        public IActionResult Create()
        {
            ViewData["Subjectid"] = new SelectList(_context.Subjects, "Subjectid", "Subjectid");
            ViewData["Teacherid"] = new SelectList(_context.Teachers, "Teacherid", "Teacherid");
            return View();
        }

        // POST: Attendance/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Recordid,Date,Teacherid,Subjectid,Status")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attendance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Subjectid"] = new SelectList(_context.Subjects, "Subjectid", "Subjectid", attendance.Subjectid);
            ViewData["Teacherid"] = new SelectList(_context.Teachers, "Teacherid", "Teacherid", attendance.Teacherid);
            return View(attendance);
        }

        // GET: Attendance/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance == null)
            {
                return NotFound();
            }
            ViewData["Subjectid"] = new SelectList(_context.Subjects, "Subjectid", "Subjectid", attendance.Subjectid);
            ViewData["Teacherid"] = new SelectList(_context.Teachers, "Teacherid", "Teacherid", attendance.Teacherid);
            return View(attendance);
        }

        // POST: Attendance/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Recordid,Date,Teacherid,Subjectid,Status")] Attendance attendance)
        {
            if (id != attendance.Recordid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attendance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendanceExists(attendance.Recordid))
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
            ViewData["Subjectid"] = new SelectList(_context.Subjects, "Subjectid", "Subjectid", attendance.Subjectid);
            ViewData["Teacherid"] = new SelectList(_context.Teachers, "Teacherid", "Teacherid", attendance.Teacherid);
            return View(attendance);
        }

        // GET: Attendance/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendances
                .Include(a => a.Subject)
                .Include(a => a.Teacher)
                .FirstOrDefaultAsync(m => m.Recordid == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        // POST: Attendance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance != null)
            {
                _context.Attendances.Remove(attendance);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttendanceExists(string id)
        {
            return _context.Attendances.Any(e => e.Recordid == id);
        }
    }
}
