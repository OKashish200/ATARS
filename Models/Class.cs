using System;
using System.Collections.Generic;

namespace TeacherAttendance.Models;

public partial class Class
{
    public string Classid { get; set; } = null!;

    public string Classname { get; set; } = null!;

    public string? Section { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Timetable> Timetables { get; set; } = new List<Timetable>();
}
