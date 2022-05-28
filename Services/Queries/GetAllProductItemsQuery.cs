using Domain.Entities;
using Domain.Pagination;
using Domain.QueryParams;
using MediatR;

namespace Services.Queries
{
    public record GetAllProductItemsQuery(ProductItemParameters parameters) : IRequest<PagedList<ProductItem>>;
}
