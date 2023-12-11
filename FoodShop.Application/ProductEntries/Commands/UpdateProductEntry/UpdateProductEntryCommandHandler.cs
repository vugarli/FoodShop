using AutoMapper;
using FoodShop.Application.Abstractions;
using FoodShop.Domain.Entities;
using MediatR;

namespace FoodShop.Application.ProductEntries.Commands.UpdateProductEntry;

public class UpdateProductEntryCommandHandler : IRequestHandler<UpdateProductEntryCommand,ProductEntryDto>
{
    private readonly IProductEntryRepository _repository;
    private readonly IMapper _mapper;

    public UpdateProductEntryCommandHandler(IProductEntryRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    
    public async Task<ProductEntryDto> Handle(UpdateProductEntryCommand request, CancellationToken cancellationToken)
    {
        var productEntry = _mapper.Map<ProductEntry>(request);
        productEntry = await _repository.UpdateProductEntryAsync(productEntry);
        var dto = _mapper.Map<ProductEntryDto>(productEntry);
        return dto;
    }
}