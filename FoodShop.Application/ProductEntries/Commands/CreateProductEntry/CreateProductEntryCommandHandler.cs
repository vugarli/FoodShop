using AutoMapper;
using FoodShop.Application.Abstractions;
using FoodShop.Domain.Abstractions;
using FoodShop.Domain.Entities;
using MediatR;

namespace FoodShop.Application.ProductEntries.Commands.CreateProductEntry;

public class CreateProductEntryCommandHandler : IRequestHandler<CreateProductEntryCommand,ProductEntryDto>
{
    private readonly IProductEntryRepository _repository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductEntryCommandHandler(IProductEntryRepository repository,IMapper mapper,IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<ProductEntryDto> Handle(CreateProductEntryCommand request, CancellationToken cancellationToken)
    {
        var productEntry = _mapper.Map<ProductEntry>(request);
        productEntry = await _repository.CreateProductEntryAsync(productEntry);
        var dto = _mapper.Map<ProductEntryDto>(productEntry);
        return dto;
    }
}