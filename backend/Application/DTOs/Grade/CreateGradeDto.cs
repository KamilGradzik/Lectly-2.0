using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Application.DTOs.Grade
{
    public class CreateGradeDto
    {
        public decimal Value { get; set; }
        public decimal Weight { get; set; }
        public string Desc { get; set; } = null!;
        public DateTime DateIssued { get; set; }
        public Guid SubjectId { get; set; }
        public Guid StudentId { get; set; }
    }
}