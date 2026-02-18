using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.Common;
using backend.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

namespace backend.Infrastructure.Security
{
    public class TokenManager : ITokenManager
    {
        private readonly JwtBearerOptions _options;
        public TokenManager(IOptions<JwtBearerOptions> options)
        {
            _options = options.Value;
        }

        public string GenerateAccessToken(User user)
        {
            var token = "JWT";
            return token;
        }
    }
}