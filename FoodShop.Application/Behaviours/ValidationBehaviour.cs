using FluentValidation;
using FoodShop.Application.Abstractions.CQSegregationInterfaces;
using FoodShop.Application.Exceptions;
using MediatR;

namespace FoodShop.Application.Behaviours;

public class ValidationBehaviour<TRequest,TResponse> : IPipelineBehavior<TRequest,TResponse>
where TRequest : ICommandBase
{
    private IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {

        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(_validators
            .Select(v => v.ValidateAsync(context,cancellationToken)));
        
        var errors = validationResults
            .Where(v=>!v.IsValid)
            .SelectMany(res => res.Errors)
            .Select(f => new ValidationError(f.PropertyName,f.ErrorMessage))
            .ToList();

        if (errors.Any())
        {
            throw new Exceptions.ValidationException(errors);
        }
        
        return await next();
    }
}