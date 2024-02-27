using AutoMapper;
using FoodShop.Application.Abstractions;
using FoodShop.Application.Filters;
using FoodShop.Application.ProductEntries;
using FoodShop.Application.Queries;
using FoodShop.Application.Specifications;
using FoodShop.Application.Specifications.ProductEntries;
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
        var spec = new ProductsByFiltersSpecification(request.filters);

        var specWithoutPagination = new ProductsByFiltersSpecification(request.filters.Where(f => !(f is IPaginationFilter)).ToArray());

        var data = await _repository.GetProductsBySpecification(spec);

        var dtos = _mapper.Map<IEnumerable<ProductDto>>(data);

        var count = await _repository.CountProductsBySpecification(specWithoutPagination);

        var queryResult = dtos.ToQueryResult(request.filters,count);

        return queryResult;
    }
}