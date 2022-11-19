using System;
using System.Collections.Generic;

namespace labWork22.Models;

public partial class Lw22Game
{
    public int IdGame { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int IdCategory { get; set; }

    public decimal Price { get; set; }

    public string? LogoFile { get; set; }
}
