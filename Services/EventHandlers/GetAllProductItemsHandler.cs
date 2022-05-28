using AutoMapper;
using Domain.Entities;
using Domain.Pagination;
using Domain.UnitOfWork;
using MediatR;
using Services.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace Services.EventHandlers
{
    public class GetAllProductItemsHandler : IRequestHandler<GetAllProductItemsQuery, PagedList<ProductItem>>

    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllProductItemsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedList<ProductItem>> Handle(GetAllProductItemsQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.ProductItemRepository.GetProductItems(request.parameters);
            
        }
    }
}
