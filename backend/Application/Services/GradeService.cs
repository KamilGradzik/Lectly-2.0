using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.Common;
using backend.Application.DTOs.Grade;
using backend.Application.DTOs.Subject;
using backend.Application.Interfaces;
using backend.Domain.Repositories;
using backend.Entities;

namespace backend.Application.Services
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepo;
        private readonly ISubjectRepository _subjectRepo;
        private readonly IStudentRepository _studentRepo;
        private readonly IUnitOfWork _unitRepo;

        public GradeService(IGradeRepository gradeRepo, ISubjectRepository subjectRepository, IUnitOfWork unitRepo, IStudentRepository studentRepo)
        {
            _gradeRepo = gradeRepo;
            _subjectRepo = subjectRepository;
            _studentRepo = studentRepo;
            _unitRepo = unitRepo;
        }

        public async Task AddGradeAsync(CreateGradeDto dto, Guid userId)
        {
            var subject = await _subjectRepo.GetAsync(dto.SubjectId);
            var student = await _studentRepo.GetAsync(dto.StudentId);
            
            if(subject == null)
                throw new NotFoundException("Cannot find subject with specified Id!");
            
            if(subject.OwnerUserId != userId)
                throw new UnauthorizedException("Unauthorized access to specified subject!");
            
            if(student == null)
                throw new NotFoundException("Cannot find student with specified Id!");
            
            if(student.OwnerUserId != userId)
                throw new UnauthorizedException("Unauthorized access to specified student!");

            var subjectGroups = await _subjectRepo.GetSubjectGroupsAsync(dto.SubjectId);
            var studentGroups = await _studentRepo.GetStudentClassGroupsAsync(dto.StudentId);

            if(!subjectGroups.Any(x => studentGroups.Select(y => y.Id).ToList().Contains(x.Id)))
                throw new NotFoundException("Specified subject Doesnt't belong to any group that student Does!");

            await _gradeRepo.AddAsync(new Grade(dto.Value, dto.Weight, dto.Desc, dto.DateIssued, dto.SubjectId, dto.StudentId, userId));
            await _unitRepo.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<StudentGradeDto>> GetStudentGradesAsync(Guid studentId, Guid userId)
        {
            var student = await _studentRepo.GetAsync(studentId);
            if(student == null)
                throw new NotFoundException("Cannot find student with specified Id!");
            
            if(student.OwnerUserId != userId)
                throw new UnauthorizedException("Unauthorized access to specified student!");

            var grades = await _gradeRepo.GetStudentGradesAsync(studentId);
            var studentGrades = new List<StudentGradeDto>();
            foreach (var grade in grades)
            {
                var subject = await _subjectRepo.GetAsync(grade.SubjectId); 
                var studentGrade = new StudentGradeDto{
                    Id = grade.Id,
                    Value = grade.Value,
                    Weight = grade.Weight,
                    Desc = grade.Desc,
                    DateIssued = grade.DateIssued,
                };
            
                if(subject != null)
                {
                    studentGrade.Subject = new SubjectDto
                    {
                        Id = subject.Id,
                        Name = subject.Name,
                        Desc = subject.Desc,
                    };
                }   
                else studentGrade.Subject = null;
                
                studentGrades.Add(studentGrade);
            }
            return studentGrades;
        }

        public async Task UpdateGradeAsync(GradeDto dto, Guid userId)
        {
            var subject = await _subjectRepo.GetAsync(dto.SubjectId);
            var grade = await _gradeRepo.GetAsync(dto.Id);
            
            if(subject == null)
                throw new NotFoundException("Cannot find subject with specified Id!");
            
            if(subject.OwnerUserId != userId)
                throw new UnauthorizedException("Unauthorized access to specified subject!");

            if(grade == null)
                throw new NotFoundException("Cannot find grade with specified Id!");
            
            if(grade.OwnerUserId != userId)
                throw new UnauthorizedException("Unauthorized access to specified grade!");
                
            grade.SetValue(dto.Value);
            grade.SetWeight(dto.Weight);
            grade.AssignSubject(dto.SubjectId);
            grade.UpdateDescription(dto.Desc);
            
            await _unitRepo.SaveChangesAsync();
        }

        public async Task RemoveGradeAsync(Guid gradeId, Guid userId)
        {
            var grade = await _gradeRepo.GetAsync(gradeId);
            
            if(grade == null)
                throw new NotFoundException("Cannot find grade with specified Id!");
            
            if(grade.OwnerUserId != userId)
                throw new UnauthorizedException("Unauthorized access to specified grade!");

            await _gradeRepo.RemoveAsync(grade);
            await _unitRepo.SaveChangesAsync();
        }
    }
}