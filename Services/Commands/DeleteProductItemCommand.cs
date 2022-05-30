using MediatR;

namespace Services.Commands
{
    public record DeleteProductItemCommand(long Id) : IRequest;
}
