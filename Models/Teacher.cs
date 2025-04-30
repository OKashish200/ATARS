using System;
using System.Collections.Generic;

namespace TeacherAttendance.Models;

public partial class Teacher
{
    public string Teacherid { get; set; } = null!;

    public string Teachername { get; set; } = null!;

    public char? Gender { get; set; }

    public string? Subjectid { get; set; }

    public string? Departmentid { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual Department? Department { get; set; }

    public virtual ICollection<Leaf> Leaves { get; set; } = new List<Leaf>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual Subject? Subject { get; set; }

    public virtual ICollection<Timetable> Timetables { get; set; } = new List<Timetable>();
}
