using AutoMapper;
using FoodShop.Application.Abstractions;
using FoodShop.Domain.Abstractions;
using FoodShop.Domain.Entities;
using MediatR;

namespace FoodShop.Application.Categories.Commands.CreateCategory;

public class CategoryCreateCommandHandler : IRequestHandler<CreateCategoryCommand,CategoryDto>
{
    private readonly ICategoryRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoryCreateCommandHandler(ICategoryRepository repository,IUnitOfWork unitOfWork,IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    
    public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Category>(request);

        await _repository.CreateCategoryAsync(category);

        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        var categoryDto = _mapper.Map<CategoryDto>(category);
        return categoryDto;
    }
}