using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Repositories;
using backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Persistence.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AppDbContext _context;
        public SubjectRepository(AppDbContext context) { _context = context; }

        public async Task AddAsync(Subject subject)
        {
            _context.Subjects.Add(subject);
        }

        public async Task<Subject> GetSubjectAsync(Guid id)
        {
            var subject = await _context.Subjects.FirstOrDefaultAsync(x => x.Id == id);
            if(subject == null)
                throw new ArgumentNullException("Cannot find Subject with specified id!");
            return subject;
        }

        public async Task<IReadOnlyList<Subject>> GetUserSubjectsAsync(Guid userId)
        {
            var subjects = await _context.Subjects.Where(x => x.OwnerUserId == userId).ToListAsync();
            return subjects;
        }

        public async Task RemoveAsync(Subject subject)
        {
            _context.Subjects.Remove(subject);
        }
    }
}