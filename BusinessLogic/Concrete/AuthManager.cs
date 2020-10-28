using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using DAL.Interfaces;

namespace BusinessLogic.Concrete
{
    public class AuthManager: IAuthManager
    {

        private readonly IUsersDal _userDal;
        public AuthManager(IUsersDal userDal)
        {
            _userDal = userDal;
        }

        public bool Login(string username, string password)
        {
            return _userDal.Login(username, password);
        }
        public long GetId(string email)
        {
            return _userDal.GetId(email);
        }

        public void ForgotPass(string keyword, string password, string email)
        { 
            _userDal.ForgotPass(keyword, password,email);
        }
    }
}
