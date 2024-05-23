using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using UnikProjekt.Web.UserManagement.Requirements;

namespace UnikProjekt.Web.UserManagement.Handler
{
    public class ResidenceRequirementHandler : AuthorizationHandler<ResidenceRequirement>
    {
        //Hvis man fx vil have at Man både skal være admin og formand til at kunne tilgå noget specifik
        //så kan man lave den her... og så søg på IAuthorize.. for at se hvordan man får den implementeret
        //i controlleren 
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
