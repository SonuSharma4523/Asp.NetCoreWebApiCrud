using System;
using System.Collections.Generic;

namespace Asp.NetCoreWebApiCrud.Models;

public partial class UserCredential
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;
}
