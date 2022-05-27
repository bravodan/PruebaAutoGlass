using MediatR;
using Models.DTO;

namespace Services.Commands
{
    public record AddProductItemCommand(ProductItemCreateView objProductItem) : IRequest<ProductItemCreateResponse>;
}
