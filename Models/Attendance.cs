using System;
using System.Collections.Generic;

namespace TeacherAttendance.Models;

public partial class Attendance
{
    public string Recordid { get; set; } = null!;

    public DateOnly Date { get; set; }

    public string? Teacherid { get; set; }

    public string? Subjectid { get; set; }

    public char? Status { get; set; }

    public virtual Subject? Subject { get; set; }

    public virtual Teacher? Teacher { get; set; }
}
