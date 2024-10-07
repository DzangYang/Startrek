using Microsoft.AspNetCore.Authorization;
using Shared.Core;

namespace Users.Application.Auth;

public sealed class HasPermission : AuthorizeAttribute
{
   public HasPermission(Permission permission)
      : base(policy: permission.ToString())
   {
   }
}