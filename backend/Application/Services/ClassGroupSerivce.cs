using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.Common;
using backend.Application.DTOs.ClassGroup;
using backend.Application.DTOs.Student;
using backend.Application.DTOs.Subject;
using backend.Application.Interfaces;
using backend.Domain.Repositories;
using backend.Entities;

namespace backend.Application.Services
{
    public class ClassGroupSerivce : IClassGroupService
    {
        private readonly IClassGroupRepository _classGroupRepo;
        private readonly IUnitOfWork _unitRepo;

        public ClassGroupSerivce(IClassGroupRepository classGroupRepo, IUnitOfWork unitRepo)
        {
            _classGroupRepo = classGroupRepo;
            _unitRepo = unitRepo;
        }

        public async Task AddClassGroupAsync(CreateClassGroupDto dto, Guid userId)
        {
            await _classGroupRepo.AddAsync(new ClassGroup(dto.Name, userId, dto.Desc));
            await _unitRepo.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<ClassGroupDto>> GetUserClassGroupsAsync(Guid userId)
        {
            var classGroups = await _classGroupRepo.GetUserClassGroupsAsync(userId);
            var userClassGroups = new List<ClassGroupDto>();
            foreach(var classGroup in classGroups)
            {
                userClassGroups.Add(new ClassGroupDto
                {
                    Id = classGroup.Id,
                    Name = classGroup.Name,
                    Desc = classGroup.Desc
                });
            }
            return userClassGroups;
        }

        public async Task<PagedResult<StudentDto>> GetClassGroupStudentsAsync(int page, int pageSize, Guid classGroupId, Guid userId)
        {
            var classGroup = await _classGroupRepo.GetAsync(classGroupId);
            if(classGroup == null)
                throw new ArgumentException("Cannot find class group with specified Id!");

            if(classGroup.OwnerUserId != userId)
                throw new UnauthorizedAccessException("Unauthorized access to specified class group!");
            
            var result = await _classGroupRepo.GetClassGroupStudentsAsync(page, pageSize, classGroupId);
            var classGroupStudents = new List<StudentDto>();
            foreach (var student in result.Items)
            {
                classGroupStudents.Add(new StudentDto
                {
                    Id = student.Id,
                    StudentCode = student.StudentCode,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    AdditionalInfo = student.AdditionalInfo
                });
            }
            return new PagedResult<StudentDto>(classGroupStudents, page, pageSize, result.TotalCount);
        }

        public async Task<IReadOnlyList<SubjectDto>> GetClassGroupSubjectsAsync(Guid classGroupId, Guid userId)
        {
            var classGroup = await _classGroupRepo.GetAsync(classGroupId);
            if(classGroup == null)
                throw new ArgumentException("Cannot find class group with specified Id!");

            if(classGroup.OwnerUserId != userId)
                throw new UnauthorizedAccessException("Unauthorized access to specified class group!");
            
            var result = await _classGroupRepo.GetClassGroupSubjectsAsync(classGroupId);
            var classGroupSubjects = new List<SubjectDto>();
            foreach (var subject in classGroupSubjects)
            {
                classGroupSubjects.Add(new SubjectDto
                {
                    Id = subject.Id,
                    Name = subject.Name,
                    Desc = subject.Desc
                });
            }
            return classGroupSubjects;
        }

        public async Task UpdateClassGroupAsync(ClassGroupDto dto, Guid userId)
        {
            var classGroup = await _classGroupRepo.GetAsync(dto.Id);
            if(classGroup == null)
                throw new ArgumentException("Cannot find class group with specified Id!");

            if(classGroup.OwnerUserId != userId)
                throw new UnauthorizedAccessException("Unauthorized access to specified class group!");
            
            classGroup.Rename(dto.Name);
            classGroup.UpdateDescription(dto.Desc);

            await _unitRepo.SaveChangesAsync();
        }

        public async Task RemoveClassGroupAsync(Guid classGroupId, Guid userId)
        {
            var classGroup = await _classGroupRepo.GetAsync(classGroupId);
            if(classGroup == null)
                throw new ArgumentException("Cannot find class group with specified Id!");

            if(classGroup.OwnerUserId != userId)
                throw new UnauthorizedAccessException("Unauthorized access to specified class group!");

            await _classGroupRepo.RemoveAsync(classGroup);
            await _unitRepo.SaveChangesAsync();
        }
    }
}