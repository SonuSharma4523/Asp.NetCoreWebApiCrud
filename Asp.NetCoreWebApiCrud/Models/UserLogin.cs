﻿

namespace Asp.NetCoreWebApiCrud.Models;

public  class UserLogin
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;
}
