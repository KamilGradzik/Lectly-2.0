using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Application.DTOs.Subject
{
    public class CreateSubjectDto
    {
        public string Name { get; set; } = null!;
        public string? Desc { get; set; }
    }
}