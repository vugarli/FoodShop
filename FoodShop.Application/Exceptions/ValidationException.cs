namespace FoodShop.Application.Exceptions;

public class ValidationException : Exception
{
    public IReadOnlyCollection<ValidationError> Errors;
    public ValidationException(IReadOnlyCollection<ValidationError> errors)
    :base("Validation Error")
    {
        Errors = errors;
    }
    
}

public record ValidationError(string PropertyName, string ErrorMessage);