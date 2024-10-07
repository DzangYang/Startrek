using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Startrek.Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddPresentation();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var config = builder.Configuration;

builder.Services.AddAuthentication(x =>
{
   x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
   x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
   
   x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
 
}).AddJwtBearer(x =>
{
   x.SaveToken = true;
   x.TokenValidationParameters = new TokenValidationParameters
   {
      SaveSigninToken = true,
      ValidIssuer = config["JwtTokenSettings:Issuer"],
      ValidAudience = config["JwtTokenSettings:Audience"],
      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtTokenSettings:SecretKey"])),
      ValidateIssuer = true,
      ValidateAudience = true,
      ValidateLifetime = true,
      ValidateIssuerSigningKey = true
   };
});


builder.Services.AddAuthorization(options =>
{
   options.AddPolicy("AccessMember", policy => policy.RequireClaim("permissions", "AccessMember"));
  
   options.AddPolicy("ReadMember", policy => policy.RequireClaim("permissions", "ReadMember"));
   options.AddPolicy("HR_GetAllCandidates", policy => policy.RequireClaim("permissions", "HR_GetAllCandidates"));
});


builder.Services.AddHttpContextAccessor();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseAuthorization();

app.MapControllers();

app.Run();
