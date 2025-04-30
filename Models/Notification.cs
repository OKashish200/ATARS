using System;
using System.Collections.Generic;

namespace TeacherAttendance.Models;

public partial class Notification
{
    public string Notificationid { get; set; } = null!;

    public string? Recipientid { get; set; }

    public string? Message { get; set; }

    public DateOnly? Datesent { get; set; }

    public virtual Teacher? Recipient { get; set; }
}
