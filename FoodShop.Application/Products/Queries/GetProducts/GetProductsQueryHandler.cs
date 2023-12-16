using AutoMapper;
using FoodShop.Application.Abstractions;
using FoodShop.Application.Pagination;
using FoodShop.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace FoodShop.Application.Products.Queries.GetProducts;

public class GetProductsQueryHandler : IRequestHandler<GetPaginatedProductsQuery, PaginatedResult<ProductDto>>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public GetProductsQueryHandler(IProductRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<PaginatedResult<ProductDto>> Handle(GetPaginatedProductsQuery request, CancellationToken cancellationToken)
    {
        var data = await _repository.GetPaginatedProductsAsync(request.page,request.per_page);
        var dto = _mapper.Map<IEnumerable<ProductDto>>(data);
        var count = await _repository.GetProductsCountAsync();

        var pModel = new PaginatedResult<ProductDto>(dto, request.page,request.per_page,count);

        return pModel;
    }
}