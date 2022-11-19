using System;
using System.Collections.Generic;

namespace labWork22_WPF_.Models;

public partial class Lw131Pizza
{
    public int IdPizza { get; set; }

    public string? Name { get; set; }

    public string? Ingredients { get; set; }

    public double? Weight { get; set; }

    public double? Price { get; set; }

    public virtual ICollection<Lw131OrderList> Lw131OrderLists { get; } = new List<Lw131OrderList>();
}
