using FoodShop.Application.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.ProductEntries.Commands.DeleteProductEntries
{
    public class DeleteProductEntriesCommandHandler : IRequestHandler<DeleteProductEntriesCommand>
    {
        private IProductEntryRepository _productEntryRepository { get; }
        public DeleteProductEntriesCommandHandler(IProductEntryRepository productEntryRepository)
        {
            _productEntryRepository = productEntryRepository;
        }


        public async Task Handle(DeleteProductEntriesCommand request, CancellationToken cancellationToken)
        {
            await _productEntryRepository.DeleteProductEntriesAsync(request.Ids);
        }
    }
}
