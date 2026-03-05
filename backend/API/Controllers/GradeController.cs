using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.DTOs.Grade;
using backend.Application.Interfaces;
using backend.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.API.Controllers
{
    [ApiController]
    [Route("api/grade")]
    [Tags("Grades")]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService _gradeService;
        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [Authorize]
        [HttpGet]
        [Route("student")]
        public async Task<IActionResult> GetGradesAsync([FromQuery] Guid id)
        {
            var grades = await _gradeService.GetStudentGradesAsync(id);
            return Ok(grades);
        }

        [Authorize]
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> AddGradeAsync([FromBody] CreateGradeDto dto)
        {
            await _gradeService.AddGradeAsync(dto);
            return Created();
        }

        [Authorize]
        [HttpPatch]
        [Route("update")]
        public async Task<IActionResult> UpdateGradeAsync([FromBody] GradeDto dto)
        {
            await _gradeService.UpdateGradeAsync(dto);
            return Ok("Grade successfuly updated!");
        }

        [Authorize]
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> RemoveGradeAsync([FromQuery] Guid id)
        {
            await _gradeService.RemoveGradeAsync(id);
            return NoContent();
        }
    }
}