﻿using System;
using System.Collections.Generic;

namespace Asp.NetCoreWebApiCrud.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Designation { get; set; }

    public int? Salary { get; set; }
}
