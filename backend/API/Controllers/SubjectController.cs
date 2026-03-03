using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.DTOs.Subject;
using backend.Application.Interfaces;
using backend.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.API.Controllers
{
    [ApiController]
    [Route("api/subjects")]
    [Tags("Subjects")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetSubjectsAsync()
        {
            var subjects = await _subjectService.GetUserSubjectsAsync();
            return Ok(subjects);
        }

        [Authorize]
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateSubjectAsync([FromBody] CreateSubjectDto dto)
        {
            await _subjectService.AddSubjectAsync(dto);
            return Created();
        }

        [Authorize]
        [HttpPost]
        [Route("class-group/attach")]
        public async Task<IActionResult> AttachToClassGroupAsync([FromBody] SubjectAttachmentDto dto)
        {
            await _subjectService.AttachToClassGroupAsync(dto);
            return Created();
        }

        [Authorize]
        [HttpPatch]
        [Route("update")]
        public async Task<IActionResult> UpdateSubjectAsync([FromBody] SubjectDto dto)
        {
            await _subjectService.UpdateSubjectAsync(dto);
            return Ok("Subject successfuly updated!");
        }

        [Authorize]
        [HttpDelete]
        [Route("class-group/detach")]
        public async Task<IActionResult> DetachFromClassGroupAsync([FromBody] SubjectAttachmentDto dto)
        {
            await _subjectService.DetachFromClassGroupAsync(dto);
            return NoContent();
        }

        [Authorize]
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> RemoveSubjectAsync([FromQuery] Guid id)
        {
            await _subjectService.RemoveSubjectAsync(id);
            return NoContent();
        }
    }
}