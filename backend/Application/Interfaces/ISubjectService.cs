using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.DTOs.Subject;
using backend.Entities;

namespace backend.Application.Interfaces
{
    public interface ISubjectService
    {
        Task AddSubjectAsync(CreateSubjectDto dto, Guid userId);
        Task<IReadOnlyList<SubjectDto>> GetUserSubjectsAsync(Guid userId);
        Task UpdateSubjectAsync(SubjectDto dto, Guid userId);
        Task RemoveSubjectAsync(Guid subjectId, Guid userId);
    }
}