using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Model
{
    public class PermissionModel
    {
        public int UPS_UM_ID { get; set; }
        public int UPS_MI_ID { get; set; }
        public int UPS_Active { get; set; }

        public int UPS_Add { get; set; }
        public int UPS_Edit { get; set; }
        public int UPS_Delete { get; set; }
        public int UPS_View { get; set; }
        public int UPS_Main_MI_ID { get; set; }
    }

    public class PermissionViewmodel
    {
        public List<PermissionModel> permissionlst { get; set; }
        public ResponseStatusModel response { get; set; }
    }

    public class PermissionString
    {
        public string res { get; set; }
    }
    public class permission
    {
        public string RoleID
        {
            get; set;
        }
        public string MenuId
        {
            get; set;
        }
        public string SessionID
        {
            get;set;
        }
    }
}
