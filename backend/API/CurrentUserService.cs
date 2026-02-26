using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using backend.Application.Interfaces;

namespace backend.API
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        
        public CurrentUserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        
        public Guid UserId => Guid.Parse(_contextAccessor.HttpContext!.User.FindFirstValue(JwtRegisteredClaimNames.Sub)!);

        public string? Email => _contextAccessor.HttpContext!.User.FindFirstValue(JwtRegisteredClaimNames.Email);
    }
}