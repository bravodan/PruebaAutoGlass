using AutoMapper;
using Domain.Entities;
using Domain.UnitOfWork;
using MediatR;
using Services.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Services.EventHandlers
{
    public class UpdateProductItemHandler : IRequestHandler<UpdateProductItemCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateProductItemHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateProductItemCommand request, CancellationToken cancellationToken)
        {
            ProductItem objProduct = _unitOfWork.ProductItemRepository.GetById(request.bodyRequest.Id);
            if (objProduct != null)
            {
                Supplier objSupplier = _unitOfWork.SupplierRepository.GetById(request.bodyRequest.SupplierId);
                if (objSupplier == null)
                {
                    throw new Exception("El nuevo proveedor no existe");
                }
                objProduct.Update(request.bodyRequest.Description, request.bodyRequest.ProductStatus, request.bodyRequest.ManufacturingDate, request.bodyRequest.ValidityDate, objSupplier);
                _unitOfWork.ProductItemRepository.Update(objProduct);
                int varResult = _unitOfWork.Complete();
                if (varResult <= 0)
                {
                    throw new Exception("No se guardó la información en la base de datos");
                }
            }
            else
            {
                throw new Exception("El producto no existe");
            }
            return Unit.Value;
        }
    }
}
