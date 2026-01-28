using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities;

namespace backend.Persistence.Repositories
{
    public interface IGradeRepository
    {
        Task AddAsync(Grade grade);
        Task<Grade?> GetAsync(Guid id);
        Task<IReadOnlyList<Grade>> GetStudentGrades(Guid studentId);
        Task RemoveAsync(Grade grade);
    }
}