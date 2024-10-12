using Microsoft.AspNetCore.Authorization;

namespace Users.Infrastructure.Auth.Requirements;

/// <summary>
/// Проверка  доступного для добавления времени
/// </summary>
public class CheckTheTimeAvailableForAddingRequirement : IAuthorizationRequirement
{
   public DateTime TimeToAdd { get; set; }
   public CheckTheTimeAvailableForAddingRequirement(DateTime time)
   {
      TimeToAdd = time;
   }
}

/// <summary>
/// Обработчик проверки доступного для добавления времени
/// </summary>
public class CheckTheTimeAvailableForAddingRequirementHandler : AuthorizationHandler<CheckTheTimeAvailableForAddingRequirement>
{
   protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CheckTheTimeAvailableForAddingRequirement requirement)
   {
      
      //Проверка условия содержит ли юзер такие утверждения и содержит ли он данные роли
      if (context.User.HasClaim(claim => claim.Type == "AccessMember")  || context.User.IsInRole("Admininstrator"))
      {
          var isBetween = TimeOnly
             .FromDateTime(requirement.TimeToAdd)
             .IsBetween(new TimeOnly(9, 0, 0), new TimeOnly(12, 0, 0));
         
          if(isBetween)
            context.Succeed(requirement);
          else
          {
             context.Fail();
             Console.WriteLine("Ошибка доступа, текущее время недоступно для обращения к ресурсу!");
          }
      }
      
      
      
      return Task.CompletedTask;
   }
}