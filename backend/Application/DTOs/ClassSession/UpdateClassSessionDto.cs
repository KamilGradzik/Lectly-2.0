using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Application.DTOs.ClassSession
{
    public class UpdateClassSessionDto
    {
        public Guid Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public string Classroom { get; set; } = null!;
        public Guid SubjectId { get; set; }
        public Guid ClassGroupId { get; set; }
    }
}