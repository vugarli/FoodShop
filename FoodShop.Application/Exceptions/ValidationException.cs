using Xeptions;

namespace FoodShop.Application.Exceptions;

public class ModelValidationException : Xeption
{
    public ModelValidationException()
    :base("Validation Error")
    {
        
    }
}

public record ValidationError(string PropertyName, string ErrorMessage);