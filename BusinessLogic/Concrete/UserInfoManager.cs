using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using DAL.Interfaces;
using DTO;

namespace BusinessLogic.Concrete
{
    public class UserInfoManager : IUserInfoManager
    {
        private readonly IUsersDal _userDal;
        private readonly IUserCardInfoDal _userCardInfoDal;
        private readonly IUserAddressDal _userAddressDal;
        private readonly ICityDal _cityDal;
        private readonly ICountryDal _countryDal;

        public UserInfoManager(IUsersDal userDal, IUserAddressDal userAddressDal, IUserCardInfoDal userCardInfoDal,
            ICityDal cityDal, ICountryDal countryDal)
        {
            _userDal = userDal;
            _userCardInfoDal = userCardInfoDal;
            _userAddressDal = userAddressDal;
            _cityDal = cityDal;
            _countryDal = countryDal;
        }




        public UserAddressDTO CreateUserAddress(UserAddressDTO user)
        {
            return _userAddressDal.CreateUserAddress(user);
        }

        public UserCardInfoDTO CreateUserCardInfo(UserCardInfoDTO user)
        {
            return _userCardInfoDal.CreateUserCardInfo(user);
        }

        public UsersDTO GetUserById(long id)
        {
            return _userDal.GetUserById(id);
        }

        public List<CityDTO> GetAllCity()
        {
            return _cityDal.GetAllCity();
        }

        public List<CountryDTO> GetAllCountry()
        {
            return _countryDal.GetAllCountry();
        }

        public CountryDTO GetCountryById(long id)
        {
            return _countryDal.GetCountryById(id);
        }

        public CityDTO GetCityById(long id)
        {
            return _cityDal.GetCityById(id);
        }

        public UserAddressDTO GetUserAddressById(long id)
        {
            return _userAddressDal.GetUserAddressById(id);
        }

        public UserCardInfoDTO GetCardInfoById(long id)
        {
            return _userCardInfoDal.GetUserCardInfoById(id);
        }

        public void UpdateUserAddress(UserAddressDTO user)
        {
            _userAddressDal.UpdateUserAddress(user);
        }

        public void UpdateUserCardInfo(UserCardInfoDTO user)
        {
            _userCardInfoDal.UpdateUserCardInfo(user);
        }
    }
}
