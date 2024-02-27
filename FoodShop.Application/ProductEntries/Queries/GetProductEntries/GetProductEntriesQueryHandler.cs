using AutoMapper;
using FoodShop.Application.Abstractions;
using FoodShop.Application.Filters;
using FoodShop.Application.Queries;
using FoodShop.Application.Specifications.ProductEntries;
using MediatR;

namespace FoodShop.Application.ProductEntries.Queries.GetProductEntries;

public class GetProductEntriesQueryHandler : IRequestHandler<GetProductEntriesQuery, IQueryResult>
{
    private readonly IProductEntryRepository _repository;
    private readonly IMapper _mapper;

    public GetProductEntriesQueryHandler(IProductEntryRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<IQueryResult> Handle(GetProductEntriesQuery request, CancellationToken cancellationToken)
    {
        var spec = new ProductEntriesByFiltersSpecification(request.filters);
        var specWithoutPagination = new ProductEntriesByFiltersSpecification(request.filters.Where(f => !(f is IPaginationFilter)).ToArray());

        var productEntries = await _repository.GetProductEntriesBySpecification(spec);

        var dtos = _mapper.Map<IEnumerable<ProductEntryDto>>(productEntries);

        var count = await _repository.CountProductEntriesBySpecification(specWithoutPagination);

        IQueryResult queryResult = dtos.ToQueryResult(request.filters,count);

        return queryResult;
    }
}