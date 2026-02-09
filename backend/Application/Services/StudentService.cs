using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.DTOs.Student;
using backend.Application.Interfaces;
using backend.Domain.Repositories;
using backend.Entities;

namespace backend.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepo;
        private readonly IClassGroupRepository _classGroupRepo;
        private readonly IUnitOfWork _unitRepo;

        public StudentService(IStudentRepository studentRepo, IClassGroupRepository classGroupRepo, IUnitOfWork unitRepo)
        {
            _studentRepo = studentRepo;
            _classGroupRepo = classGroupRepo;
            _unitRepo = unitRepo; 
        }

        public async Task AddStudentAsync(CreateStudentDto dto, Guid userId)
        {
            var group = await _classGroupRepo.GetAsync(dto.GroupId);
            if(group == null)
                throw new ArgumentException("Cannot find class group with specified Id!");
            
            if(group.OwnerUserId != userId)
                throw new UnauthorizedAccessException("Unauthorized access to specified class group!");
            
            await _studentRepo.AddAsync(
                new Student(dto.StudentCode, dto.FirstName, dto.LastName, dto.GroupId, dto.AdditionalInfo));
        }

        public async Task<IReadOnlyList<StudentDto>> GetClassGroupStudentsAsync(Guid groupId, Guid userId)
        {
            var group = await _classGroupRepo.GetAsync(groupId);
            if(group == null)
                throw new ArgumentException("Cannot find class group with specified Id!");
            
            if(group.OwnerUserId != userId)
                throw new UnauthorizedAccessException("Unauthorized access to specified class group!");
            
            var students = await _studentRepo.GetGroupStudentsAsync(groupId);
            var studentsList = new List<StudentDto>();
            foreach (var student in students)
            {
                studentsList.Add(new StudentDto{
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    AdditionalInfo = student.AdditionalInfo
                });
            }

            return studentsList;
        }

        public async Task UpdateStudentAsync(StudentDto dto, Guid userId)
        {
            var student = await _studentRepo.GetAsync(dto.Id);
            if(student == null)
                throw new ArgumentException("Cannot find student with specified Id!");
            
            var group = await _classGroupRepo.GetAsync(student.GroupId);
            if(group == null)
                throw new ArgumentException("Cannot find class group with specified Id!");
            
            if(group.OwnerUserId != userId)
                throw new UnauthorizedAccessException("Unauthorized access to specified class group!");
            
            student.AssignStudentCode(dto.StudentCode);
            student.UpdateFirstName(dto.FirstName);
            student.UpdateLastName(dto.LastName);
            student.UpdateAdditionalInfo(dto.AdditionalInfo);
            
            await _unitRepo.SaveChangesAsync();
        }

        public async Task RemoveStudentAsync(Guid studentId, Guid userId)
        {
            var student = await _studentRepo.GetAsync(studentId);
            if(student == null)
                throw new ArgumentException("Cannot find student with specified Id!");
            
            var group = await _classGroupRepo.GetAsync(student.GroupId);
            if(group == null)
                throw new ArgumentException("Cannot find class group with specified Id!");
            
            if(group.OwnerUserId != userId)
                throw new UnauthorizedAccessException("Unauthorized access to specified class group!");
            
            await _studentRepo.RemoveAsync(student);
            await _unitRepo.SaveChangesAsync();
        }
    }
}