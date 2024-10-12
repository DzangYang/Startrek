using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Shared.Core;
using Users.Infrastructure.Auth.Requirements;
using Users.Infrastructure.Database;
using Permission = Users.Domain.Entities.Permission;

namespace Users.Infrastructure;


public class AuthorizationPolicyProviderService : IAuthorizationPolicyProvider
{
   public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
   {
    
      var policyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
      //policyBuilder.AddRequirements(new CheckTheTimeAvailableForAddingRequirement(DateTime.Now));
      policyBuilder.AddRequirements(new PermissionsAuthorizationRequirement(policyName));
     
      
      // Создаем политику и возвращаем ее как Task
      var policy = policyBuilder.Build();
      return Task.FromResult<AuthorizationPolicy?>(policy);
   }
   

   public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
   {
      var policyBilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
      policyBilder.RequireAuthenticatedUser();
      
      return Task.FromResult(policyBilder.Build());
   }

   public Task<AuthorizationPolicy?> GetFallbackPolicyAsync()
   {
      return Task.FromResult<AuthorizationPolicy?>(null);
   }
}