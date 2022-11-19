using System;
using System.Collections.Generic;

namespace labWork22_WPF_.Models;

public partial class GeneralOrderProductView
{
    public int НомерЗаказа { get; set; }

    public DateTime ВремяЗаказа { get; set; }

    public string Логин { get; set; } = null!;

    public string ПолноеИмя { get; set; } = null!;

    public string Продукт { get; set; } = null!;

    public decimal Цена { get; set; }

    public int? Количество { get; set; }

    public decimal? Стоимость { get; set; }
}
