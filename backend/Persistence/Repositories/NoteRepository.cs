using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.Common;
using backend.Domain.Repositories;
using backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Persistence.Repositories
{
    public class NoteRepository : INoteRepository
    {  
        private readonly AppDbContext _context;
        public NoteRepository(AppDbContext context) { _context = context; }

        public async Task AddAsync(Note note)
        {
            _context.Notes.Add(note);
        }

        public async Task<Note?> GetAsync(Guid id)
        {
            return await _context.Notes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PagedResult<Note>> GetUserNotesAsync(Guid userId, int page, int pageSize)
        {
            var totalCount = await _context.Notes.Where(x => x.OwnerUserId == userId).CountAsync();
            var items = await _context.Notes.Where(x => x.OwnerUserId == userId).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedResult<Note>(items, page, pageSize, totalCount);
        }

        public async Task RemoveAsync(Note note)
        {
            _context.Notes.Remove(note);
        }
    }
}