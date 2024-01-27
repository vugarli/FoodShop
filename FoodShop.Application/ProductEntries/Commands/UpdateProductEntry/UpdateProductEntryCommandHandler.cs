using AutoMapper;
using FoodShop.Application.Abstractions;
using FoodShop.Domain.Abstractions;
using FoodShop.Domain.Entities;
using MediatR;

namespace FoodShop.Application.ProductEntries.Commands.UpdateProductEntry;

public class UpdateProductEntryCommandHandler : IRequestHandler<UpdateProductEntryCommand,ProductEntryDto>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IProductEntryRepository _repository;
    private readonly IMapper _mapper;

    public UpdateProductEntryCommandHandler(IUnitOfWork unitOfWork, IProductEntryRepository repository,IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        _repository = repository;
        _mapper = mapper;
    }
    
    
    public async Task<ProductEntryDto> Handle(UpdateProductEntryCommand request, CancellationToken cancellationToken)
    {
        var productEntry = _mapper.Map<ProductEntry>(request);
        productEntry = await _repository.UpdateProductEntryAsync(productEntry);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        var dto = _mapper.Map<ProductEntryDto>(productEntry);
        return dto;
    }
}