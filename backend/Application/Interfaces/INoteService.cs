using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.Common;
using backend.Application.DTOs.Note;

namespace backend.Application.Interfaces
{
    public interface INoteService
    {
        Task AddNoteAsync(CreateNoteDto dto);
        Task<PagedResult<NoteDto>> GetUserNotesAsync(int Page, int PageSize);
        Task UpdateNoteAsync(UpdateNoteDto dto);
        Task RemoveNoteAsync(Guid noteId);

    }
}