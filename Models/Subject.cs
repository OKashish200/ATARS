using System;
using System.Collections.Generic;

namespace TeacherAttendance.Models;

public partial class Subject
{
    public string Subjectid { get; set; } = null!;

    public string Subjectname { get; set; } = null!;

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();

    public virtual ICollection<Timetable> Timetables { get; set; } = new List<Timetable>();
}
