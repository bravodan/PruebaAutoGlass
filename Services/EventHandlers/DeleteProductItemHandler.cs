using Domain.Entities;
using Domain.Enums;
using Domain.UnitOfWork;
using MediatR;
using Services.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Services.EventHandlers
{
    public class DeleteProductItemHandler : IRequestHandler<DeleteProductItemCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteProductItemHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteProductItemCommand request, CancellationToken cancellationToken)
        {
            ProductItem objProductItem = _unitOfWork.ProductItemRepository.GetById(request.Id);
            if (objProductItem != null)
            {
                if(objProductItem.ProductStatus != EProductStatus.inactivo)
                {
                    objProductItem.DeactiveProductState();
                    _unitOfWork.ProductItemRepository.Update(objProductItem);
                    _unitOfWork.Complete();
                }
                else
                {
                    throw new Exception("Producto eliminado con anterioridad");
                }
            }
            else
            {
                throw new Exception("Producto no existe");
            }

            return Unit.Value;
        }
    }
}
