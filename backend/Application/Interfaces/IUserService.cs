using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.DTOs.User;

namespace backend.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserAsync();
        Task ChangePasswordAsync(UpdateUserPasswordDto dto);
        Task UpdateUserAsync(UserDto dto);
        Task RemoveUserAsync();
    }
}