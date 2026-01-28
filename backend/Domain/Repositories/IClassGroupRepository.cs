using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using backend.Entities;

namespace backend.Domain.Repositories
{
    public interface IClassGroupRepository
    {
        Task AddAsync(ClassGroup classGroup);
        Task<ClassGroup?> GetAsync(Guid id);
        Task<IReadOnlyList<ClassGroup>>GetUserClassGroupsAsync(Guid userId);
        Task<IReadOnlyList<Subject>>GetGroupSubjectsAsync(Guid groupId);
        Task AttachSubjectAsync(Guid groupId, Guid subjectId);
        Task DetachSubjectAsync(Guid groupId, Guid subjectId);
        Task<bool> CheckSubjectAttachmentAsync(Guid groupId, Guid subjectId);
        Task RemoveAsync(ClassGroup classGroup);
    }
}