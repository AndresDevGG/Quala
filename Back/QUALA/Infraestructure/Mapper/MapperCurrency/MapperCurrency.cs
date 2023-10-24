using AutoMapper;
using Domain.Process.Currency;
using Infraestructure.Model;

namespace Infraestructure.Mapper.MapperCurrency
{
    public class MapperCurrency : Profile
    {

        public MapperCurrency()
        {
            CreateMap<Currency, CurrencyDomain>();
        }
    }
}
