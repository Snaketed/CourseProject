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

        UsersDTO CreateUser(string firstName, string lastName, string email, string phoneNumber, string password,
            string gender, string keyword);

        long GetId(string email);
        void DeleteUser(long id);

        bool Login(string username, string password);
        void ForgotPass(string keyword, string password, string email);
    }
}
