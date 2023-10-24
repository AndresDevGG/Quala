using Domain.Process.Currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Process.Currency
{
    public interface ICurrencyRepository
    {
        Task<List<CurrencyDomain>> GetAll();
    }
}
