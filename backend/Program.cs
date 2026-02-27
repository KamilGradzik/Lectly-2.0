
using System.Text;
using backend.API;
using backend.Application.Common;
using backend.Application.Interfaces;
using backend.Application.Services;
using backend.Infrastructure;
using backend.Infrastructure.Persistence;
using backend.Infrastructure.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddOpenApi();
        builder.Services.AddControllers();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddInfrastructure();

        //_____________ DB CONNECTION _____________
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDatabase"));
        });

        //_____________ JWT CONFIG _____________
        builder.Services.Configure<JwtSettings>(
            builder.Configuration.GetSection("JwtSettings"));

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();

            options.MapInboundClaims = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings!.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
            };
            
        });
        
        //_____________ SWAGGER CONFIG _____________
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Lectly API",
                Description = "All the API endpoints that exists in Lectly application",
                Version = "v0.1",
            });

            options.AddSecurityDefinition("JWT", new OpenApiSecurityScheme
            {
                Name = "JWT Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Please provide JWT token"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "JWT"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {   
            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapOpenApi();
        }
        app.UseMiddleware<ExceptionHandlerMiddleware>();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
    
}