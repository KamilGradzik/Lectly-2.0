using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Repositories;
using backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Persistence.Repositories
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

        public async Task<IReadOnlyList<Student>> GetGroupStudentsAsync(Guid groupId)
        {
            return await _context.Students.Where(x => x.GroupId == groupId).ToListAsync();
        }

        public async Task RemoveAsync(Student student)
        {
            _context.Students.Remove(student);
        }
    }
}