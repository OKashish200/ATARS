using System;
using System.Collections.Generic;

namespace TeacherAttendance.Models;

public partial class PlayingWithNeon
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public float? Value { get; set; }
}
