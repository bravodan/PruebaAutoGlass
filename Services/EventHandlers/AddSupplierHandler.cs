using AutoMapper;
using Domain.Entities;
using Domain.UnitOfWork;
using MediatR;
using Models.DTO;
using Services.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace Services.EventHandlers
{
    public class AddSupplierHandler : IRequestHandler<AddSupplierCommand, SupplierView>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AddSupplierHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SupplierView> Handle(AddSupplierCommand request, CancellationToken cancellationToken)
        {
            SupplierView objSupplierAdded = null;
            Supplier objSupplierToAdd = _mapper.Map<SupplierView, Supplier>(request.objSupplier);
            if (_unitOfWork.SupplierRepository.GetById(request.objSupplier.id) == null)
            {
                objSupplierAdded = _mapper.Map<Supplier, SupplierView>(_unitOfWork.SupplierRepository.Add(objSupplierToAdd));
                _unitOfWork.Complete();
            }

            return objSupplierAdded;
        }
    }
}
