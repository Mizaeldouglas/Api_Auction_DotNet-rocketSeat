using Api_Auction.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api_Auction.API.Filters;

public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // dGF0aWFuYUB0YXRpYW5hLmNvbQ==
        try
        {
            var token = TokenOnRequest(context.HttpContext);
            var repository = new ApiAuctionDbContext();
            var email = FromBase64String(token);
            var exist = repository.Users.Any(user => user.Email.Equals(email));

            if (exist == false)
            {
                context.Result = new UnauthorizedObjectResult("Email Not valid");
            }
        }
        catch (Exception e)
        {
            context.Result = new UnauthorizedObjectResult(e.Message);
            throw;
        }
    }

    private string TokenOnRequest(HttpContext context)
    {
        var authentication = context.Request.Headers.Authorization.ToString();
        if (string.IsNullOrEmpty(authentication))
        {
            throw new Exception("Token is not valid");
        }
        
        return authentication["Bearer ".Length..];
        
    }

    private string FromBase64String(string base64)
    {
        var data = Convert.FromBase64String(base64);
        return System.Text.Encoding.UTF8.GetString(data);
    }
}