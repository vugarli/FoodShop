using FoodShop.Application.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Variations.Commands.DeleteVariations
{
    public class DeleteVariationsCommandHandler : IRequestHandler<DeleteVariationsCommand>
    {

        private IVariationRepository _variationRepository { get; }
        public DeleteVariationsCommandHandler(IVariationRepository variationRepository)
        {
            _variationRepository = variationRepository;
        }


        public async Task Handle(DeleteVariationsCommand request, CancellationToken cancellationToken)
        {
            await _variationRepository.DeleteVariationsAsync(request.Ids);
        }
    }
}
