using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Application.DTOs.Student
{
    public class CreateStudentDto
    {
        public string StudentCode { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? AdditionalInfo { get; set; }
        public Guid GroupId { get; set; }
    }
}