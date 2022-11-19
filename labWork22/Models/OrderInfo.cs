using System;
using System.Collections.Generic;

namespace labWork22.Models;

public partial class OrderInfo
{
    public int НомерЗаказа { get; set; }

    public DateTime ВремяЗаказа { get; set; }

    public string Логин { get; set; } = null!;

    public string ПолноеИмя { get; set; } = null!;
}
