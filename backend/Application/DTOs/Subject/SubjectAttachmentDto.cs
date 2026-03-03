using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Application.DTOs.Subject
{
    public class SubjectAttachmentDto
    {
        public Guid SubjectId { get; set; }
        public Guid ClassGroupId { get; set; }
    }
}