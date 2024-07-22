using HR.Application.Abstractions;
using HR.Application.Services;
using HR.Domain.Interfaces;
using HR.Domain.Repositories;
using HR.Infrastructure;
using HR.Infrastructure.DataAccess;
using HR.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddApplicationPart(typeof(HR.Endpoints.Entry).Assembly)
    .AddApplicationPart(typeof(Employees.Endpoints.Entry).Assembly);

//builder.Services.AddApplication(builder.Configuration);
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();
builder.Services.AddScoped<IInterviewRepository, InterviewRepository>();
builder.Services.AddScoped<ICandidateService, CandidateService>();
builder.Services.AddScoped<IInterviewService, InterviewService>();
builder.Services.AddScoped<IOfferRepository, OfferRepository>();
builder.Services.AddScoped<IOfferService, OfferService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddHttpContextAccessor();
var connectionString = builder.Configuration.GetConnectionString("DbContextEFConnection")
    ?? throw new InvalidOperationException("Connection string 'DbContextEFConnection' not found.");


builder.Services.AddDbContext<DbContextEF>(options => options.UseNpgsql(connectionString));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
