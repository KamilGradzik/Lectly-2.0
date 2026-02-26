using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Application.DTOs.Student
{
    public class CreateStudentDto
    {
        public required string StudentCode { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? AdditionalInfo { get; set; }
    }
}