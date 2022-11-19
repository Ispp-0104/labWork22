using System;
using System.Collections.Generic;

namespace labWork22.Models;

public partial class Order
{
    public int IdOrder { get; set; }

    public int IdBuyer { get; set; }

    public DateTime? DataTimeOrder { get; set; }

    public bool StatusOrder { get; set; }

    public virtual Buyer IdBuyerNavigation { get; set; } = null!;

    public virtual ICollection<OrderedProduct> OrderedProducts { get; } = new List<OrderedProduct>();
}
