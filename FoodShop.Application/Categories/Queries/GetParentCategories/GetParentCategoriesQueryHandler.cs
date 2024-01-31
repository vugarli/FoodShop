using AutoMapper;
using FoodShop.Application.Abstractions;
using FoodShop.Application.Specifications.Categories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Categories.Queries.GetParentCategories
{
    public class GetParentCategoriesQueryHandler : IRequestHandler<GetParentCategoriesQuery, IEnumerable<CategoryDto>>
    {
        public ICategoryRepository _repository { get; set; }
        public IMapper _mapper { get; set; }    

        public GetParentCategoriesQueryHandler(ICategoryRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoryDto>> Handle(GetParentCategoriesQuery request, CancellationToken cancellationToken)
        {
            var spec = new ParentCategorySpecification();

            var data= await _repository.GetCategoriesBySpecification(spec);

            var result = _mapper.Map<IEnumerable<CategoryDto>>(data);
            return result;
        }
    }
}
