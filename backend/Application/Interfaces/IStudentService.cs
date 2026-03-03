using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.Common;
using backend.Application.DTOs.ClassGroup;
using backend.Application.DTOs.Student;
using backend.Entities;

namespace backend.Application.Interfaces
{
    public interface IStudentService
    {
        Task AddStudentAsync(CreateStudentDto dto);
        Task<PagedResult<StudentDto>>GetUserStudentsAsync(int page, int pageSize);
        Task<IReadOnlyList<ClassGroupDto>> GetStudentClassGroupsAsync(Guid studentId);
        Task AttachToClassGroupAsync(StudentAttachmentDto dto);
        Task DetachFromClassGroupAsync(StudentAttachmentDto dto);
        Task UpdateStudentAsync(StudentDto dto);
        Task RemoveStudentAsync(Guid studentId);
    }
}