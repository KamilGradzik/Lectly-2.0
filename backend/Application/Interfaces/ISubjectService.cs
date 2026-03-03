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
        Task AddSubjectAsync(CreateSubjectDto dto);
        Task<IReadOnlyList<SubjectDto>> GetUserSubjectsAsync();
        Task AttachToClassGroupAsync(SubjectAttachmentDto dto);
        Task DetachFromClassGroupAsync(SubjectAttachmentDto dto);
        Task UpdateSubjectAsync(SubjectDto dto);
        Task RemoveSubjectAsync(Guid subjectId);
    }
}