using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BusinessLogic.Interfaces
{
    public interface IUserInfoManager
    {
        UserAddressDTO CreateUserAddress(UserAddressDTO user);
        UserCardInfoDTO CreateUserCardInfo(UserCardInfoDTO user);

        UsersDTO GetUserById(long id);

        List<CityDTO> GetAllCity();
        List<CountryDTO> GetAllCountry();
        CountryDTO GetCountryById(long id);
        CityDTO GetCityById(long id);

        UserAddressDTO GetUserAddressById(long id);
        void UpdateUserAddress(UserAddressDTO user);
        void UpdateUserCardInfo(UserCardInfoDTO user);
        UserCardInfoDTO GetCardInfoById(long id);

    }
}
