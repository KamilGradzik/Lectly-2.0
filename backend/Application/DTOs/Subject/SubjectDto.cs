using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Application.DTOs.Subject
{
    public class SubjectDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Desc { get; set; }
    }
}