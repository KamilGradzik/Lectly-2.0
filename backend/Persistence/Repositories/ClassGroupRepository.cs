using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Repositories;
using backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Persistence.Repositories
{
    public class ClassGroupRepository : IClassGroupRepository
    {
        private readonly AppDbContext _context;
        public ClassGroupRepository(AppDbContext context) { _context = context; }

        public async Task AddAsync(ClassGroup classGroup)
        {
            _context.ClassGroups.Add(classGroup);
        }

        public async Task<ClassGroup?> GetAsync(Guid id)
        {
            return await _context.ClassGroups.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<ClassGroup>>GetUserClassGroupsAsync(Guid userId)
        {
            return await _context.ClassGroups.Where(x => x.OwnerUserId == userId).ToListAsync();
        }

        public async Task<IReadOnlyList<Subject>>GetGroupSubjectsAsync(Guid groupId)
        {
            var subjects = await _context.GroupsSubjects.Where(x => x.GroupId == groupId).Select(y => y.SubjectId).ToListAsync();
            return await _context.Subjects.Where(x => subjects.Contains(x.Id)).ToListAsync();
        }
        public async Task AttachSubjectAsync(Guid groupId, Guid subjectId)
        {
            _context.GroupsSubjects.Add(new GroupSubject(groupId, subjectId));
        }
        public async Task DetachSubjectAsync(Guid groupId, Guid subjectId)
        {
            var groupSubject = await _context.GroupsSubjects.FirstOrDefaultAsync(x => x.GroupId == groupId && x.SubjectId == subjectId);
            _context.GroupsSubjects.Remove(groupSubject);
        }
        public async Task<bool> CheckSubjectAttachmentAsync(Guid groupId, Guid subjectId)
        {
            return await _context.GroupsSubjects.AnyAsync(x => x.GroupId == groupId && x.SubjectId == subjectId);
        }
        public async Task RemoveAsync(ClassGroup classGroup)
        {
            _context.ClassGroups.Remove(classGroup);
        }
    }       
}