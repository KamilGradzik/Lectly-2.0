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
        private readonly ICurrentUserService _currentUser;
        private readonly IStudentRepository _studentRepo;
        private readonly IClassGroupRepository _classGroupRepo;
        private readonly IUnitOfWork _unitRepo;

        public StudentService(ICurrentUserService currentUser, IStudentRepository studentRepo, IClassGroupRepository classGroupRepo, IUnitOfWork unitRepo)
        {
            _currentUser = currentUser;
            _studentRepo = studentRepo;
            _classGroupRepo = classGroupRepo;
            _unitRepo = unitRepo; 
        }

        public async Task AddStudentAsync(CreateStudentDto dto)
        {
            await _studentRepo.AddAsync(new Student(dto.StudentCode, dto.FirstName, dto.LastName, _currentUser.UserId, dto.AdditionalInfo));
            await _unitRepo.SaveChangesAsync();
        }

        public async Task<PagedResult<StudentDto>> GetUserStudentsAsync(int page, int pageSize)
        {
            var result = await _studentRepo.GetUserStudentsAsync(_currentUser.UserId, page, pageSize);
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
        
        public async Task<IReadOnlyList<ClassGroupDto>> GetStudentClassGroupsAsync(Guid studentId)
        {
            var student = await _studentRepo.GetAsync(studentId);
            if(student == null)
                throw new NotFoundException("Cannot find student with specified Id!");
            
            if(student.OwnerUserId != _currentUser.UserId)
                throw new UnauthorizedException("Unauthorized access to specified student!");
            
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

        public async Task AttachToClassGroupAsync(StudentAttachmentDto dto)
        {
            var student = await _studentRepo.GetAsync(dto.StudentId);
            if(student == null)
                throw new NotFoundException("Cannot find student with specified Id!");
            
            if(student.OwnerUserId != _currentUser.UserId)
                throw new UnauthorizedException("Unauthorized access to specified student!");
            
            var group = await _classGroupRepo.GetAsync(dto.ClassGroupId);
            if(group == null)
                throw new NotFoundException("Cannot find class group with specified Id!");

            if(group.OwnerUserId != _currentUser.UserId)
                throw new UnauthorizedException("Unauthorized access to specified class group!");

            if(await _studentRepo.CheckForAttachmentAsync(dto.ClassGroupId, dto.StudentId))
                throw  new ValidationException("Student Is already attached to the class group!");
            
            await _studentRepo.AttachToClassGroupAsync(dto.ClassGroupId, dto.StudentId);
            await _unitRepo.SaveChangesAsync();

        }

        public async Task DetachFromClassGroupAsync(StudentAttachmentDto dto)
        {
            var student = await _studentRepo.GetAsync(dto.StudentId);
            if(student == null)
                throw new NotFoundException("Cannot find student with specified Id!");
            
            if(student.OwnerUserId != _currentUser.UserId)
                throw new UnauthorizedException("Unauthorized access to specified student!");
            
            var group = await _classGroupRepo.GetAsync(dto.ClassGroupId);
            if(group == null)
                throw new NotFoundException("Cannot find class group with specified Id!");
            
            if(group.OwnerUserId != _currentUser.UserId)
                throw new UnauthorizedException("Unauthorized access to specified class group!");
            
            if(!await _studentRepo.CheckForAttachmentAsync(dto.ClassGroupId, dto.StudentId))
                throw  new ValidationException("Student Is already detached from the class group!");

            await _studentRepo.DetachFromClassGroupAsync(dto.ClassGroupId, dto.StudentId);
            await _unitRepo.SaveChangesAsync();

        }

        public async Task UpdateStudentAsync(StudentDto dto)
        {
            var student = await _studentRepo.GetAsync(dto.Id);
            if(student == null)
                throw new NotFoundException("Cannot find student with specified Id!");
            
            if(student.OwnerUserId != _currentUser.UserId)
                throw new UnauthorizedException("Unauthorized access to specified student!");
            
            student.AssignStudentCode(dto.StudentCode);
            student.UpdateFirstName(dto.FirstName);
            student.UpdateLastName(dto.LastName);
            student.UpdateAdditionalInfo(dto.AdditionalInfo);
            
            await _unitRepo.SaveChangesAsync();
        }

        public async Task RemoveStudentAsync(Guid studentId)
        {
            var student = await _studentRepo.GetAsync(studentId);
            if(student == null)
                throw new NotFoundException("Cannot find student with specified Id!");
            
            if(student.OwnerUserId != _currentUser.UserId)
                throw new UnauthorizedException("Unauthorized access to specified student!");
            
            await _studentRepo.RemoveAsync(student);
            await _unitRepo.SaveChangesAsync();
        }
    }
}