using AutoMapper;
using FoodShop.Application.Abstractions;
using FoodShop.Application.Filters;
using FoodShop.Application.Products;
using FoodShop.Application.Queries;
using FoodShop.Application.Specifications.Categories;
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
        var spec = new CategoriesByFiltersSpecification(request.filters);
        var specWithoutPagination = new CategoriesByFiltersSpecification(request.filters.Where(f => !(f is IPaginationFilter)).ToArray());

        var categories = await _repository.GetCategoriesBySpecification(spec);

        var dtos = _mapper.Map<IEnumerable<CategoryDto>>(categories);

        var count = await _repository.CountCategoriesBySpecification(specWithoutPagination);

        IQueryResult queryResult = dtos.ToQueryResult(request.filters,count);

        return queryResult;
    }
}