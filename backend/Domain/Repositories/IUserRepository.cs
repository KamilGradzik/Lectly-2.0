using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities;

namespace backend.Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User?> GetAsync(Guid id);
        Task RemoveAsync(User user);
    }
}