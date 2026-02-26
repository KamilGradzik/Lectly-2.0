using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Application.DTOs.Note
{
    public class CreateNoteDto
    {
        public required string Name { get; set; }
        public required string Content { get; set; }
    }
}