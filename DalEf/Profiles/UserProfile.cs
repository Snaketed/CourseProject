using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DTO;

namespace DalEf.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UsersDTO>().ReverseMap();
            CreateMap<UserAddress, UserAddressDTO>().ReverseMap();
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<City, CityDTO>().ReverseMap();
            CreateMap<UserCardInfo, UserCardInfoDTO>().ReverseMap();
        }
    }
}
