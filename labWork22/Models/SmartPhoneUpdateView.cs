using System;
using System.Collections.Generic;

namespace labWork22.Models;

public partial class SmartPhoneUpdateView
{
    public int IdProduct { get; set; }

    public int IdManufacturer { get; set; }

    public string Model { get; set; } = null!;

    public decimal Price { get; set; }

    public short RealeseYear { get; set; }

    public string Type { get; set; } = null!;

    public decimal? Mass { get; set; }

    public string? Description { get; set; }
}
