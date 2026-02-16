using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Application.DTOs.ClassGroup
{
    public class CreateClassGroupDto
    {
        public string Name { get; set; } = null!;
        public string? Desc { get; set; }
    }
}