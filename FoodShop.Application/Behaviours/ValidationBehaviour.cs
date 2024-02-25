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
            .Where(v => !v.IsValid)
            .SelectMany(res => res.Errors)
            .GroupBy(f => f.PropertyName);
            
        
        if (errors.Any())
        {
            var validationEx = new ModelValidationException();

            foreach (var error in errors)
            {
                foreach (var errorDetail in error.ToList())
                    validationEx.UpsertDataList(error.Key,errorDetail.ErrorMessage);
            }

            throw validationEx;
        }
        
        return await next();
    }
}