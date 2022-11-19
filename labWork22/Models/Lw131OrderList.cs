using System;
using System.Collections.Generic;

namespace labWork22.Models;

public partial class Lw131OrderList
{
    public int IdOrder { get; set; }

    public int IdPizza { get; set; }

    public double? Quantity { get; set; }

    public virtual Lw131Order IdOrderNavigation { get; set; } = null!;

    public virtual Lw131Pizza IdPizzaNavigation { get; set; } = null!;
}
