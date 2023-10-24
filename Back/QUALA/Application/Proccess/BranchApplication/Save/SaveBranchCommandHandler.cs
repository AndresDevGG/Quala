
using Domain.Process.Branch;
using ErrorOr;
using MediatR;

namespace Application.Proccess.BranchApplication.Save
{
    public sealed class SaveBranchCommandHandler : IRequestHandler<SaveBranchCommand, ErrorOr<Unit>>
    {
        private readonly IBranchRepository _branchRepository;

        public SaveBranchCommandHandler(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository ?? throw new ArgumentNullException(nameof(branchRepository));
        }

        public async Task<ErrorOr<Unit>> Handle(SaveBranchCommand command, CancellationToken cancellationToken)
        {

            var branch = new BranchDomain(
                Guid.NewGuid(),
                command.Code,
                command.Description,
                command.Address,
                command.Identify,
                command.CreatedDate,
                command.Currency,
                true
            );

            _branchRepository.Save(branch);
            return Unit.Value;
        }
    }
}
