using System;
using System.Collections.Generic;

namespace labWork22_WPF_.Models;

public partial class User
{
    public int IdUser { get; set; }

    public int IdRole { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual Role IdRoleNavigation { get; set; } = null!;
}
