using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Persistence.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly AppDbContext _context;
        public GradeRepository(AppDbContext context) { _context = context; }

        public async Task AddAsync(Grade grade)
        {
            _context.Grades.Add(grade);
        }

        public async Task<Grade?> GetAsync(Guid id)
        {
            return await _context.Grades.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<Grade>> GetStudentGrades(Guid studentId)
        {
            return await _context.Grades.Where(x => x.StudentId == studentId).ToListAsync();
        }

        public async Task RemoveAsync(Grade grade)
        {
            _context.Grades.Remove(grade);
        }
    }
}