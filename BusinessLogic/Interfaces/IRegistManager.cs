using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BusinessLogic.Interfaces
{
    public interface IRegistManager
    {
        UsersDTO CreateUser(string firstName, string lastName, string email, string phoneNumber, string password,
            string gender, string keyword);
    }
}
