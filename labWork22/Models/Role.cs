﻿using System;
using System.Collections.Generic;

namespace labWork22.Models;

public partial class Role
{
    public int IdRole { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
