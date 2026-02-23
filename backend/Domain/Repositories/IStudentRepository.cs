using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.Common;
using backend.Entities;

namespace backend.Domain.Repositories
{
    public interface IStudentRepository
    {
        Task AddAsync(Student student);
        Task<Student?> GetAsync(Guid id);
        Task<PagedResult<Student>> GetUserStudentsAsync(Guid userId, int page, int pageSize);
        Task<IReadOnlyList<ClassGroup>> GetStudentClassGroupsAsync(Guid studentId);
        Task AttachToGroupAsync(Guid studentId, Guid groupId);
        Task DetachFromGroupAsync(Guid studentId, Guid groupId);
        Task<bool> CheckForAttachmentAsync(Guid studentId, Guid groupId);
        Task RemoveAsync(Student student);
    }
}