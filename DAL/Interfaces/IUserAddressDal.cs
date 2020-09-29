using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL.Interfaces
{
    public interface IUserAddressDal
    {
        UserAddressDTO GetUserAddressById(long id);
        List<UserAddressDTO> GetAllUserAddress();
        void UpdateUserAddress(UserAddressDTO user);
        UserAddressDTO CreateUserAddress(UserAddressDTO user);
        void DeleteUserAddress(long id);
    }
}
