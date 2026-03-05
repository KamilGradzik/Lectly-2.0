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
        Task AddClassSessionAsync(CreateClassSessionDto dto);
        Task<IReadOnlyList<ClassSessionDto>>GetUserClassSessionsAsync();
        Task UpdateClassSessionAsync(UpdateClassSessionDto dto);
        Task RemoveClassSessionAsync(Guid classSessionId);
    }
}