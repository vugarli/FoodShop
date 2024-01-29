using FoodShop.Application.Abstractions;
using FoodShop.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Categories.Commands.RemoveVariation
{
    public class RemoveVariationCommandHandler : IRequestHandler<RemoveVariationCommand>
    {
        private ICategoryRepository _categoryRepository { get; }
        private IUnitOfWork _unitOfWork { get; }

        public RemoveVariationCommandHandler(ICategoryRepository categoryRepository,IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task Handle(RemoveVariationCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(request.CategoryId);
            category.RemoveVariation(request.VariationId);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
