using AutoMapper;
using FoodShop.Application.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.BaseCategoryDiscriminators.Queries.GetBaseCategoryDiscriminators
{
    public class GetBaseCategoryDiscriminatorsQueryHandler
        : IRequestHandler<GetBaseCategoryDiscriminatorsQuery, IEnumerable<BaseCategoryDiscriminatorDto>>
    {

        public IBaseCategoryDiscriminatorRepository _repository { get; set; }
        public IMapper _mapper { get; set; }

        public GetBaseCategoryDiscriminatorsQueryHandler(IMapper mapper,IBaseCategoryDiscriminatorRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BaseCategoryDiscriminatorDto>> Handle(GetBaseCategoryDiscriminatorsQuery request, CancellationToken cancellationToken)
        {
            var res = await _repository.GetBaseCategoryDiscriminatorsAsync();
            var m = _mapper.Map<IEnumerable<BaseCategoryDiscriminatorDto>>(res);
            return m;
        }
    }
}
