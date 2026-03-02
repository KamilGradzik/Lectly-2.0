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
        Task AddClassGroupAsync(CreateClassGroupDto dto);
        Task <IReadOnlyList<ClassGroupDto>> GetUserClassGroupsAsync();
        Task <PagedResult<StudentDto>> GetClassGroupStudentsAsync(int page, int pageSize, Guid classGroupId);
        Task <IReadOnlyList<SubjectDto>> GetClassGroupSubjectsAsync(Guid classGroupId);
        Task UpdateClassGroupAsync(ClassGroupDto dto);
        Task RemoveClassGroupAsync(Guid classGroupId);
    }
}