using AutoMapper;
using FoodShop.Application.Abstractions;
using FoodShop.Application.Filters;
using FoodShop.Application.ProductEntries;
using FoodShop.Application.Queries;
using FoodShop.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace FoodShop.Application.Products.Queries.GetProducts;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IQueryResult>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public GetProductsQueryHandler(IProductRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<IQueryResult> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var data = await _repository.GetFilteredProductsAsync(request.filters);
        var dtos = _mapper.Map<IEnumerable<ProductDto>>(data);
        var count = await _repository.GetFilteredProductsCountAsync(request.filters.Where(f=>!(f is IPaginationFilter)).ToArray());



        IQueryResult queryResult;

        //temp
        if (request.filters.Any(f => f is PaginationFilter<Product>))
        {
            var pFilter = (PaginationFilter<Product>)request.filters.FirstOrDefault(c => c is PaginationFilter<Product>);

            if (pFilter != null && pFilter.per_page != null && pFilter.page != null)
                queryResult = new PaginatedQueryResult<ProductDto>(dtos, (int)pFilter.page, (int)pFilter.per_page, count);
            else
                queryResult = new QueryResult<ProductDto>(dtos);
        }
        else
            queryResult = new QueryResult<ProductDto>(dtos);

        return queryResult;
    }
}