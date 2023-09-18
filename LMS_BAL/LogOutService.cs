using LMS_DAL;
using LMS_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_BAL
{
    public class LogOutService
    {
        LogOutRepository lr = new LogOutRepository();

        public ResponseStatusModel LogOut(string UserId)
        {
            return lr.LogOut(UserId);
        }
    }
}
