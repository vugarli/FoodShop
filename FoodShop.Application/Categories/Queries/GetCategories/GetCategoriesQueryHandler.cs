using AutoMapper;
using FoodShop.Application.Abstractions;
using FoodShop.Application.Pagination;
using FoodShop.Domain.Entities;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FoodShop.Application.Categories.Queries.GetCategories;

public class GetCategoriesQueryHandler : IRequestHandler<GetPaginatedCategoriesQuery, PaginatedResult<CategoryDto>>
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;

    public GetCategoriesQueryHandler(ICategoryRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    
    public async Task<PaginatedResult<CategoryDto>> Handle(GetPaginatedCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _repository.GetPaginatedCategoriesAsync(request.page,request.per_page);
        var categoryDtos = _mapper.Map<IEnumerable<CategoryDto>>(categories);
        var count = await _repository.GetCategoriesCountAsync();

        var pModel = new PaginatedResult<CategoryDto>(categoryDtos, request.page, request.per_page, count);

        return pModel;
    }
}