using System;
using System.Collections.Generic;

namespace labWork22_WPF_.Models;

public partial class Lw133Ingredient
{
    public int IdIngredient { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Lw133Pizza> IdPizzas { get; } = new List<Lw133Pizza>();
}
