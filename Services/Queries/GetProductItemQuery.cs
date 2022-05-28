using MediatR;
using Models.DTO;

namespace Services.Queries
{
    public record GetProductItemQuery(int Id) : IRequest<ProductItemGetResponse>;
}
