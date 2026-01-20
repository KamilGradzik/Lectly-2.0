using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
    }
}