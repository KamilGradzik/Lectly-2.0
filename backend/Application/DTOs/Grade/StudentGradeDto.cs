using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.DTOs.Subject;

namespace backend.Application.DTOs.Grade
{
    public class StudentGradeDto
    {
        public Guid Id { get; set; }
        public decimal Value { get; set; }
        public decimal Weight { get; set; }
        public string Desc { get; set; } = null!;
        public DateTime DateIssued { get; set; }
        public SubjectDto Subject { get; set; } = null!;
    }
}