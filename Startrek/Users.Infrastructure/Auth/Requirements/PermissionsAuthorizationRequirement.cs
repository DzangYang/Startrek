using Microsoft.AspNetCore.Authorization;
using Shared.Core;
using Users.Infrastructure.Database;
using Permission = Users.Domain.Entities.Permission;

namespace Users.Infrastructure.Auth.Requirements;

public class PermissionsAuthorizationRequirement : IAuthorizationRequirement
{
   public string Permissions { get; }
   public PermissionsAuthorizationRequirement(string permissions)
   {
      Permissions = permissions;
   }
}

public static class CustomClaimsType
{
   public const string Permissions = "permissions";
}
public class PermissionsAuthorizationRequirementHandler :AuthorizationHandler<PermissionsAuthorizationRequirement>
{
   protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionsAuthorizationRequirement requirement)
   {
      
      var permissionClaim = context.User.FindFirst(
         c => c.Type == CustomClaimsType.Permissions);
      
      if (permissionClaim == null)
      {
         return Task.CompletedTask;
      }

      var userPermissions = permissionClaim.Value.Split(',');

      var requiredPermission = requirement.Permissions; 
      
      if (!userPermissions.Contains(requiredPermission))
      {
         return Task.CompletedTask;
      }
      context.Succeed(requirement);
      return Task.CompletedTask;
      
   }
}