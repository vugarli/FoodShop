using AutoMapper;
using FoodShop.Application.Abstractions;
using FoodShop.Domain.Abstractions;
using FoodShop.Domain.Entities;
using MediatR;

namespace FoodShop.Application.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand,CategoryDto>
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoryCommandHandler(ICategoryRepository repository,IMapper mapper,IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<CategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Category>(request);
        await _repository.UpdateCategoryAsync(category);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        var categoryDto = _mapper.Map<CategoryDto>(category);
        return categoryDto;
    }
}