using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.Common;
using backend.Application.DTOs.Note;
using backend.Application.Interfaces;
using backend.Domain.Repositories;
using backend.Entities;

namespace backend.Application.Services
{
    public class NoteService : INoteService
    {   
        private readonly ICurrentUserService _currentUser;
        private readonly INoteRepository _noteRepo;
        private readonly IUnitOfWork _unitRepo;

        public NoteService(ICurrentUserService currentUser, INoteRepository noteRepo, IUnitOfWork unitRepo)
        {
            _currentUser = currentUser;
            _noteRepo = noteRepo;
            _unitRepo = unitRepo;
        }

        public async Task AddNoteAsync(CreateNoteDto dto)
        {
            var note = new Note(dto.Name, dto.Content, _currentUser.UserId);
            await _noteRepo.AddAsync(note);
            await _unitRepo.SaveChangesAsync();
        }

        public async Task<PagedResult<NoteDto>> GetUserNotesAsync(int page, int pageSize)
        {
            var notes = await _noteRepo.GetUserNotesAsync(_currentUser.UserId, page, pageSize);
            var notesList = new List<NoteDto>();

            foreach (var note in notes.Items)
            {
                notesList.Add(new NoteDto{
                    Id = note.Id,
                    Name = note.Name,
                    Content = note.Content,
                    CreatedAt = note.CreatedAt
                });
            }
            
            return new PagedResult<NoteDto>(notesList, page, pageSize, notes.TotalCount);
        }

        public async Task UpdateNoteAsync(UpdateNoteDto dto)
        {
            var note = await _noteRepo.GetAsync(dto.Id);
            if(note == null)
                throw  new NotFoundException("Cannot find note with specified Id!");
            
            if(note.OwnerUserId != _currentUser.UserId)
                throw new UnauthorizedException("Unauthorized access to specified note!");
            
            note.Rename(dto.Name);
            note.UpdateContent(dto.Content);
            
            await _unitRepo.SaveChangesAsync();
        }

        public async Task RemoveNoteAsync(Guid noteId)
        {
            var note = await _noteRepo.GetAsync(noteId);
            if(note == null)
                throw  new NotFoundException("Cannot find note with specified Id!");
            
            if(note.OwnerUserId != _currentUser.UserId)
                throw new UnauthorizedException("Unauthorized access to specified note!");

            await _noteRepo.RemoveAsync(note);
            await _unitRepo.SaveChangesAsync();
        }
    }
}