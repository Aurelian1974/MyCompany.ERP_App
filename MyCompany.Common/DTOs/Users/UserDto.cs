﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Common.DTOs.Users;

public class UserDto
{
    public int UserId { get; set; }
    public string ? UserName { get; set; }
    public string ? Password { get; set; }
    public DateTime CreatedAt { get; set; }
}