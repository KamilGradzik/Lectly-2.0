using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Application.DTOs.User
{
    public class UserDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}