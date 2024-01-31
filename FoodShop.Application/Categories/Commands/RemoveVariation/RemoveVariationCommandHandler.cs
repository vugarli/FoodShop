using FoodShop.Application.Abstractions;
using FoodShop.Application.Specifications.Categories;
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
            var spec = new CategoryByIdWithVariationsSpecification(request.CategoryId);

            var category = await _categoryRepository.GetCategoryBySpecification(spec);
            
            category.RemoveVariation(request.VariationId);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
