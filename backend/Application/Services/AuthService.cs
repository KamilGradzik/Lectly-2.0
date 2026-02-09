using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.DTOs.Auth;
using backend.Application.Interfaces;
using backend.Domain.Repositories;
using backend.Entities;
using Microsoft.AspNetCore.Identity;

namespace backend.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly PasswordHasher<User> _passwordHasher = new();
        private readonly IUserRepository _userRepo;
        private readonly IUnitOfWork _unitRepo;
        public AuthService(IUserRepository userRepo, IUnitOfWork unitRepo) 
        { 
            _userRepo = userRepo; 
            _unitRepo = unitRepo; 
        }

        public async Task RegisterAsync(UserRegisterDto dto)
        {
            var user = new User(dto.Email, dto.Password, dto.FirstName, dto.LastName, false);
            var hashedPassword = _passwordHasher.HashPassword(user, dto.Password);
            user.ChangePassword(hashedPassword);

            await _userRepo.AddAsync(user);
            await _unitRepo.SaveChangesAsync();
        }
        
        public async Task LoginAsync(UserLoginDto dto)
        {
            
        }
    }
}