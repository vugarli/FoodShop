using AutoMapper;
using FoodShop.Application.Abstractions;
using FoodShop.Application.Filters;
using FoodShop.Application.Products;
using FoodShop.Application.Queries;
using FoodShop.Domain.Entities;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FoodShop.Application.VariationOptions.Queries.GetVariationOptions;

public class GetVariationOptionsQueryHandler : IRequestHandler<GetVariationOptionsQuery, IQueryResult>
{
    private readonly IVariationOptionRepository _repository;
    private readonly IMapper _mapper;

    public GetVariationOptionsQueryHandler(IVariationOptionRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<IQueryResult> Handle(GetVariationOptionsQuery request, CancellationToken cancellationToken)
    {
        var variationOptions = await _repository.GetFilteredVariationOptionsAsync(request.filters);
        var dtos = _mapper.Map<IEnumerable<VariationOptionDto>>(variationOptions);

        var count = await _repository.GetVariationOptionsCountAsync();

        IQueryResult queryResult = dtos.ToQueryResult(request.filters,count);

        return queryResult;
    }
}