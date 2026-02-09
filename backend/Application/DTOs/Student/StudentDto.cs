using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Application.DTOs.Student
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string StudentCode { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? AdditionalInfo { get; set; }
    }
}