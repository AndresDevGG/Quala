
using AutoMapper;
using Domain.Process.Branch;
using Infraestructure.Model;

namespace Infraestructure.Mapper.MapperBranch
{
    internal class MapperBranch : Profile
    {

        public MapperBranch()
        {
            CreateMap<Branch, BranchDomain>();
                //.ForMember(dest => dest.Currency, org => org.MapFrom(src => src.Currency.Code));

            CreateMap<BranchDomain, Branch>()
                .ForMember(dest => dest.Id, org => org.MapFrom(src => src.Id))
                .ForMember(dest => dest.Code, org => org.MapFrom(src => src.Code))
                .ForMember(dest => dest.Description, org => org.MapFrom(src => src.Description))
                .ForMember(dest => dest.Address, org => org.MapFrom(src => src.Address))
                .ForMember(dest => dest.Identify, org => org.MapFrom(src => src.Identify))
                .ForMember(dest => dest.Created, org => org.MapFrom(src => src.Created))
                .ForMember(dest => dest.CurrencyId, org => org.MapFrom(src => src.CurrencyId))
                .ForMember(dest => dest.Active, org => org.MapFrom(src => src.Active));
                //.ForMember(dest => dest.Currency, org => org.Ignore()); ;
        }
    }
}
