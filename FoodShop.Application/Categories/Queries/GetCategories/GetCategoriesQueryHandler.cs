using AutoMapper;
using FoodShop.Application.Abstractions;
using FoodShop.Application.Filters;
using FoodShop.Application.Products;
using FoodShop.Application.Queries;
using FoodShop.Domain.Entities;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FoodShop.Application.Categories.Queries.GetCategories;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IQueryResult>
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;

    public GetCategoriesQueryHandler(ICategoryRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    
    public async Task<IQueryResult> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _repository.GetCategoriesWithFiltersAsync(request.filters);

        var dtos = _mapper.Map<IEnumerable<CategoryDto>>(categories);
        var count = await _repository.GetCategoriesCountAsync();

        //var pModel = new PaginatedQueryResult<CategoryDto>(dtos, request.page, request.per_page, count);


        IQueryResult queryResult;

        //temp
        if (request.filters.Any(f => f is PaginationFilter<Category>))
        {
            var pFilter = (PaginationFilter<Category>)request.filters.FirstOrDefault(c => c is PaginationFilter<Category>);

            if (pFilter != null && pFilter.per_page != null && pFilter.page != null)
                queryResult = new PaginatedQueryResult<CategoryDto>(dtos, (int)pFilter.page, (int)pFilter.per_page, count);
            else
                queryResult = new QueryResult<CategoryDto>(dtos);
        }
        else
            queryResult = new QueryResult<CategoryDto>(dtos);

        return queryResult;
    }
}