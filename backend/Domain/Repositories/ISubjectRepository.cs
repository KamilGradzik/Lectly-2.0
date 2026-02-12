using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities;

namespace backend.Domain.Repositories
{
    public interface ISubjectRepository
    {
        Task AddAsync(Subject subject);
        Task<Subject?> GetAsync(Guid id);
        Task<IReadOnlyList<Subject>> GetUserSubjectsAsync(Guid userId);
        Task<IReadOnlyList<ClassGroup>> GetSubjectGroupsAsync(Guid subjectId);
        Task RemoveAsync(Subject subject);
    }
}