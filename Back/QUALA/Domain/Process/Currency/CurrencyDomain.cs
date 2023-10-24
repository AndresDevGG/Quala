using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Process.Currency
{
    public class CurrencyDomain
    {
        public CurrencyDomain(Guid id, string code, string name) {
            Id = id;
            Code = code;
            Name = name;
        }
        public Guid Id { get; set; }

        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;

    }
}
