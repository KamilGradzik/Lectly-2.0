using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.Common;
using backend.Application.DTOs.Student;
using backend.Entities;

namespace backend.Application.Interfaces
{
    public interface IStudentService
    {
        Task AddStudentAsync(CreateStudentDto dto, Guid userId);
        Task<PagedResult<StudentDto>>GetUserStudentsAsync(Guid userId, int page, int pageSize);
        //TODO - Getting sepcified student groups.
        // Task<IReadOnlyList<StudentDto>> GetClassGroupStudentsAsync(Guid groupId, Guid userId);
        Task AttachToGroupAsync(Guid studentId, Guid GroupId, Guid userId);
        Task DetachToGroupAsync(Guid studentId, Guid GroupId, Guid userId);
        Task UpdateStudentAsync(StudentDto dto, Guid userId);
        Task RemoveStudentAsync(Guid studentId, Guid userId);
    }
}