using AutoMapper;
using FoodShop.Application.Abstractions;
using MediatR;

namespace FoodShop.Application.ProductEntries.Queries.GetProductEntryById;

public class GetProductEntryByIdQueryHandler : IRequestHandler<GetProductEntryByIdQuery,ProductEntryDto>
{
    private readonly IProductEntryRepository _repository;
    private readonly IMapper _mapper;

    public GetProductEntryByIdQueryHandler(IProductEntryRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<ProductEntryDto> Handle(GetProductEntryByIdQuery request, CancellationToken cancellationToken)
    {
        var productEntry = await _repository.GetProductEntryByIdAsync(request.Id);
        var dto = _mapper.Map<ProductEntryDto>(productEntry);
        return dto;
    }
}