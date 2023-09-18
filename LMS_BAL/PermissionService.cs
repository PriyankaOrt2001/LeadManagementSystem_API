using LMS_DAL;
using LMS_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_BAL
{
    public class PermissionService
    {
        PermissionRepository pr = new PermissionRepository();
        public ResponseStatusModel AddRolePermission(string RoleID, string MenuID,string SessionID)
        {
            return pr.AddRolePermission(RoleID,MenuID, SessionID);
        }
        public RolePermissionViewModel GetRolePermission(string RoleID)
        {
            return pr.GetRolePermission(RoleID);
        }
    }
}
