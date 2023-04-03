using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace ErrorHandling
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (BadRequestException e)
            {
                // Status Code : 400
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync(e.Message);
            }
            catch (AuthorizationtException e)
            {
                // Status Code : 401
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync(e.Message);
            }
            catch (NotFoundException e)
            {
                // Status Code : 404
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await context.Response.WriteAsync(e.Message);
            }
            catch (ValidationException e)
            {
                // Status Code : 500
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(e.Message);
            }
            catch (BadGatewayException e)
            {
                // Status Code : 502
                context.Response.StatusCode = (int)HttpStatusCode.BadGateway;
                await context.Response.WriteAsync(e.Message);
            }
        }   
    }
}
