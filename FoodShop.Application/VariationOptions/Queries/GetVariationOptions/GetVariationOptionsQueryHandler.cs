using AutoMapper;
using FoodShop.Application.Abstractions;
using MediatR;

namespace FoodShop.Application.VariationOptions.Queries.GetVariationOptions;

public class GetVariationOptionsQueryHandler : IRequestHandler<GetVariationOptionsQuery,IEnumerable<VariationOptionDto>>
{
    private readonly IVariationOptionRepository _repository;
    private readonly IMapper _mapper;

    public GetVariationOptionsQueryHandler(IVariationOptionRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<VariationOptionDto>> Handle(GetVariationOptionsQuery request, CancellationToken cancellationToken)
    {
        var variationOptions = await _repository.GetVariationOptionsAsync();
        var dtos = _mapper.Map<IEnumerable<VariationOptionDto>>(variationOptions);
        return dtos;
    }
}