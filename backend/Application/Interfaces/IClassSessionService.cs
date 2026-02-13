using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.DTOs.ClassSession;
using backend.Entities;

namespace backend.Application.Interfaces
{
    public interface IClassSessionService
    {
        Task AddClassSessionAsync(CreateClassSessionDto dto, Guid userId);
        Task<IReadOnlyList<ClassSessionDto>>GetUserClassSessionsAsync(Guid userId);
        Task UpdateClassSessionAsync(UpdateClassSessionDto dto, Guid userId);
        Task RemoveClassSessionAsync(Guid classSessionId, Guid userId);
    }
}