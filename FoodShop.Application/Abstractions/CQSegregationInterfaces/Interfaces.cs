using MediatR;

namespace FoodShop.Application.Abstractions.CQSegregationInterfaces;

public interface ICommand : IRequest, ICommandBase
{
    
}

public interface ICommand<out TResponse> : IRequest<TResponse>, ICommandBase
{
        
}

public interface ICommandBase
{
    
}