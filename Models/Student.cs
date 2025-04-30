using System;
using System.Collections.Generic;

namespace TeacherAttendance.Models;

public partial class Student
{
    public string Studentid { get; set; } = null!;

    public string Studentname { get; set; } = null!;

    public char? Gender { get; set; }

    public string? Classid { get; set; }

    public virtual Class? Class { get; set; }
}
