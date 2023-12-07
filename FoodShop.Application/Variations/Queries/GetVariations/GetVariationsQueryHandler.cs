using AutoMapper;
using FoodShop.Application.Abstractions;
using FoodShop.Domain.Entities;
using MediatR;

namespace FoodShop.Application.Variations.Queries.GetVariations;

public class GetVariationsQueryHandler:IRequestHandler<GetVariationsQuery,IEnumerable<VariationDto>>
{
    private readonly IMapper _mapper;
    private readonly IVariationRepository _repository;

    public GetVariationsQueryHandler(IMapper mapper,IVariationRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<IEnumerable<VariationDto>> Handle(GetVariationsQuery request, CancellationToken cancellationToken)
    {
        var variations = await _repository.GetVariationsAsync();
        var variationDtos = _mapper.Map<IEnumerable<Variation>,IEnumerable<VariationDto>>(variations);
        return variationDtos;
    }
}