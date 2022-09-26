using AutoMapper;
using NotOYO.Models;
namespace NotOYO.Models.DTO.Configuration
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();
            //CreateMap<Country, CountryDTO>().ReverseMap();
        }
    }
}
