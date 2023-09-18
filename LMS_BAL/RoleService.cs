using LMS_DAL;
using LMS_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_BAL
{
    public class RoleService
    {
        readonly RoleRepository repository = new RoleRepository();
        public RoleDetailsModel GetRoleDetailsList()
        {
            return repository.GetRoleDetailsList();
        }
        public ResponseStatusModel AddNewRole(RoleDetails rd)
        {
            return repository.AddNewRole(rd);
        }
        public ResponseStatusModel UpdateRole(RoleDetails rd)
        {
            return repository.UpdateRole(rd);
        }
        public ResponseStatusModel RemoveRole(int Role_Id)
        {
            return repository.RemoveRole(Role_Id);
        }
        public RoleDetails ViewRole(int Role_Id)
        {
            return repository.ViewRole(Role_Id);
        }
    }
}
