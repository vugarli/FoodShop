using AutoMapper;
using FoodShop.Application.Abstractions;
using FoodShop.Application.Filters;
using FoodShop.Application.Queries;
using FoodShop.Application.VariationOptions;
using FoodShop.Domain.Entities;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FoodShop.Application.Variations.Queries.GetVariations;

public class GetVariationsQueryHandler:IRequestHandler<GetVariationsQuery, IQueryResult>
{
    private readonly IMapper _mapper;
    private readonly IVariationRepository _repository;

    public GetVariationsQueryHandler(IMapper mapper,IVariationRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<IQueryResult> Handle(GetVariationsQuery request, CancellationToken cancellationToken)
    {
        var variations = await _repository.GetFilteredVariationsAsync(request.filters);

        var dtos = _mapper.Map<IEnumerable<Variation>,IEnumerable<VariationDto>>(variations);
        
        var count = await _repository.GetVariationsCountAsync();

        IQueryResult queryResult = dtos.ToQueryResult(request.filters,count);

        return queryResult;
    }
}