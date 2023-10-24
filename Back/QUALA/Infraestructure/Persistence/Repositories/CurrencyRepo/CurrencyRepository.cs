using AutoMapper;
using Domain.Process.Currency;
using Infraestructure.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Repositories.CurrencyRepo
{
    internal class CurrencyRepository : ICurrencyRepository
    {

        private readonly QualaDbContext _context;
        private IMapper _mapper;

        public CurrencyRepository(QualaDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper;
        }

        public async Task<List<CurrencyDomain>> GetAll()
        {
            var currencies = await _context.Currencies.ToListAsync();
            var result = _mapper.Map<List<CurrencyDomain>>(currencies);
            
            return result;
        }
    }
}
