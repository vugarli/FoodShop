using AutoMapper;
using FoodShop.Application.Abstractions;
using FoodShop.Application.Filters;
using FoodShop.Application.Queries;
using FoodShop.Application.Specifications.ProductEntries;
using FoodShop.Domain.Entities;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        
        //var count = await _repository.GetProductEntriesWithFiltersCountAsync(request.filters.Where(f => !(f is IPaginationFilter)).ToArray());


        IQueryResult queryResult;

        //temp
        if (request.filters.Any(f => f is PaginationFilter<ProductEntry>))
        { 
            var pFilter = (PaginationFilter<ProductEntry>) request.filters.FirstOrDefault(c => c is PaginationFilter<ProductEntry>);

            if(pFilter!= null && pFilter.per_page != null && pFilter.page != null)
                queryResult = new PaginatedQueryResult<ProductEntryDto>(dtos, (int)pFilter.page, (int)pFilter.per_page, count);
            else
                queryResult = new QueryResult<ProductEntryDto>(dtos);
        }
        else
            queryResult = new QueryResult<ProductEntryDto>(dtos);

        return queryResult;
    }
}