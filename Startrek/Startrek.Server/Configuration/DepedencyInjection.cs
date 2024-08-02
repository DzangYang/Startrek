using HR.Application.Abstractions;
using HR.Application.Services;
using HR.Domain.Interfaces;
using HR.Domain.Repositories;
using HR.Infrastructure;
using HR.Infrastructure.DataAccess;
using HR.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Startrek.Server;

public static class DepedencyInjection
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
       
        services.AddDbContext<DbContextEF>
            (options => options.UseNpgsql(
                configuration.GetConnectionString("DbContextEFConnection")
                ?? throw new InvalidOperationException("Connection string 'DbContextEFConnection' not found.")));

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
            .AddScoped<IVacancyRepository, VacancyRepository>();
       
        return services;
    }

   
}
