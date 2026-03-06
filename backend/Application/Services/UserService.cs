using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.Common;
using backend.Application.DTOs.User;
using backend.Application.Interfaces;
using backend.Domain.Repositories;

namespace backend.Application.Services
{
    public class UserService : IUserService
    {
        private readonly ICurrentUserService _currentUser;
        private readonly IUserRepository _userRepo;
        private readonly IUnitOfWork _unitRepo;
        private readonly IPasswordManager _passwordManager;
        
        public UserService(ICurrentUserService currentUser, IUserRepository userRepo, IUnitOfWork unitRepo, IPasswordManager passwordManager)
        {
            _currentUser = currentUser;
            _userRepo = userRepo;
            _unitRepo = unitRepo;
            _passwordManager = passwordManager;
        }

        public async Task<UserDto> GetUserAsync()
        {
            var user = await _userRepo.GetAsync(_currentUser.UserId);
            if(user == null)
                throw new UnauthorizedException("Unauthorized access!");

            return new UserDto {
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }
        
        public async Task ChangePasswordAsync(UpdateUserPasswordDto dto)
        {
            var user = await _userRepo.GetAsync(_currentUser.UserId);
            
            if(user == null)
                throw new UnauthorizedException("Unauthorized access!");
            
            if(!_passwordManager.VerifyPassword(dto.OldPassword, user.Password))
                throw new ValidationException("Current password is incorrect!");
            
            if(dto.NewPassword != dto.NewPasswordRepeat)
                throw new ValidationException("New password and confirmation password do not match!");

            user.ChangePassword(_passwordManager.HashPassword(dto.NewPassword));

            await _unitRepo.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(UserDto dto)
        {
            var user = await _userRepo.GetAsync(_currentUser.UserId);

            if(user == null)
                throw new UnauthorizedException("Unauthorized access!");

            user.ChangeFirstName(dto.FirstName);
            user.ChangeLastName(dto.LastName);

            await _unitRepo.SaveChangesAsync();
        }

        public async Task RemoveUserAsync()
        {
            var user = await _userRepo.GetAsync(_currentUser.UserId);

            if(user == null)
                throw new UnauthorizedException("Unauthorized access!");
            
            await _userRepo.RemoveAsync(user);
            await _unitRepo.SaveChangesAsync();
        }
    }
}