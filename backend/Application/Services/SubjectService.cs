using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.DTOs.Subject;
using backend.Application.Interfaces;
using backend.Domain.Repositories;
using backend.Entities;

namespace backend.Application.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepo;
        private readonly IUnitOfWork _unitRepo;

        public SubjectService(ISubjectRepository subjectRepo, IUnitOfWork unitRepo)
        {
            _subjectRepo = subjectRepo;
            _unitRepo = unitRepo;
        }

        public async Task AddSubjectAsync(CreateSubjectDto dto, Guid userId)
        {
            await _subjectRepo.AddAsync(new Subject(dto.Name, userId, dto.Desc));
            await _unitRepo.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<SubjectDto>> GetUserSubjectsAsync(Guid userId)
        {
            var subjects = await _subjectRepo.GetUserSubjectsAsync(userId);
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

        public async Task UpdateSubjectAsync(SubjectDto dto, Guid userId)
        {
            var subject = await _subjectRepo.GetSubjectAsync(dto.Id);

            if(subject == null)
                throw new ArgumentException("Cannot find subject with specified Id!");

            if(subject.OwnerUserId != userId)
                throw new UnauthorizedAccessException("Unauthorized access to specified subject!");
            
            subject.Rename(dto.Name);
            subject.UpdateDescription(dto.Desc);
            await _unitRepo.SaveChangesAsync();
        }

        public async Task RemoveSubjectAsync(Guid subjectId, Guid userId)
        {
            var subject = await _subjectRepo.GetSubjectAsync(subjectId);

            if(subject == null)
                throw new ArgumentException("Cannot find subject with specified Id!");
                
            if(subject.OwnerUserId != userId)
                throw new UnauthorizedAccessException("Unauthorized access to specified subject!");

            await _subjectRepo.RemoveAsync(subject);
            await _unitRepo.SaveChangesAsync();
        }
    }
}