using AutoMapper;
using HotelListing.API.Data;
using HotelListing.API.Models.Country;

namespace HotelListing.API.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            // reverse map allows you to map in either direction
            CreateMap<Country, CreateCountryDto>().ReverseMap();
        }
    }
}
