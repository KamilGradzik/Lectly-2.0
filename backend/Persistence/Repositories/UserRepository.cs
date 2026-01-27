using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Repositories;
using backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) { _context = context; }

        public Task AddAsync(User user)
        {
            _context.Users.Add(user);
            return Task.CompletedTask;
        }

        public async Task<User> GetAsync(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if(user == null)
                throw new ArgumentNullException("Cannot find user with specified Id!");
            return user;
        }

        public Task RemoveAsync(User user)
        {
            _context.Users.Remove(user);
            return Task.CompletedTask;
        }
    }
}