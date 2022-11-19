using System;
using System.Collections.Generic;

namespace labWork22_WPF_.Models;

public partial class Lw133Pizza
{
    public int IdPizza { get; set; }

    public string Name { get; set; } = null!;

    public int Mass { get; set; }

    public int Price { get; set; }

    public virtual ICollection<Lw133Ingredient> IdIndgredients { get; } = new List<Lw133Ingredient>();
}
