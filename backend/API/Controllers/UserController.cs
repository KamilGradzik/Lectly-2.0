using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.DTOs.User;
using backend.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    [Tags("User")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUserAsync()
        {
            var user = await _userService.GetUserAsync();
            return Ok(user);
        }

        [Authorize]
        [HttpPatch]
        [Route("change-password")]
        public async Task<IActionResult> ChangePasswordAsync([FromBody] UpdateUserPasswordDto dto)
        {
            await _userService.ChangePasswordAsync(dto);
            return Ok("Password sucessfuly updated!");
        }

        [Authorize]
        [HttpPatch]
        [Route("update")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UserDto dto)
        {
            await _userService.UpdateUserAsync(dto);
            return Ok("User sucessfuly updated!");
        }

        [Authorize]
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> RemoveUserAsync()
        {
            await _userService.RemoveUserAsync();
            return NoContent();
        }
    }
}