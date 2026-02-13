using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.DTOs.ClassGroup;
using backend.Application.DTOs.ClassSession;
using backend.Application.DTOs.Subject;
using backend.Application.Interfaces;
using backend.Domain.Repositories;
using backend.Entities;

namespace backend.Application.Services
{
    public class ClassSessionService : IClassSessionService
    {
        private readonly IClassSessionRepository _classSessionRepo;
        private readonly IClassGroupRepository _classGroupRepo;
        private readonly ISubjectRepository _subjectRepo;
        private readonly IUnitOfWork _unitRepo;

        public ClassSessionService (IClassSessionRepository classSessionRepo, IClassGroupRepository classGroupRepo, ISubjectRepository subjectRepo, IUnitOfWork unitRepo)
        {
            _classSessionRepo = classSessionRepo;
            _classGroupRepo = classGroupRepo;
            _subjectRepo = subjectRepo;  
            _unitRepo = unitRepo;     
        }

        public async Task AddClassSessionAsync(CreateClassSessionDto dto, Guid userId)
        {
            var group = await _classGroupRepo.GetAsync(dto.ClassGroupId);
            var subject = await _subjectRepo.GetAsync(dto.SubjectId);

            if(group == null)
                throw new ArgumentException("Cannot find student with specified Id!");

            if(group.OwnerUserId != userId)
                throw new UnauthorizedAccessException("Unauthorized access to specified student!");

            if(subject == null)
                throw new ArgumentException("Cannot find subject with specified Id!");
            
            if(subject.OwnerUserId != userId)
                throw new UnauthorizedAccessException("Unauthorized access to specified subject!");

            if(!await _classGroupRepo.CheckSubjectAttachmentAsync(dto.ClassGroupId, dto.SubjectId))
                throw  new ArgumentException("Specified subject Isn't attached to the group!");

            if(await _classSessionRepo.CheckExistingAsync(userId, dto.DayOfWeek, dto.StartTime, dto.EndTime))
                throw  new ArgumentException("There are already scheduled classes during specified period of time!");
            
            var classSession = new ClassSession(dto.DayOfWeek, dto.StartTime, dto.EndTime, dto.Classroom, dto.ClassGroupId, dto.SubjectId, userId);

            await _classSessionRepo.AddAsync(classSession);
            await _unitRepo.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<ClassSessionDto>> GetUserClassSessionsAsync(Guid userId)
        {
            var classSessions = await _classSessionRepo.GetUserClassSessionsAsync(userId);
            var userClassSessions = new List<ClassSessionDto>();
            foreach (var classSession in classSessions)
            {
                var subject = await _subjectRepo.GetAsync(classSession.SubjectId);
                var group = await _classGroupRepo.GetAsync(classSession.GroupId);

                var dto = new ClassSessionDto
                {
                    Id = classSession.Id,
                    DayOfWeek = classSession.DayOfWeek,
                    StartTime = classSession.StartTime,
                    EndTime = classSession.EndTime,
                    Classroom = classSession.Classroom
                };

                if(subject != null)
                {
                    dto.Subject = new SubjectDto
                    {
                        Id = subject.Id,
                        Name = subject.Name,
                        Desc = subject.Desc
                    };
                }
                else dto.Subject = null;

                if(group != null)
                {
                    dto.ClassGroup = new ClassGroupDto
                    {
                        Id = group.Id,
                        Name = group.Name,
                        Desc = group.Desc
                    };
                }
                else dto.ClassGroup = null;

                userClassSessions.Add(dto);
            }

            return userClassSessions;
        }

        public async Task UpdateClassSessionAsync(UpdateClassSessionDto dto, Guid userId)
        {
            var group = await _classGroupRepo.GetAsync(dto.ClassGroupId);
            var subject = await _subjectRepo.GetAsync(dto.SubjectId);
            var classSession = await _classSessionRepo.GetAsync(dto.Id);
            
            if(classSession == null)
                throw new ArgumentException("Cannot find class session with specified Id!");

            if(classSession.OwnerUserId != userId)
                throw new UnauthorizedAccessException("Unauthorized access to specified class session!");

            if(group == null)
                throw new ArgumentException("Cannot find student with specified Id!");

            if(group.OwnerUserId != userId)
                throw new UnauthorizedAccessException("Unauthorized access to specified student!");

            if(subject == null)
                throw new ArgumentException("Cannot find subject with specified Id!");
            
            if(subject.OwnerUserId != userId)
                throw new UnauthorizedAccessException("Unauthorized access to specified subject!");

            if(!await _classGroupRepo.CheckSubjectAttachmentAsync(dto.ClassGroupId, dto.SubjectId))
                throw  new ArgumentException("Specified subject Isn't attached to the group!");

            if(await _classSessionRepo.CheckExistingAsync(userId, dto.DayOfWeek, dto.StartTime, dto.EndTime))
                throw  new ArgumentException("There are already scheduled classes during specified period of time!");
            
            classSession.ChangeDayOfWeek(dto.DayOfWeek);
            classSession.UpdateClassroom(dto.Classroom);
            classSession.UpdateClassTime(dto.StartTime, dto.EndTime);
            classSession.AssignGroup(dto.ClassGroupId);
            classSession.AssignSubject(dto.SubjectId);
            
            await _unitRepo.SaveChangesAsync();
        }

        public async Task RemoveClassSessionAsync(Guid classSessionId, Guid userId)
        {
            var classSession = await _classSessionRepo.GetAsync(classSessionId);
            
            if(classSession == null)
                throw new ArgumentException("Cannot find class session with specified Id!");

            if(classSession.OwnerUserId != userId)
                throw new UnauthorizedAccessException("Unauthorized access to specified class session!");
            
            await _classSessionRepo.RemoveAsync(classSession);
            await _unitRepo.SaveChangesAsync();
        }
    }
}