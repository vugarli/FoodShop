using AutoMapper;
using FoodShop.Application.Abstractions;
using FoodShop.Domain.Abstractions;
using FoodShop.Domain.Entities;
using MediatR;

namespace FoodShop.Application.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery,CategoryDto>
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;

    public GetCategoryByIdQueryHandler(ICategoryRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _repository.GetCategoryByIdAsync(request.Id);
        var dto = _mapper.Map<CategoryDto>(category);

        return dto;
    }
}