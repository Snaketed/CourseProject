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
    public class RegistManager : IRegistManager
    {
        private readonly IUsersDal _userDal;
        public RegistManager(IUsersDal userDal)
        {
            _userDal = userDal;
        }
        public UsersDTO CreateUser(string firstName, string lastName, string email, string phoneNumber, string password,
            string gender, string keyword)
        {
            return _userDal.CreateUser(firstName, lastName, email, phoneNumber, password,
            gender, keyword);
        }
    }
}
