using MediatR;
using Models.DTO;

namespace Services.Commands
{
    public record UpdateProductItemCommand(ProductItemUpdateView bodyRequest) : IRequest;
}
