using System;
using System.Collections.Generic;

namespace labWork22_WPF_.Models;

public partial class Lw131Order
{
    public int IdOrder { get; set; }

    public DateTime? DateOfOrder { get; set; }

    public int? IdPromocode { get; set; }

    public virtual Lw131Promocode? IdPromocodeNavigation { get; set; }

    public virtual ICollection<Lw131OrderList> Lw131OrderLists { get; } = new List<Lw131OrderList>();
}
