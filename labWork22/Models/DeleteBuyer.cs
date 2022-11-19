using System;
using System.Collections.Generic;

namespace labWork22_WPF_.Models;

public partial class DeleteBuyer
{
    public int IdDeleteBuyer { get; set; }

    public int IdBuyer { get; set; }

    public string Login { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Address { get; set; }

    public string? Telephone { get; set; }

    public DateTime DateDeleteBuyer { get; set; }
}
