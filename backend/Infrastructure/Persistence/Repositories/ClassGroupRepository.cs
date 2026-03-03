using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.Common;
using backend.Domain.Repositories;
using backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Infrastructure.Persistence.Repositories
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

        public async Task<IReadOnlyList<Subject>>GetClassGroupSubjectsAsync(Guid groupId)
        {
            var subjects = await _context.GroupsSubjects.Where(x => x.GroupId == groupId).Select(y => y.SubjectId).ToListAsync();
            return await _context.Subjects.Where(x => subjects.Contains(x.Id)).ToListAsync();
        }

        public async Task<PagedResult<Student>>GetClassGroupStudentsAsync(int page, int pageSize, Guid groupId)
        {
            var groupStudents = await _context.GroupsStudents.Where(x => x.GroupId == groupId).Skip((page - 1) * pageSize).Take(pageSize).Select(x => x.StudentId).ToListAsync();
            var students = await _context.Students.Where(x => groupStudents.Contains(x.Id)).ToListAsync();
            var total = await _context.GroupsStudents.Where(x => x.GroupId == groupId).CountAsync();

            return new PagedResult<Student>(students, page, pageSize, total);
        }
        
        public async Task RemoveAsync(ClassGroup classGroup)
        {
            var groupsSubjects = await _context.GroupsSubjects.Where(x => x.GroupId == classGroup.Id).ToListAsync();
            foreach(var item in groupsSubjects)
            {
                _context.GroupsSubjects.Remove(item);
            }

            var groupsStudens = await _context.GroupsStudents.Where(x => x.GroupId == classGroup.Id).ToListAsync();
            foreach(var item in groupsStudens)
            {
                _context.GroupsStudents.Remove(item);
            }
            
            _context.ClassGroups.Remove(classGroup);
        }
    }       
}