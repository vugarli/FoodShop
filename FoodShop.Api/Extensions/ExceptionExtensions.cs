using System.Collections;
using FoodShop.Application.Exceptions;

namespace FoodShop.Api.Extensions;

public static class ExceptionExtensions
{
    public static ExceptionDetail GetExceptionDetails(this Exception exception)
    {
        if (exception is ModelValidationException validationException)
        {
            return new ExceptionDetail
                (
                    StatusCodes.Status400BadRequest,
                    "ValidationException",
                    "Validation",
                    "Something bad happened",
                    null
                    );
        }
        return new ExceptionDetail
        (
            StatusCodes.Status500InternalServerError,
            "Server error",
            "Nope",
            "Server Error",
            null
        );
    }
}


public record ExceptionDetail(int Status,string Type,string Title,string Detail,IEnumerable<object>? Errors);