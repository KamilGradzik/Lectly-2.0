using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.Common;
using backend.Entities;

namespace backend.Domain.Repositories
{
    public interface INoteRepository
    {
        Task AddAsync(Note note);
        Task<Note?> GetAsync(Guid id);
        Task<PagedResult<Note>> GetUserNotesAsync(Guid userId, int requestPage, int perPage);
        Task RemoveAsync(Note note);
    }
}