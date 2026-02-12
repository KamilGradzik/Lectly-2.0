using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.DTOs.Grade;

namespace backend.Application.Interfaces
{
    public interface IGradeService
    {
        Task AddGradeAsync(CreateGradeDto dto, Guid userId);
        Task<IReadOnlyList<StudentGradeDto>> GetStudentGradesAsync(Guid studentId, Guid userId);     
        Task UpdateGradeAsync(GradeDto dto, Guid userId);
        Task RemoveGradeAsync(Guid gradeId, Guid userId);
    }
}