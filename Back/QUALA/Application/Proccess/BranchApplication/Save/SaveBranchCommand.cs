

using ErrorOr;
using MediatR;

namespace Application.Proccess.BranchApplication.Save
{
    public record SaveBranchCommand(
        int Code,
        string Description,
        string Address,
        string Identify,
        DateTime CreatedDate,
        Guid Currency
    ) : IRequest<ErrorOr<Unit>>;
}
