using System;
using System.Collections.Generic;

namespace labWork22.Models;

public partial class Lw131Promocode
{
    public int IdPromocode { get; set; }

    public string? Name { get; set; }

    public double? Percent { get; set; }

    public virtual ICollection<Lw131Order> Lw131Orders { get; } = new List<Lw131Order>();
}
