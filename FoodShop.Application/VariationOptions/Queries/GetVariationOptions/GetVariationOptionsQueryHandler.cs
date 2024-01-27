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

        IQueryResult queryResult;

        //temp
        if (request.filters.Any(f => f is PaginationFilter<VariationOption>))
        {
            var pFilter = (PaginationFilter<VariationOption>)request.filters.FirstOrDefault(c => c is PaginationFilter<VariationOption>);

            if (pFilter != null && pFilter.per_page != null && pFilter.page != null)
                queryResult = new PaginatedQueryResult<VariationOptionDto>(dtos, (int)pFilter.page, (int)pFilter.per_page, count);
            else
                queryResult = new QueryResult<VariationOptionDto>(dtos);
        }
        else
            queryResult = new QueryResult<VariationOptionDto>(dtos);

        return queryResult;
    }
}