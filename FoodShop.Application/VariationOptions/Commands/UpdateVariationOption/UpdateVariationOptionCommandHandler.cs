using AutoMapper;
using FoodShop.Application.Abstractions;
using FoodShop.Domain.Abstractions;
using FoodShop.Domain.Entities;
using MediatR;

namespace FoodShop.Application.VariationOptions.Commands.UpdateVariationOption;

public class UpdateVariationOptionCommandHandler : IRequestHandler<UpdateVariationOptionCommand,VariationOptionDto>
{
    private readonly IVariationOptionRepository _repository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVariationOptionCommandHandler(IVariationOptionRepository repository,IMapper mapper, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<VariationOptionDto> Handle(UpdateVariationOptionCommand request, CancellationToken cancellationToken)
    {
        var variationOption = _mapper.Map<VariationOption>(request);
        await _repository.UpdateVariationOptionAsync(variationOption);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        var dto = _mapper.Map<VariationOptionDto>(variationOption);
        return dto;
    }
}