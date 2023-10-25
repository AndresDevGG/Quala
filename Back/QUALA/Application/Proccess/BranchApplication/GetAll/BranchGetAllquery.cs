using Application.Proccess.BranchApplication.Common;
using ErrorOr;
using MediatR;

namespace Application.Proccess.BranchApplication.GetAll
{
    public record class BranchGetAllquery() : IRequest<ErrorOr<IReadOnlyList<BranchGetAllDTO>>>;
}
