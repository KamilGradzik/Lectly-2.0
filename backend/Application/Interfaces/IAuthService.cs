using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.DTOs.Auth;
using backend.Entities;

namespace backend.Application.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(UserRegisterDto userRegisterDto);
        Task<string> LoginAsync(UserLoginDto userLoginDto);
    }
}