using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Application.Interfaces
{
    public interface ICurrentUserService
    {
        public Guid UserId { get; }
        public string? Email { get;}
    }
}