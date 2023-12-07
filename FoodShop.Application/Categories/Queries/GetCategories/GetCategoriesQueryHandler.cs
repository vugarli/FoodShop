using AutoMapper;
using FoodShop.Application.Abstractions;
using MediatR;

namespace FoodShop.Application.Categories.Queries.GetCategories;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery,IEnumerable<CategoryDto>>
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;

    public GetCategoriesQueryHandler(ICategoryRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    
    public async Task<IEnumerable<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _repository.GetCategoriesAsync();
        var categoryDtos = _mapper.Map<IEnumerable<CategoryDto>>(categories);
        return categoryDtos;
    }
}