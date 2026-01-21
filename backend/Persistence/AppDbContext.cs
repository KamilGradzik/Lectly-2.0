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
        public DbSet<Subject> Subjects => Set<Subject>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Note> Notes => Set<Note>();
        public DbSet<GroupSubject> GroupsSubjects => Set<GroupSubject>();
        public DbSet<Grade> Grades => Set<Grade>();
        public DbSet<ClassSession> ClassSessions => Set<ClassSession>();
        public DbSet<ClassGroup> ClassGroups => Set<ClassGroup>();
        public DbSet<CalendarEvent> CalendarEvents  => Set<CalendarEvent>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder); 
        }
    }
}