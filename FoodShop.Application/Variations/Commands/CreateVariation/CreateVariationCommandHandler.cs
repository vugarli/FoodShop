using AutoMapper;
using FoodShop.Application.Abstractions;
using FoodShop.Domain.Abstractions;
using FoodShop.Domain.Entities;
using MediatR;

namespace FoodShop.Application.Variations.Commands.CreateVariation;

public class CreateVariationCommandHandler : IRequestHandler<CreateVariationCommand,VariationDto>
{
    private readonly IVariationRepository _repository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateVariationCommandHandler(IVariationRepository repository,IMapper mapper,IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<VariationDto> Handle(CreateVariationCommand request, CancellationToken cancellationToken)
    {
        var variation = _mapper.Map<Variation>(request);
        await _repository.CreateVariationAsync(variation);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        var dto = _mapper.Map<VariationDto>(variation);
        return dto;
    }
}