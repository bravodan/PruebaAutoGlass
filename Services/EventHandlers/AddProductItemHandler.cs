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
    public class AddProductItemHandler : IRequestHandler<AddProductItemCommand, ProductItemCreateResponse>

    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AddProductItemHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductItemCreateResponse> Handle(AddProductItemCommand request, CancellationToken cancellationToken)
        {
            ProductItem objProductItemAdded;

            Supplier objSupplier = _unitOfWork.SupplierRepository.GetById(request.objProductItem.SupplierId);
            if (objSupplier != null)
            {
                ProductItem objProductItemToAdd = new ProductItem(request.objProductItem.Description, request.objProductItem.ManufacturingDate, request.objProductItem.ValidityDate, objSupplier);
                objProductItemToAdd.ActiveProductState();
                objProductItemAdded = _unitOfWork.ProductItemRepository.Add(objProductItemToAdd);
                _unitOfWork.Complete();

            }
            else
            {
                throw new Exception("El proveedor no existe");
            }
            return _mapper.Map<ProductItem, ProductItemCreateResponse>(objProductItemAdded);
        }
    }
}
