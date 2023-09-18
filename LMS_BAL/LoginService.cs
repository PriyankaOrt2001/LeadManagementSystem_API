using LMS_DAL;
using LMS_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_BAL
{
    public class LoginService
    {
        LoginRepository lr = new LoginRepository();

        public UserResponseModelViewModel login(LoginModel login)
        {
            return lr.Login(login);
        }
    }
}
