using AutoMapper;
using FoodShop.Application.Abstractions;
using MediatR;

namespace FoodShop.Application.ProductEntries.Queries.GetProductEntries;

public class GetProductEntriesQueryHandler : IRequestHandler<GetProductEntriesQuery,IEnumerable<ProductEntryDto>>
{
    private readonly IProductEntryRepository _repository;
    private readonly IMapper _mapper;

    public GetProductEntriesQueryHandler(IProductEntryRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ProductEntryDto>> Handle(GetProductEntriesQuery request, CancellationToken cancellationToken)
    {
        var productEntries = await _repository.GetProductEntriesAsync();
        var dtos = _mapper.Map<IEnumerable<ProductEntryDto>>(productEntries);
        return dtos;
    }
}