using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Application.DTOs
{
    public class UserLoginDto
    {
        string Email { get; set; } = null!;
        string Password { get; set; } = null!;
    }
}