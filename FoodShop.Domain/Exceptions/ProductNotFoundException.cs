namespace FoodShop.Domain.Exceptions;

public class ProductNotFoundException : Exception
{
    public ProductNotFoundException(Guid Id)
    :base($"Product with Id = {Id} not found!")
    {
        
    }
}