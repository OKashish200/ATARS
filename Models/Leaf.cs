using System;
using System.Collections.Generic;

namespace TeacherAttendance.Models;

public partial class Leaf
{
    public string Leaveid { get; set; } = null!;

    public string? Teacherid { get; set; }

    public DateOnly? Startdate { get; set; }

    public DateOnly? Enddate { get; set; }

    public string? Reason { get; set; }

    public string? Status { get; set; }

    public virtual Teacher? Teacher { get; set; }
}
