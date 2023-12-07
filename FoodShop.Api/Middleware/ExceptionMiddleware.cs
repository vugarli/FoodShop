using FoodShop.Api.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FoodShop.Api.Middleware;

public class ExceptionMiddleware : IMiddleware
{
    
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {

            var ExceptionDetails = exception.GetExceptionDetails();

            var problem = new ProblemDetails()
            {
                Status = ExceptionDetails.Status,
                Title = ExceptionDetails.Title,
                Detail = ExceptionDetails.Detail,
                Type = ExceptionDetails.Type
            };

            if (ExceptionDetails.Errors != null)
            {
                problem.Extensions["errors"] = ExceptionDetails.Errors;
            }
            else
                throw;

            context.Response.StatusCode = ExceptionDetails.Status;
            await context.Response.WriteAsJsonAsync(problem);
        }
    }
}