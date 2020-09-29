using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL.Interfaces
{
    public interface IUserCardInfoDal
    {
        UserCardInfoDTO GetUserCardInfoById(long id);
        List<UserCardInfoDTO> GetAllUserCardInfo();
        void UpdateUserCardInfo(UserCardInfoDTO user);
        UserCardInfoDTO CreateUserCardInfo(UserCardInfoDTO user);
        void DeleteUserCardInfo(long id);
    }
}
