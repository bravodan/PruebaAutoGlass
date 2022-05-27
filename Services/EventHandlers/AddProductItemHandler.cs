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
            ProductItem objProductItemAdded = null;

            Supplier objSupplier = _unitOfWork.SupplierRepository.GetById(request.objProductItem.CurrentSupplierId);
            if (objSupplier != null)
            {
                ProductItem objProductItemToAdd = _mapper.Map<ProductItemCreateView, ProductItem>(request.objProductItem);
                objProductItemToAdd.ActiveProductState();
                objProductItemAdded = _unitOfWork.ProductItemRepository.Add(objProductItemToAdd);
                _unitOfWork.Complete();
                if (objProductItemAdded != null)
                {
                    _unitOfWork.ProductSupplierRepository.Add(new ProductSupplier(objProductItemAdded.Id, objSupplier.id, DateTime.Now, null));
                    _unitOfWork.Complete();
                }
                else
                {
                    throw new Exception("An error was ocurred saving the product item.");
                }

            }
            else
            {
                throw new Exception("El proveedor no existe");
            }
            return _mapper.Map<ProductItem, ProductItemCreateResponse>(objProductItemAdded);
        }
    }
}
