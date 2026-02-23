using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.Common;
using backend.Domain.Entities;
using backend.Domain.Repositories;
using backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Infrastructure.Persistence.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context) { _context = context; }

        public async Task AddAsync(Student student)
        {
            _context.Students.Add(student);
        }

        public async Task<Student?> GetAsync(Guid id)
        {
            return await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PagedResult<Student>> GetUserStudentsAsync(Guid userId, int page, int pageSize)
        {
            var totalCount  = await _context.Students.Where(x => x.OwnerUserId == userId).CountAsync();
            var students = await _context.Students.Where(x => x.OwnerUserId == userId).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedResult<Student>(students, page, pageSize, totalCount);
        }

        public async Task<IReadOnlyList<ClassGroup>> GetStudentClassGroupsAsync(Guid studentId)
        {
            var groups = await _context.GroupsStudents.Where(x => x.StudentId == studentId).Select(x => x.GroupId).ToListAsync();
            return await _context.ClassGroups.Where(x => groups.Contains(x.Id)).ToListAsync();
        }
        
        public async Task AttachToGroupAsync(Guid groupId, Guid studentId)
        {
            _context.GroupsStudents.Add(new GroupStudent(groupId, studentId));
        }

        public async Task DetachFromGroupAsync(Guid groupId, Guid studentId)
        {
            var groupStudent = await _context.GroupsStudents.FirstOrDefaultAsync(x => x.GroupId == groupId && x.StudentId == studentId);
            if(groupStudent != null)
                _context.GroupsStudents.Remove(groupStudent);
        }

        public async Task<bool> CheckForAttachmentAsync(Guid groupId, Guid StudentId)
        {
            return await _context.GroupsStudents.AnyAsync(x => x.GroupId == groupId && x.StudentId == StudentId);
        }

        public async Task RemoveAsync(Student student)
        {
            var groupsStudents = await _context.GroupsStudents.Where(x => x.StudentId == student.Id).ToListAsync();
            foreach(var item in groupsStudents)
            {
                _context.GroupsStudents.Remove(item);
            }

            var grades = await _context.Grades.Where(x => x.StudentId == student.Id).ToListAsync();
            foreach(var item in grades)
            {
                _context.Grades.Remove(item);
            }

            _context.Students.Remove(student);
        }
    }
}