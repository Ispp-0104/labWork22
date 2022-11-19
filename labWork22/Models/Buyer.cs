using System;
using System.Collections.Generic;

namespace labWork22.Models;

public partial class Buyer
{
    public int IdBuyer { get; set; }

    public string Login { get; set; } = null!;

    public string? Password { get; set; }

    public string LastName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Address { get; set; }

    public string? Telephone { get; set; }

    public byte[]? Photo { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
