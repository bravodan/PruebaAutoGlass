using AutoMapper;
using Domain.Entities;
using Domain.UnitOfWork;
using MediatR;
using Models.DTO;
using Services.Queries;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Services.EventHandlers
{
    public class GetProductItemHandler : IRequestHandler<GetProductItemQuery, ProductItemGetResponse>

    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetProductItemHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductItemGetResponse> Handle(GetProductItemQuery request, CancellationToken cancellationToken)
        {
            ProductItem objProductItem = _unitOfWork.ProductItemRepository.GetById(request.Id);
            if (objProductItem == null)
            {
                throw new Exception("Producto no existe");
            }
            return _mapper.Map<ProductItem, ProductItemGetResponse>(objProductItem);
        }
    }
}
