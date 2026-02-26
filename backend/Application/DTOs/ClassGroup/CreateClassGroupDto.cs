using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Application.DTOs.ClassGroup
{
    public class CreateClassGroupDto
    {
        public required string Name { get; set; }
        public string? Desc { get; set; }
    }
}