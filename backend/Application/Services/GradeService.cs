using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.DTOs.Grade;
using backend.Application.Interfaces;
using backend.Domain.Repositories;
using backend.Persistence.Repositories;

namespace backend.Application.Services
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepo;
        private readonly ISubjectRepository _subjectRepo;
        private readonly IStudentRepository _studentRepo;
        private readonly IUnitOfWork _unitRepo;

        public GradeService(IGradeRepository gradeRepo, ISubjectRepository subjectRepository, IUnitOfWork unitRepo)
        {
            _gradeRepo = gradeRepo;
            _subjectRepo = subjectRepository;
            _unitRepo = unitRepo;
        }

        public async Task AddGradeAsync(CreateGradeDto dto, Guid userId)
        {
            
        }
    }
}