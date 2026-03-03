using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Application.DTOs.Student
{
    public class StudentAttachmentDto
    {
        public Guid StudentId { get; set; }
        public Guid ClassGroupId { get; set; }
    }
}