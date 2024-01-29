using AutoMapper;
using FoodShop.Application.Abstractions;
using FoodShop.Application.Queries;
using FoodShop.Application.Variations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Categories.Queries.GetVariations
{
    public class GetVariationsQueryHandler : IRequestHandler<GetVariationsQuery, QueryResult<VariationDto>>
    {
        private ICategoryRepository _categoryRepository { get; }
        private IMapper _mapper { get; }

        public GetVariationsQueryHandler(ICategoryRepository categoryRepository,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<QueryResult<VariationDto>> Handle(GetVariationsQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(request.categoryId);
            var dtos = _mapper.Map<IEnumerable<VariationDto>>(category.Variations);

            var queryResult = new QueryResult<VariationDto>(dtos);
            return queryResult;
        }
    }
}
