using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Repositories;
using backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Infrastructure.Persistence.Repositories
{
    public class ClassSessionRepository : IClassSessionRepository
    {
        private readonly AppDbContext _context;
        public ClassSessionRepository(AppDbContext context) { _context = context; }

        public async Task AddAsync(ClassSession classSession)
        {
            _context.ClassSessions.Add(classSession);
        }

        public async Task<ClassSession?> GetAsync(Guid id)
        {
            return await _context.ClassSessions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<ClassSession>> GetUserClassSessionsAsync(Guid userId)
        {
            return await _context.ClassSessions.Where(x => x.OwnerUserId == userId).ToListAsync();
        }

        public async Task<bool> CheckExistingAsync(Guid userId, DayOfWeek dayOfWeek, TimeOnly startTime, TimeOnly endTime)
        {
            return await _context.ClassSessions.AnyAsync(x => x.OwnerUserId == userId && x.DayOfWeek == dayOfWeek && x.StartTime <= startTime && x.EndTime >= endTime);
        }

        public async Task  RemoveAsync(ClassSession classSession)
        {
            _context.ClassSessions.Remove(classSession);
        }
    }
}