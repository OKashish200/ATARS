using System;
using System.Collections.Generic;

namespace TeacherAttendance.Models;

public partial class Adminuser
{
    public string Adminid { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Role { get; set; }
}
