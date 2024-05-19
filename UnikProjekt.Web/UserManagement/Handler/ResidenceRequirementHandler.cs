using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using UnikProjekt.Web.UserManagement.Requirements;

namespace UnikProjekt.Web.UserManagement.Handler
{
    public class ResidenceRequirementHandler : AuthorizationHandler<ResidenceRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResidenceRequirement requirement)
        {
            var hasAddressClaim = context.User.HasClaim(ClaimTypes.StreetAddress, " ");
            var hasUserTypeClaim = context.User.HasClaim("UserType", "Resident");

            // Check if the user has a valid address and UserType is "Resident"
            if (hasAddressClaim && hasUserTypeClaim)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }

    }
}
