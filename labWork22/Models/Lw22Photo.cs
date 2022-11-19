using System;
using System.Collections.Generic;

namespace labWork22.Models;

public partial class Lw22Photo
{
    public int IdPhoto { get; set; }

    public int IdGame { get; set; }

    public string FileName { get; set; } = null!;

    public byte[] Photo { get; set; } = null!;
}
