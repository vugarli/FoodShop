using System.Net.Http.Headers;
using AutoMapper;
using FoodShop.Application.Abstractions;
using FoodShop.Domain.Abstractions;
using FoodShop.Domain.Entities;
using MediatR;

namespace FoodShop.Application.VariationOptions.Commands.CreateVariationOption;

public class CreateVariationOptionCommandHandler : IRequestHandler<CreateVariationOptionCommand,VariationOptionDto>
{
    private readonly IVariationOptionRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateVariationOptionCommandHandler(IVariationOptionRepository repository,IUnitOfWork unitOfWork,IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<VariationOptionDto> Handle(CreateVariationOptionCommand request, CancellationToken cancellationToken)
    {
        var variationOption = _mapper.Map<VariationOption>(request);
        await _repository.CreateVariationOptionAsync(variationOption);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        var dto = _mapper.Map<VariationOptionDto>(variationOption);
        return dto;
    }
}