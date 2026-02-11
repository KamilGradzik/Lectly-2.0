using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Application.DTOs.Note
{
    public class CreateNoteDto
    {
        public string Name { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}