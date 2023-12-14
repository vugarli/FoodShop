using AutoMapper;
using FoodShop.Application.Abstractions;
using FoodShop.Application.Pagination;
using FoodShop.Domain.Entities;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FoodShop.Application.ProductEntries.Queries.GetProductEntries;

public class GetProductEntriesQueryHandler : IRequestHandler<GetPaginatedProductEntriesQuery, PaginatedResult<ProductEntryDto>>
{
    private readonly IProductEntryRepository _repository;
    private readonly IMapper _mapper;

    public GetProductEntriesQueryHandler(IProductEntryRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<PaginatedResult<ProductEntryDto>> Handle(GetPaginatedProductEntriesQuery request, CancellationToken cancellationToken)
    {
        var productEntries = await _repository.GetPaginatedProductEntriesAsync(request.page,request.per_page);
        var dtos = _mapper.Map<IEnumerable<ProductEntryDto>>(productEntries);
        var count = await _repository.GetProductEntriesCountAsync();

        var pModel = new PaginatedResult<ProductEntryDto>(dtos, request.page, request.per_page, count);

        return pModel;
    }
}