using Contracts.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Handlers
{
    public class ExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var problemDetails = CreateProblemDeatils(exception);

            httpContext.Response.StatusCode = problemDetails.Status ??
                StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
            return true;
        }

        private static ProblemDetails CreateProblemDeatils(Exception exception) 
        {
            ProblemDetails problemDetails = exception switch
            {
                NotFoundException => CreateProblemDeatils(StatusCodes.Status404NotFound, "Not Found", exception.Message),
                CustomValidationException => CreateProblemDeatils(StatusCodes.Status400BadRequest, "Validation Error", "One or more validations errors occurred"),
                _ => CreateProblemDeatils(StatusCodes.Status500InternalServerError, "Internal Server Error", "An unexpected error occurred")
            };

            if (exception is CustomValidationException customValidationException) 
            {
                problemDetails.Extensions["errors"] = customValidationException.ValidationErrors;
            }
             return problemDetails;
        }

        private static ProblemDetails CreateProblemDeatils(int status, string title, string detail) 
        {
            return new ProblemDetails 
            { 
                Status = status, 
                Title = title, 
                Detail = detail 
            };
        }

    }
}
