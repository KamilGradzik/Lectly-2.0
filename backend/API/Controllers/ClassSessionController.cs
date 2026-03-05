using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.DTOs.ClassSession;
using backend.Application.Interfaces;
using backend.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.API.Controllers
{
    [ApiController]
    [Route("api/class-session")]
    [Tags("Class sessions")]
    public class ClassSessionController : ControllerBase
    {
        private readonly IClassSessionService _classSessionService;
        public ClassSessionController(IClassSessionService classSessionService)
        {
            _classSessionService = classSessionService;
        }
        
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetClassSessionsAsync()
        {
            var classSessions = await _classSessionService.GetUserClassSessionsAsync();
            return Ok(classSessions);
        }

        [Authorize]
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateClassSessionAsync([FromBody] CreateClassSessionDto dto)
        {
            await _classSessionService.AddClassSessionAsync(dto);
            return Created();
        }

        [Authorize]
        [HttpPatch]
        [Route("update")]
        public async Task<IActionResult> UpdateClassSessionAsync([FromBody] UpdateClassSessionDto dto)
        {
            await _classSessionService.UpdateClassSessionAsync(dto);
            return Ok("Class session successfuly updated!");
        }

        [Authorize]
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> RemoveClassSessionAsync([FromQuery] Guid id)
        {
            await _classSessionService.RemoveClassSessionAsync(id);
            return NoContent();
        }
    }
}