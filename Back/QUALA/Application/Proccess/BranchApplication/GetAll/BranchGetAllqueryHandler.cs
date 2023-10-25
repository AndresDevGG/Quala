
using Application.Proccess.BranchApplication.Common;
using Domain.Process.Branch;
using ErrorOr;
using MediatR;

namespace Application.Proccess.BranchApplication.GetAll
{
    public sealed class BranchGetAllqueryHandler : IRequestHandler<BranchGetAllquery, ErrorOr<IReadOnlyList<BranchGetAllDTO>>>
    {

        private readonly IBranchRepository _branchRepository;

        public BranchGetAllqueryHandler(IBranchRepository currencyRepository)
        {
            _branchRepository = currencyRepository ?? throw new ArgumentNullException(nameof(currencyRepository));
        }

        public async Task<ErrorOr<IReadOnlyList<BranchGetAllDTO>>> Handle(BranchGetAllquery request, CancellationToken cancellationToken)
        {

            IReadOnlyList<BranchDomain> loans = await _branchRepository.GetAll();

            var result = loans.Select(x => new BranchGetAllDTO(
                    x.Id,
                    x.Code,
                    x.Description,
                    x.Address,
                    x.Identify,
                    x.Created,
                    x.CurrencyCode,
                    x.Active
                ))
                .ToList();

            if (!result.Any())
            {
                return Error.NotFound("mensaje", $"No hay sedes.");
            }

            return result;
        }
    }
}
