﻿using AutoMapper;
using FoodShop.Application.Abstractions;
using FoodShop.Application.Queries;
using FoodShop.Domain.Entities;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FoodShop.Application.VariationOptions.Queries.GetVariationOptions;

public class GetVariationOptionsQueryHandler : IRequestHandler<GetPaginatedVariationOptionsQuery, PaginatedQueryResult<VariationOptionDto>>
{
    private readonly IVariationOptionRepository _repository;
    private readonly IMapper _mapper;

    public GetVariationOptionsQueryHandler(IVariationOptionRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<PaginatedQueryResult<VariationOptionDto>> Handle(GetPaginatedVariationOptionsQuery request, CancellationToken cancellationToken)
    {
        var variationOptions = await _repository.GetVariationOptionsAsync();
        var dtos = _mapper.Map<IEnumerable<VariationOptionDto>>(variationOptions);

        var count = await _repository.GetVariationOptionsCountAsync();

        var pModel = new PaginatedQueryResult<VariationOptionDto>(dtos, request.page, request.per_page, count);

        return pModel;
    }
}