using AutoMapper;
using FoodShop.Application.Abstractions;
using MediatR;

namespace FoodShop.Application.Variations.Queries.GetVariationById;

public class GetVariationByIdQueryHandler:IRequestHandler<GetVariationByIdQuery,VariationDto>
{
    private readonly IVariationRepository _repository;
    private readonly IMapper _mapper;

    public GetVariationByIdQueryHandler(IVariationRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<VariationDto> Handle(GetVariationByIdQuery request, CancellationToken cancellationToken)
    {
        var variation =  await _repository.GetVariationByIdAsync(request.Id);
        var dto = _mapper.Map<VariationDto>(variation);
        return dto;
    }
}