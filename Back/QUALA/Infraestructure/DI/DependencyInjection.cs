using AutoMapper;
using Domain.Process.Branch;
using Domain.Process.Currency;
using Infraestructure.Mapper.MapperBranch;
using Infraestructure.Mapper.MapperCurrency;
using Infraestructure.Model;
using Infraestructure.Persistence.Repositories.BranchRepo;
using Infraestructure.Persistence.Repositories.CurrencyRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistence(configuration);
            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<QualaDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DBConnection")));

            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();

            var mapperconfig = new MapperConfiguration(m =>
            {
                m.AddProfile(new MapperCurrency());
                m.AddProfile(new MapperBranch());
            });

            IMapper mapper = mapperconfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
