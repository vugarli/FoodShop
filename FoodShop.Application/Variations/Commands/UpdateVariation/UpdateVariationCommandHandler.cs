using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using FoodShop.Application.Abstractions;
using FoodShop.Domain.Abstractions;
using FoodShop.Domain.Entities;
using MediatR;

namespace FoodShop.Application.Variations.Commands.UpdateVariation;

public class UpdateVariationCommandHandler : IRequestHandler<UpdateVariationCommand,VariationDto>
{
    private readonly IMapper _mapper;
    private readonly IVariationRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVariationCommandHandler(IMapper mapper,IVariationRepository repository,IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<VariationDto> Handle(UpdateVariationCommand request, CancellationToken cancellationToken)
    {
        var variation = _mapper.Map<Variation>(request);
        await _repository.UpdateVariationAsync(variation);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        var dto = _mapper.Map<VariationDto>(variation);
        return dto;
    }
}