using Microsoft.AspNetCore.Authorization;
using Users.Domain.Enums;

namespace Users.Application;

public sealed class HasPermission : AuthorizeAttribute
{
   public HasPermission(Permission permission)
      : base(policy: permission.ToString())
   {
   }
}