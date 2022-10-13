using Entity.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Business;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // skip authorization if action is decorated with [AllowAnonymous] attribute
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
        if (allowAnonymous)
            return;

        // authorization
        //var user = (AppUser)context.HttpContext.Items["User"];
        var user = context.HttpContext.User;
        if (user == null)
            context.Result = new JsonResult(new { statusCode = StatusCodes.Status401Unauthorized, message = "Unauthorized" })
            {
                StatusCode = StatusCodes.Status401Unauthorized
            };
    }
}