using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GestionProduitPanier_AspNET.Tools
{
    public class ConnectionHandler : AuthorizationHandler<ConnectionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ConnectionRequirement requirement)
        {
            if(context.User.HasClaim(c=>c.Type==ClaimTypes.Email) && (requirement.Role == null || (context.User.HasClaim(c=>c.Type==ClaimTypes.Role) && context.User.Claims.FirstOrDefault(u=>u.Type==ClaimTypes.Role).Value==requirement.Role)))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
