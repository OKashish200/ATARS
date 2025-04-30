using System;
using System.Collections.Generic;

namespace TeacherAttendance.Models;

public partial class Timetable
{
    public string Timetableid { get; set; } = null!;

    public string? Teacherid { get; set; }

    public string? Classid { get; set; }

    public string? Subjectid { get; set; }

    public string? Day { get; set; }

    public string? Period { get; set; }

    public virtual Class? Class { get; set; }

    public virtual Subject? Subject { get; set; }

    public virtual Teacher? Teacher { get; set; }
}
