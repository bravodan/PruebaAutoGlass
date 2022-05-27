using AutoMapper;
using Domain.Entities;
using Domain.UnitOfWork;
using MediatR;
using Models.DTO;
using Services.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Services.EventHandlers
{
    public class UpdateProductItemHandler : IRequestHandler<UpdateProductItemCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateProductItemHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductItemCommand request, CancellationToken cancellationToken)
        {
            ProductItem objProduct = _unitOfWork.ProductItemRepository.GetById(request.bodyRequest.Id);
            if (objProduct != null)
            {;
                if (request.bodyRequest.CurrentSupplierId != null && request.bodyRequest.CurrentSupplierId.Trim(' ') != "" && !Equals(request.bodyRequest.ObjNewSupplier, null))
                {
                    objProduct.Update(request.bodyRequest.Description, request.bodyRequest.ProductStatus, request.bodyRequest.ManufacturingDate, request.bodyRequest.ValidityDate,
                        request.bodyRequest.CurrentSupplierId, _mapper.Map<SupplierView, Supplier>(request.bodyRequest.ObjNewSupplier));
                }
                else
                {
                    objProduct.Update(request.bodyRequest.Description, request.bodyRequest.ProductStatus, request.bodyRequest.ManufacturingDate, request.bodyRequest.ValidityDate);
                }
                int varResult = _unitOfWork.Complete();
                if (varResult <= 0)
                {
                    throw new Exception("No se guardó la información en la base de datos");
                }
            }
            return Unit.Value;
        }
    }
}
