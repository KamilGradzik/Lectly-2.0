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
        private readonly INoteRepository _noteRepo;
        private readonly IUnitOfWork _unitRepo;

        public NoteService(INoteRepository noteRepo, IUnitOfWork unitRepo)
        {
            _noteRepo = noteRepo;
            _unitRepo = unitRepo;
        }

        public async Task AddNoteAsync(CreateNoteDto dto, Guid userId)
        {
            var note = new Note(dto.Name, dto.Content, userId);
            await _noteRepo.AddAsync(note);
            await _unitRepo.SaveChangesAsync();
        }

        public async Task<PagedResult<NoteDto>> GetUserNotesAsync(Guid userId, int page, int pageSize)
        {
            var notes = await _noteRepo.GetUserNotesAsync(userId, page, pageSize);
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

        public async Task UpdateNoteAsync(UpdateNoteDto dto, Guid userId)
        {
            var note = await _noteRepo.GetAsync(dto.Id);
            if(note == null)
                throw  new ArgumentException("Cannot find note with specified Id!");
            
            if(note.OwnerUserId != userId)
                throw new UnauthorizedAccessException("Unauthorized access to specified note!");
            
            note.Rename(dto.Name);
            note.UpdateContent(dto.Content);
            
            await _unitRepo.SaveChangesAsync();
        }

        public async Task RemoveNoteAsync(Guid noteId, Guid userId)
        {
            var note = await _noteRepo.GetAsync(noteId);
            if(note == null)
                throw  new ArgumentException("Cannot find note with specified Id!");
            
            if(note.OwnerUserId != userId)
                throw new UnauthorizedAccessException("Unauthorized access to specified note!");

            await _noteRepo.RemoveAsync(note);
            await _unitRepo.SaveChangesAsync();
        }
    }
}