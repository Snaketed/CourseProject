using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IAuthManager
    {
        bool Login(string username, string password);
        long GetId(string email);

        void ForgotPass(string keyword, string password, string email);
    }
}
