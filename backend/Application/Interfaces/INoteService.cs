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
        Task AddNoteAsync(CreateNoteDto dto, Guid userId);
        Task<PagedResult<NoteDto>> GetUserNotesAsync(Guid userId, int Page, int PageSize);
        Task UpdateNoteAsync(UpdateNoteDto dto, Guid userId);
        Task RemoveNoteAsync(Guid noteId, Guid userId);

    }
}