﻿using System.Net;
using HR.Application.Abstractions;
using HR.Application.Services;
using HR.Domain.Interfaces;
using HR.Domain.Repositories;
using HR.Infrastructure;
using HR.Infrastructure.Database;
using HR.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Startrek.Server.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Users.Application.Abstractions;
using Users.Application.Services;
using Users.Domain.Repositories;
using Users.Infrastructure;
using Users.Infrastructure.Database;
using Users.Infrastructure.Repositories;

namespace Startrek.Server;

public static class DepedencyInjection
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
       
        services.AddDbContext<DbContextEF>
            (options => options.UseNpgsql(
                configuration.GetConnectionString("DbContextEFConnection"), 
                o => o.MigrationsHistoryTable(
                    tableName: HistoryRepository.DefaultTableName,
                    schema: "HR"
                    )));
        
        services.AddDbContext<AppUserDbContext>
        (options => options.UseNpgsql(
            configuration.GetConnectionString("DbContextEFConnection"), 
            o => o.MigrationsHistoryTable(
                tableName: HistoryRepository.DefaultTableName,
                schema: "Users"
                )));

        

        return services;
    }

    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers()
            .AddApplicationPart(typeof(HR.Endpoints.Entry).Assembly)
            .AddApplicationPart(typeof(Employees.Endpoints.Entry).Assembly);
        
        return services;

    }
    public static  IServiceCollection AddApplication(this IServiceCollection services)
    {

        services
            .AddScoped<ICandidateRepository, CandidateRepository>()
            .AddScoped<IInterviewRepository, InterviewRepository>()
            .AddScoped<ICandidateService, CandidateService>()
            .AddScoped<IInterviewService, InterviewService>()
            .AddScoped<IOfferRepository, OfferRepository>()
            .AddScoped<IOfferService, OfferService>()
            .AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped<IVacancyService, VacancyService>()
            .AddScoped<IVacancyRepository, VacancyRepository>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IAuthService, AuthService>()
            .AddScoped<IPasswordHasher, PasswordHasher>()
            .AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>()
            .AddScoped<IJwtAuthService, JwtAuthService>()
            .AddScoped<IPermissionRepository, PermissionRepository>()
            .AddScoped<IRoleRepository, RoleRepository>();
            
            
            
       
        return services;
    }

   
}
