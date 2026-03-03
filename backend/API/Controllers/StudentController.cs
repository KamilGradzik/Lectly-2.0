using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.DTOs.Student;
using backend.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.API.Controllers
{
    [ApiController]
    [Route("api/student")]
    [Tags("Students")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetStudentsAsync([FromQuery] int page, [FromQuery] int pageSize)
        {
            var students = await _studentService.GetUserStudentsAsync(page, pageSize);
            return Ok(students);
        }

        [Authorize]
        [HttpGet]
        [Route("class-groups")]
        public async Task<IActionResult> GetStudentClassGroupsAsync([FromQuery] Guid studentId)
        {
            var classGroups = await _studentService.GetStudentClassGroupsAsync(studentId);
            return Ok(classGroups);
        }

        [Authorize]
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateStudentAsync([FromBody] CreateStudentDto dto)
        {
            await _studentService.AddStudentAsync(dto);
            return Created();
        }

        [Authorize]
        [HttpPost]
        [Route("class-group/attach")]
        public async Task<IActionResult> AttachToClassGroupAsync([FromBody] StudentAttachmentDto dto)
        {
            await _studentService.AttachToClassGroupAsync(dto);
            return Created();
        }

        [Authorize]
        [HttpPatch]
        [Route("update")]
        public async Task<IActionResult> UpdateStudentAsync([FromBody] StudentDto dto)
        {
            await _studentService.UpdateStudentAsync(dto);
            return Ok("Student successfuly updated!");
        }

        [Authorize]
        [HttpDelete]
        [Route("class-group/detach")]
        public async Task<IActionResult> DetachFromClassGroupAsync([FromBody] StudentAttachmentDto dto)
        {
            await _studentService.DetachFromClassGroupAsync(dto);
            return NoContent();
        }

        [Authorize]
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> RemoveStudentAsync([FromQuery] Guid id)
        {
            await _studentService.RemoveStudentAsync(id);
            return NoContent();
        }


    }
}