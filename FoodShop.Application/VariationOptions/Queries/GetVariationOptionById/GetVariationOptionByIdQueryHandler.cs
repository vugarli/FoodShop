using AutoMapper;
using FoodShop.Application.Abstractions;
using MediatR;

namespace FoodShop.Application.VariationOptions.Queries.GetVariationOptionById;

public class GetVariationOptionByIdQueryHandler : IRequestHandler<GetVariationOptionByIdQuery,VariationOptionDto>
{
    private readonly IVariationOptionRepository _repository;
    private readonly IMapper _mapper;

    public GetVariationOptionByIdQueryHandler(IVariationOptionRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<VariationOptionDto> Handle(GetVariationOptionByIdQuery request, CancellationToken cancellationToken)
    {
        var variationOption = await _repository.GetVariationOptionByIdAsync(request.Id);
        var dto = _mapper.Map<VariationOptionDto>(variationOption);
        return dto;
    }
}