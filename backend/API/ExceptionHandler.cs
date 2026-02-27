using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.Common;

namespace backend.API
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next) { _next = next; }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception exc)
            {
                await HandleExceptionAsync(context, exc);    
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exc)
        {
            context.Response.ContentType = "application/json";
            var statusCode =  exc switch
            {
                UnauthorizedException => StatusCodes.Status401Unauthorized,
                ValidationException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError,
            };

            context.Response.StatusCode = statusCode;
            
            return context.Response.WriteAsJsonAsync(new {status = statusCode, messsage = exc.Message});
        }
    }
}