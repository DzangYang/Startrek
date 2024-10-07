using Microsoft.AspNetCore.Authorization;

namespace Users.Infrastructure.Auth.Requirements;

public class GetAllCandidatesRequirement : IAuthorizationRequirement
{
   
}

public class GetAllCandidatesRequirementHandler :AuthorizationHandler<GetAllCandidatesRequirement>
{
   protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, GetAllCandidatesRequirement requirement)
   {
      if (context.User.IsInRole("HR") || context.User.IsInRole("Manager")|| context.User.IsInRole("Admininstrator"))
      {
         context.Succeed(requirement);
      }
      return Task.CompletedTask;
   }
}