using System;
using System.Collections.Generic;

namespace labWork22.Models;

public partial class Lw22User
{
    public int IdUser { get; set; }

    public string? Name { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? Ip { get; set; }

    public DateTime? LastEnter { get; set; }
}
