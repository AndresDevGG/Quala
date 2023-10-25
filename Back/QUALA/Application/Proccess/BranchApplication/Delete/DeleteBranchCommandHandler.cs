using Domain.Process.Branch;
using ErrorOr;
using MediatR;

namespace Application.Proccess.BranchApplication.Delete
{
    public sealed class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommand, ErrorOr<Unit>>
    {
        private readonly IBranchRepository _branchRepository;

        public DeleteBranchCommandHandler(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository ?? throw new ArgumentNullException(nameof(branchRepository));
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteBranchCommand command, CancellationToken cancellationToken)
        {
            _branchRepository.Delete(command.id);
            return Unit.Value;
        }
    }
}
