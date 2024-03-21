using AutoMapper;
using Shortly_Client.Data.ViewModels;
using Shortly_Data.Models;

namespace Shortly_Client.Data.Mapper
{
    //for this class to become the default mapping file or the mapping configuration file, you need to inherit from the base class profile, which belong to Automapper library
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Here we are mapping the Url Object to GetUrlVM

            CreateMap<Url, GetUrlVM>().ReverseMap();

            //Here we are mapping User with the GetUserVM

            CreateMap<AppUser, GetUserVM>().ReverseMap();
        }
        
    }
}
