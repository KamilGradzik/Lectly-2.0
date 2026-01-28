using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities;

namespace backend.Domain.Repositories
{
    public interface IClassSessionRepository
    {
        Task AddAsync(ClassSession classSession);
        Task<ClassSession?> GetAsync(Guid id);
        Task<IReadOnlyList<ClassSession>> GetUserClassSessionsAsync(Guid userId);
        Task<bool> CheckExistingAsync(Guid userId, DayOfWeek dayOfWeek, TimeOnly startTime, TimeOnly endTime);
        Task RemoveAsync(ClassSession classSession);
    }
}