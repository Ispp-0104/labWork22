using System;
using System.Collections.Generic;

namespace labWork22_WPF_.Models;

public partial class Log
{
    public int IdLog { get; set; }

    public DateTime DateTime { get; set; }

    public string? Operation { get; set; }

    public string CurrentUser { get; set; } = null!;
}
