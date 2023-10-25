
using ErrorOr;
using MediatR;

namespace Application.Proccess.BranchApplication.Delete
{
    public record DeleteBranchCommand(Guid id) : IRequest<ErrorOr<Unit>>;
}
