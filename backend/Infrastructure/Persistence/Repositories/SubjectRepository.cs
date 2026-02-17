using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Repositories;
using backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Infrastructure.Persistence.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AppDbContext _context;
        public SubjectRepository(AppDbContext context) { _context = context; }

        public async Task AddAsync(Subject subject)
        {
            _context.Subjects.Add(subject);
        }

        public async Task<Subject?> GetAsync(Guid id)
        {
            return await _context.Subjects.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<Subject>> GetUserSubjectsAsync(Guid userId)
        {
            return await _context.Subjects.Where(x => x.OwnerUserId == userId).ToListAsync();
        }

        public async Task<IReadOnlyList<ClassGroup>> GetSubjectGroupsAsync(Guid subjectId)
        {
            var groupSubjects = await _context.GroupsSubjects.Where(x => x.SubjectId == subjectId).Select(x => x.GroupId).ToListAsync();
            return await _context.ClassGroups.Where(x => groupSubjects.Contains(x.Id)).ToListAsync();
        }

        public async Task RemoveAsync(Subject subject)
        {
            var groupsSubjects = await _context.GroupsSubjects.Where(x => x.SubjectId == subject.Id).ToListAsync();
            foreach(var item in groupsSubjects)
            {
                _context.GroupsSubjects.Remove(item);
            }
            
            var grades = await _context.Grades.Where(x => x.SubjectId == subject.Id).ToListAsync();
            foreach(var item in grades)
            {
                _context.Grades.Remove(item);
            }

            var classSessions = await _context.ClassSessions.Where(x => x.SubjectId == subject.Id).ToListAsync();
            foreach(var item in classSessions)
            {
                _context.ClassSessions.Remove(item);
            }

            _context.Subjects.Remove(subject);
        }
    }
}