using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.Common;
using backend.Application.Interfaces;
using backend.Application.Services;
using backend.Domain.Repositories;
using backend.Infrastructure.Persistence.Repositories;
using backend.Infrastructure.Security;

namespace backend.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //Application services register
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICalendarEventService, CalendarEventService>();
            services.AddScoped<IClassGroupService, ClassGroupSerivce>();
            services.AddScoped<IClassSessionService, ClassSessionService>();
            services.AddScoped<IGradeService, GradeService>();
            services.AddScoped<INoteService, NoteService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ISubjectService, SubjectService>();

            //Infrastructure repositories register
            services.AddScoped<ICalendarEventRepository, CalendarEventRepository>();
            services.AddScoped<IClassGroupRepository, ClassGroupRepository>();
            services.AddScoped<IClassSessionRepository, ClassSessionRepository>();
            services.AddScoped<IGradeRepository, GradeRepository>();
            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();

            //Security middleware register
            services.AddScoped<ITokenManager, TokenManager>();
            services.AddScoped<IPasswordManager, PasswordManager>();

            return services;
        }
    }
}