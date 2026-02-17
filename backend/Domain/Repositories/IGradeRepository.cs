using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities;

namespace backend.Domain.Repositories
{
    public interface IGradeRepository
    {
        Task AddAsync(Grade grade);
        Task<Grade?> GetAsync(Guid id);
        Task<IReadOnlyList<Grade>> GetStudentGradesAsync(Guid studentId);
        Task RemoveAsync(Grade grade);
    }
}