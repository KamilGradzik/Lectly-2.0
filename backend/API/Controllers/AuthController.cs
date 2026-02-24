using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.DTOs.Auth;
using backend.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;

namespace backend.API.Controllers
{   
    [ApiController]
    [Route("/api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            try
            {
                var token = await _authService.LoginAsync(dto);
                return Ok(token);
            }
            catch(Exception err)
            {
                return BadRequest(err.Message);
            }
        }  

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto dto)
        {
            try
            {
                await _authService.RegisterAsync(dto);
                return Ok("Account registered!");
            }
            catch(Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}