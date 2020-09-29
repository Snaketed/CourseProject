using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL.Interfaces
{
    public interface IUsersDal
    {
        UsersDTO GetUserById(long id);
        List<UsersDTO> GetAllUsers();
        void UpdateUser(UsersDTO user);
        UsersDTO CreateUser(UsersDTO user);
        void DeleteUser(long id);
    }
}
