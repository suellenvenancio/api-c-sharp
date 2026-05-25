using System;
using LibraryApplication.Service;
using LibraryApplication.Service.Interfaces;
using LibraryApplication.Services;
using LibraryDomain.Account;
using LibraryDomain.Interfaces;
using LibraryInfraData.Authenticate;
using LibraryInfraData.Context;
using LibraryInfraData.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryInfraIOC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly( typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer( options =>
        {
            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])),
                ClockSkew = TimeSpan.Zero
            };
        });

        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ILoanRepository, LoanRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IBookService, BookServices>();
        services.AddScoped<ICategoryService, CategoryServices>();
        services.AddScoped<ILoanService, LoansServices>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthenticate, AuthenticateService>();
        

        return services;
    }

}
