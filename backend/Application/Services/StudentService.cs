using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.Common;
using backend.Application.DTOs.ClassGroup;
using backend.Application.DTOs.Student;
using backend.Application.Interfaces;
using backend.Domain.Repositories;
using backend.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            await _studentRepo.AddAsync(new Student(dto.StudentCode, dto.FirstName, dto.LastName, userId, dto.AdditionalInfo));
            await _unitRepo.SaveChangesAsync();
        }

        public async Task<PagedResult<StudentDto>> GetUserStudentsAsync(Guid userId, int page, int pageSize)
        {
            var result = await _studentRepo.GetUserStudentsAsync(userId, page, pageSize);
            var students = new List<StudentDto>();
            foreach (var item in result.Items)
            {
                students.Add(new StudentDto
                {
                    Id = item.Id,
                    StudentCode = item.StudentCode,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    AdditionalInfo = item.AdditionalInfo,
                });
            }
            
            return new PagedResult<StudentDto>(students, page, pageSize, result.TotalCount);
        }
        
        public async Task<IReadOnlyList<ClassGroupDto>> GetStudentClassGroupsAsync(Guid studentId, Guid userId)
        {
            var student = await _studentRepo.GetAsync(studentId);
            if(student == null)
                throw new ArgumentException("Cannot find class group with specified Id!");
            
            if(student.OwnerUserId != userId)
                throw new UnauthorizedAccessException("Unauthorized access to specified student!");
            
            var classGroups = await _studentRepo.GetStudentClassGroupsAsync(student.Id);
            var classGroupsList = new List<ClassGroupDto>();
            foreach (var classGroup in classGroups)
            {
                classGroupsList.Add(new ClassGroupDto{
                    Id = classGroup.Id,
                    Name = classGroup.Name,
                    Desc = classGroup.Desc,
                });
            }

            return classGroupsList;
        }

        public async Task AttachToGroupAsync(Guid studentId, Guid groupId, Guid userId)
        {
            var student = await _studentRepo.GetAsync(studentId);
            if(student == null)
                throw new ArgumentException("Cannot find student with specified Id!");
            
            if(student.OwnerUserId != userId)
                throw new UnauthorizedAccessException("Unauthorized access to specified student!");
            
            var group = await _classGroupRepo.GetAsync(groupId);
            if(group == null)
                throw new ArgumentException("Cannot find student with specified Id!");

            if(group.OwnerUserId != userId)
                throw new UnauthorizedAccessException("Unauthorized access to specified student!");

            if(await _studentRepo.CheckForAttachmentAsync(studentId, groupId))
                throw  new ArgumentException("Student Is already attached to the group!");
            
            await _studentRepo.AttachToGroupAsync(studentId, groupId);
            await _unitRepo.SaveChangesAsync();

        }

        public async Task DetachFromGroupAsync(Guid studentId, Guid groupId, Guid userId)
        {
            var student = await _studentRepo.GetAsync(studentId);
            if(student == null)
                throw new ArgumentException("Cannot find student with specified Id!");
            
            if(student.OwnerUserId != userId)
                throw new UnauthorizedAccessException("Unauthorized access to specified student!");
            
            var group = await _classGroupRepo.GetAsync(groupId);
            if(group == null)
                throw new ArgumentException("Cannot find student with specified Id!");
            
            if(group.OwnerUserId != userId)
                throw new UnauthorizedAccessException("Unauthorized access to specified student!");
            
            if(!await _studentRepo.CheckForAttachmentAsync(studentId, groupId))
                throw  new ArgumentException("Student Is already detached to the group!");

            await _studentRepo.DetachFromGroupAsync(studentId, groupId);
            await _unitRepo.SaveChangesAsync();

        }

        public async Task UpdateStudentAsync(StudentDto dto, Guid userId)
        {
            var student = await _studentRepo.GetAsync(dto.Id);
            if(student == null)
                throw new ArgumentException("Cannot find student with specified Id!");
            
            if(student.OwnerUserId != userId)
                throw new UnauthorizedAccessException("Unauthorized access to specified student!");
            
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
            
            if(student.OwnerUserId != userId)
                throw new UnauthorizedAccessException("Unauthorized access to specified student!");
            
            await _studentRepo.RemoveAsync(student);
            await _unitRepo.SaveChangesAsync();
        }
    }
}