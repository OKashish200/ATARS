using System;
using System.Collections.Generic;

namespace TeacherAttendance.Models;

public partial class Department
{
    public string Departmentid { get; set; } = null!;

    public string Departmentname { get; set; } = null!;

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
