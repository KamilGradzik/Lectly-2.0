using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.Common;
using backend.Application.DTOs.Subject;
using backend.Application.Interfaces;
using backend.Domain.Repositories;
using backend.Entities;

namespace backend.Application.Services
{
    public class SubjectService : ISubjectService
    {   
        private readonly ICurrentUserService _currentUser;
        private readonly IClassGroupRepository _classGroupRepo;
        private readonly ISubjectRepository _subjectRepo;
        private readonly IUnitOfWork _unitRepo;

        public SubjectService(ICurrentUserService currentUser, ISubjectRepository subjectRepo, IClassGroupRepository classGroupRepo, IUnitOfWork unitRepo)
        {
            _currentUser = currentUser;
            _subjectRepo = subjectRepo;
            _classGroupRepo = classGroupRepo;
            _unitRepo = unitRepo;
        }

        public async Task AddSubjectAsync(CreateSubjectDto dto)
        {
            await _subjectRepo.AddAsync(new Subject(dto.Name, _currentUser.UserId, dto.Desc));
            await _unitRepo.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<SubjectDto>> GetUserSubjectsAsync()
        {
            var subjects = await _subjectRepo.GetUserSubjectsAsync(_currentUser.UserId);
            var subjectsList = new List<SubjectDto>();
            foreach (var subject in subjects)
            {
                subjectsList.Add(
                    new SubjectDto {
                            Id = subject.Id, 
                            Name = subject.Name, 
                            Desc = subject.Desc
                        }
                    );
            }

            return subjectsList;
        }

        public async Task AttachToClassGroupAsync(SubjectAttachmentDto dto)
        {
            var subject = await _subjectRepo.GetAsync(dto.SubjectId);
            if(subject == null)
                throw new NotFoundException("Cannot find subject with specified Id!");
            
            if(subject.OwnerUserId != _currentUser.UserId)
                throw new UnauthorizedException("Unauthorized access to specified subject!");
            
            var group = await _classGroupRepo.GetAsync(dto.ClassGroupId);
            if(group == null)
                throw new NotFoundException("Cannot find class group with specified Id!");

            if(group.OwnerUserId != _currentUser.UserId)
                throw new UnauthorizedException("Unauthorized access to specified class group!");

            if(await _subjectRepo.CheckForAttachmentAsync(dto.ClassGroupId, dto.SubjectId))
                throw  new ValidationException("Subject Is already attached to the class group!");
            
            await _subjectRepo.AttachToClassGroupAsync(dto.ClassGroupId, dto.SubjectId);
            await _unitRepo.SaveChangesAsync();

        }

        public async Task DetachFromClassGroupAsync(SubjectAttachmentDto dto)
        {
            var subject = await _subjectRepo.GetAsync(dto.SubjectId);
            if(subject == null)
                throw new NotFoundException("Cannot find subject with specified Id!");
            
            if(subject.OwnerUserId != _currentUser.UserId)
                throw new UnauthorizedException("Unauthorized access to specified subject!");
            
            var group = await _classGroupRepo.GetAsync(dto.ClassGroupId);
            if(group == null)
                throw new NotFoundException("Cannot find group with specified Id!");
            
            if(group.OwnerUserId != _currentUser.UserId)
                throw new UnauthorizedException("Unauthorized access to specified class group!");
            
            if(!await _subjectRepo.CheckForAttachmentAsync(dto.ClassGroupId, dto.SubjectId))
                throw  new ValidationException("Subject Is already detached from the class group!");

            await _subjectRepo.DetachFromClassGroupAsync(dto.ClassGroupId, dto.SubjectId);
            await _unitRepo.SaveChangesAsync();

        }

        public async Task UpdateSubjectAsync(SubjectDto dto)
        {
            var subject = await _subjectRepo.GetAsync(dto.Id);

            if(subject == null)
                throw new NotFoundException("Cannot find subject with specified Id!");

            if(subject.OwnerUserId != _currentUser.UserId)
                throw new UnauthorizedException("Unauthorized access to specified subject!");
            
            subject.Rename(dto.Name);
            subject.UpdateDescription(dto.Desc);
            await _unitRepo.SaveChangesAsync();
        }

        public async Task RemoveSubjectAsync(Guid subjectId)
        {
            var subject = await _subjectRepo.GetAsync(subjectId);

            if(subject == null)
                throw new NotFoundException("Cannot find subject with specified Id!");
                
            if(subject.OwnerUserId != _currentUser.UserId)
                throw new UnauthorizedException("Unauthorized access to specified subject!");

            await _subjectRepo.RemoveAsync(subject);
            await _unitRepo.SaveChangesAsync();
        }
    }
}