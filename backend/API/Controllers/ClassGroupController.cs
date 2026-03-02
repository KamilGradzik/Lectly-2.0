using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.DTOs.ClassGroup;
using backend.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace backend.API.Controllers
{   
    [ApiController]
    [Route("api/class-groups")]
    [Tags("Class groups")]
    public class ClassGroupController : ControllerBase
    {
        private readonly IClassGroupService _classGroupService;
        public ClassGroupController(IClassGroupService classGroupService)
        {
            _classGroupService = classGroupService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetClassGroupsAsync()
        {
            var groups = await _classGroupService.GetUserClassGroupsAsync();
            return Ok(groups);
        }

        [Authorize]
        [HttpGet]
        [Route("students")]
        public async Task<IActionResult> GetClassGroupStudentsAsync([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] Guid Id)
        {
            var groups = await _classGroupService.GetClassGroupStudentsAsync(page, pageSize, Id);
            return Ok(groups);
        }

        [Authorize]
        [HttpGet]
        [Route("subjects")]
        public async Task<IActionResult> GetClassGroupSubjectsAsync([FromQuery] Guid Id)
        {
            var groups = await _classGroupService.GetClassGroupSubjectsAsync(Id);
            return Ok(groups);
        }

        [Authorize]
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> AddClassGroupAsync([FromBody] CreateClassGroupDto dto)
        {
            await _classGroupService.AddClassGroupAsync(dto);
            return Created();
        }

        [Authorize]
        [HttpPatch]
        [Route("update")]
        public async Task<IActionResult> UpdateClassGroupAsync([FromBody] ClassGroupDto dto)
        {
            await _classGroupService.UpdateClassGroupAsync(dto);
            return Ok("Class group successfuly updated!");
        }

        [Authorize]
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> RemoveClassGroupAsync([FromQuery] Guid Id)
        {
            await _classGroupService.RemoveClassGroupAsync(Id);
            return NoContent();
        }
    }
}