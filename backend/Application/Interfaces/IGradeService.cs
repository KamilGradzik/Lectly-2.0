using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.DTOs.Grade;

namespace backend.Application.Interfaces
{
    public interface IGradeService
    {
        Task AddGradeAsync(CreateGradeDto dto);
        Task<IReadOnlyList<StudentGradeDto>> GetStudentGradesAsync(Guid studentId);     
        Task UpdateGradeAsync(GradeDto dto);
        Task RemoveGradeAsync(Guid gradeId);
    }
}