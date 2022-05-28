using MediatR;

namespace Services.Commands
{
    public record DeleteProductItemCommand(int Id) : IRequest;
}
