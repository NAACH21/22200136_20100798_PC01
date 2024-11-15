﻿using System;
using System.Collections.Generic;

namespace EventManagementDB.DOMAIN.Core.Entities;

public partial class Attendees
{
    public int Id { get; set; }

    public string AttendeeName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public DateTime? RegisteredAt { get; set; }

    public virtual ICollection<EventAttendance> EventAttendance { get; set; } = new List<EventAttendance>();

    public virtual ICollection<Events> Events { get; set; } = new List<Events>();
}
