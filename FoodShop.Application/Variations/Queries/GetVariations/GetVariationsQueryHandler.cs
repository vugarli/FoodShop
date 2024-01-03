using AutoMapper;
using FoodShop.Application.Abstractions;
using FoodShop.Application.Queries;
using FoodShop.Domain.Entities;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FoodShop.Application.Variations.Queries.GetVariations;

public class GetVariationsQueryHandler:IRequestHandler<GetPaginatedVariationsQuery, PaginatedQueryResult<VariationDto>>
{
    private readonly IMapper _mapper;
    private readonly IVariationRepository _repository;

    public GetVariationsQueryHandler(IMapper mapper,IVariationRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<PaginatedQueryResult<VariationDto>> Handle(GetPaginatedVariationsQuery request, CancellationToken cancellationToken)
    {
        var variations = await _repository.GetVariationsAsync();
        var variationDtos = _mapper.Map<IEnumerable<Variation>,IEnumerable<VariationDto>>(variations);
        var count = await _repository.GetVariationsCountAsync();

        var pModel = new PaginatedQueryResult<VariationDto>(variationDtos, request.page, request.per_page, count);

        return pModel;
    }
}