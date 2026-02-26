using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.DTOs.ClassGroup;
using backend.Application.DTOs.Subject;

namespace backend.Application.DTOs.ClassSession
{
    public class ClassSessionDto
    {
        public Guid Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public required string Classroom { get; set; }
        public SubjectDto? Subject { get; set; }
        public ClassGroupDto? ClassGroup { get; set; }
    }
}