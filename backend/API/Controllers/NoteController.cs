using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.DTOs.Note;
using backend.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.API.Controllers
{
    [ApiController]
    [Route("api/notes")]
    [Tags("Notes")]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;
        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetNotesAsync([FromQuery] int page, [FromQuery] int pageSize)
        {
            var notes = await _noteService.GetUserNotesAsync(page, pageSize);
            return Ok(notes);
        }

        [Authorize]
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> AddNoteAsync([FromBody] CreateNoteDto dto)
        {
            await _noteService.AddNoteAsync(dto);
            return Created();
        }

        [Authorize]
        [HttpPatch]
        [Route("update")]
        public async Task<IActionResult> UpdateNoteAsync([FromBody] UpdateNoteDto dto)
        {
            await _noteService.UpdateNoteAsync(dto);
            return Ok("Note successfuly updated!");
        }

        [Authorize]
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> RemoveNoteAsync([FromQuery] Guid Id)
        {
            await _noteService.RemoveNoteAsync(Id);
            return NoContent();
        }
    }
}