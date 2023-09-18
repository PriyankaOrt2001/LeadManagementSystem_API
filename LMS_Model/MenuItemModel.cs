using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Model
{
    public class MenuItemModel
    {
        public long MenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuControllerName { get; set; }
        public string MenuActionName { get; set; }
        public string MenuIcon { get; set; }
        public long MenuParentId { get; set; }
        public string Status { get; set; }
    }
    public class MenuItemViewModel
    {
        public List<MenuItemModel> SideMenuItem { get; set; }
        public ResponseStatusModel Response { get; set; }
    }

    public class RolePermissionModel
    {
        public int Id { get; set; }
        public long MenuId { get; set; }
        public long RoleId { get; set; }
        public string ActionName { get; set; }
    }


    public class RolePermissionViewModel
    {
        public List<RolePermissionModel> rolepermission { get; set; }
        public ResponseStatusModel Response { get; set; }
    }
}
