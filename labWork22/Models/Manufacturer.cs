using System;
using System.Collections.Generic;

namespace labWork22.Models;

public partial class Manufacturer
{
    public int IdManufacturer { get; set; }

    public string Name { get; set; } = null!;

    public string Country { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
