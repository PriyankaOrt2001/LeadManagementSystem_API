using LMS_DAL;
using LMS_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_BAL
{
    public class MenuItemService
    {
        MenuItemRepository mir = new MenuItemRepository();
        public MenuItemViewModel GetAllSideMenuItem()
        {
            return mir.GetAllSideMenuItem();
        }

    }
}
