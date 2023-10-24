using Domain.Process.Currency;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Proccess.CurrencyApplication.GetCurrencies
{
    public record class CurrencyGetAllQuery() : IRequest<ErrorOr<IReadOnlyList<CurrencyDomain>>>;
}
