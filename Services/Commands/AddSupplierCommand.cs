using MediatR;
using Models.DTO;

namespace Services.Commands
{
    public record AddSupplierCommand(SupplierView objSupplier) : IRequest<SupplierView>;
}
