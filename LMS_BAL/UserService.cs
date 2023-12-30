using LMS_DAL;
using LMS_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_BAL
{
    public class UserService
    {
        readonly UserRepository repository = new UserRepository();
        public UserResponseModelViewModel GetUserList()
        {
            return repository.GetUserList();
        }
        public ResponseStatusModel AddNewUser(UserModel um)
        {
            return repository.AddNewUser(um);
        }
        
    }
}
