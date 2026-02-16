using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.Common;
using backend.Application.DTOs.ClassGroup;
using backend.Application.DTOs.Student;
using backend.Application.DTOs.Subject;

namespace backend.Application.Interfaces
{
    public interface IClassGroupService
    {
        Task AddClassGroupAsync(CreateClassGroupDto dto, Guid userId);
        Task <IReadOnlyList<ClassGroupDto>> GetUserClassGroupsAsync(Guid userId);
        Task <PagedResult<StudentDto>> GetClassGroupStudentsAsync(int page, int pageSize, Guid classGroupId, Guid userId);
        Task <IReadOnlyList<SubjectDto>> GetClassGroupSubjectsAsync(Guid classGroupId, Guid userId);
        Task UpdateClassGroupAsync(ClassGroupDto dto, Guid userId);
        Task RemoveClassGroupAsync(Guid classGroupId, Guid userId);
    }
}