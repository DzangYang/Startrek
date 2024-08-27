using HR.Application.Abstractions;
using HR.Application.Services;
using HR.Domain.Interfaces;
using HR.Domain.Repositories;
using HR.Infrastructure;
using HR.Infrastructure.DataAccess;
using HR.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Startrek.Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddPresentation();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

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
