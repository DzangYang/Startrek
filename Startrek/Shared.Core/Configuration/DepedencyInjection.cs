using HR.Application.Abstractions;
using HR.Application.Services;
using HR.Domain.Repositories;
using HR.Infrastructure.DataAccess;
using HR.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Core.Configuration;

public static class DepedencyInjection
{
   
    public static  IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        var configurationString = configuration.GetConnectionString("dfdf") ?? throw new Exception();

        services
            .AddScoped<ICandidateRepository, CandidateRepository>()
            .AddScoped<IInterviewRepository, InterviewRepository>()
            .AddScoped<ICandidateService, CandidateService>()
            .AddScoped<IInterviewService, InterviewService>()
            .AddDbContext<DbContextEF>(options => options.UseNpgsql(configurationString));

        return services;
    }

   
}
