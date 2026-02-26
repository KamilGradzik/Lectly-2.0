using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Application.DTOs.Note
{
    public class NoteDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}