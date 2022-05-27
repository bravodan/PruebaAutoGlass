using MediatR;
using Models.DTO;

namespace Commands
{
    public record AddSupplierCommand(SupplierView ParSupplier) : IRequest<SupplierView>;
}
