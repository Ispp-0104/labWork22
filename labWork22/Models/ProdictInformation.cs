using System;
using System.Collections.Generic;

namespace labWork22_WPF_.Models;

public partial class ProdictInformation
{
    public int IdПродукта { get; set; }

    public string Продукт { get; set; } = null!;

    public decimal Цена { get; set; }
}
