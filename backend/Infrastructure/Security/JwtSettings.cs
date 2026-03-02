using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Infrastructure.Security
{
    public class JwtSettings
    {
        public required string Key { get; set; }
        public required string Issuer { get; set; } 
        public required string Audience { get; set; } 
        public int ExpiryDays { get; set; }
    }
}