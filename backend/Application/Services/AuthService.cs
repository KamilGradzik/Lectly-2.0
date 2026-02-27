using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.Common;
using backend.Application.DTOs.Auth;
using backend.Application.Interfaces;
using backend.Domain.Repositories;
using backend.Entities;
using backend.Infrastructure.Security;
using Microsoft.AspNetCore.Identity;

namespace backend.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly IUnitOfWork _unitRepo;
        private readonly IPasswordManager _passwordManager;
        private readonly ITokenManager _tokenManager;
        public AuthService(IUserRepository userRepo, IUnitOfWork unitRepo, IPasswordManager passwordManager, ITokenManager tokenManager) 
        { 
            _userRepo = userRepo; 
            _unitRepo = unitRepo;
            _passwordManager = passwordManager;
            _tokenManager = tokenManager;
        }

        public async Task RegisterAsync(UserRegisterDto dto)
        {
            var hashedPassword = _passwordManager.HashPassword(dto.Password);
            var user = new User(dto.Email, hashedPassword, dto.FirstName, dto.LastName, true);

            await _userRepo.AddAsync(user);
            await _unitRepo.SaveChangesAsync();
        }
        
        public async Task<string> LoginAsync(UserLoginDto dto)
        {
            var user = await _userRepo.GetByEmailAsync(dto.Email);
            if(user == null)
                throw new NotFoundException("Cannot find user with specified email");
            
            if(!_passwordManager.VerifyPassword(dto.Password, user.Password))
                throw new UnauthorizedException("Invaild credentials, please try again!");
            
            if(!user.IsActive)
                throw new UnauthorizedException("Account inactive, please activate it with link sent in email!");
                
            return _tokenManager.GenerateAccessToken(user);
        }
    }
}