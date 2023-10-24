using Application.Proccess.CurrencyApplication.GetCurrencies;
using Domain.Process.Currency;
using Domain.Process.Currency;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Proccess.CurrencyApplication.GetAll
{
    public sealed class CurrencyGetAllQueryHandler : IRequestHandler<CurrencyGetAllQuery, ErrorOr<IReadOnlyList<CurrencyDomain>>>
    {

        private readonly ICurrencyRepository _currencyRepository;

        public CurrencyGetAllQueryHandler(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository ?? throw new ArgumentNullException(nameof(currencyRepository));
        }

        public async Task<ErrorOr<IReadOnlyList<CurrencyDomain>>> Handle(CurrencyGetAllQuery request, CancellationToken cancellationToken)
        {

            var loans = await _currencyRepository.GetAll();

            if (!loans.Any())
            {
                return Error.NotFound("mensaje", $"No hay prestamos.");
            }

            return loans;
        }
    }
}
