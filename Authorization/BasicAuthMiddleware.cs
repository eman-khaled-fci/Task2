namespace WebApi.Authorization;

using System.Net.Http.Headers;
using System.Text;
using WebApi.Models;
using WebApi.Services;

public class BasicAuthMiddleware
{
    private readonly RequestDelegate _next;

    public BasicAuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IUserService userService)
    {
        try
        {
            var authHeader = AuthenticationHeaderValue.Parse(context.Request.Headers["Authorization"]);
            var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
            var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':', 2);
            var username = credentials[0];
            var password = credentials[1];
            AuthenticateLoginModel model = new AuthenticateLoginModel
            {
                Username = username,
                Password = password
            };

            // authenticate credentials with user service and attach user to http context
            context.Items["User"] = await userService.AuthenticateLogin(model);
        }
        catch
        {

        }

        await _next(context);
    }
}