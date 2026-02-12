using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Application.DTOs.Grade
{
    public class GradeDto
    {
        public Guid Id { get; set; }
        public decimal Value { get; set; }
        public decimal Weight { get; set; }
        public string Desc { get; set; } = null!;
        public Guid SubjectId { get; set; }
    }
}