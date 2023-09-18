using Dapper;
using LMS_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_DAL
{
    public class MenuItemRepository
    {
        public MenuItemViewModel GetAllSideMenuItem()
        {
            MenuItemViewModel menuitemresponse = new MenuItemViewModel();
            string sql = "[dbo].[Admin_GetAllSideMenu]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {

                }, commandType: CommandType.StoredProcedure);
                menuitemresponse.SideMenuItem = multi.Read<MenuItemModel>().ToList();
                menuitemresponse.Response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return menuitemresponse;
        }
        public ResponseMessageModel InsertPermission(string xmlstr)
        {

            ResponseMessageModel rmm = new ResponseMessageModel();
            string sql = "Setting_InsertScreenrolemapping";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new { flag = "1", xmlstr = xmlstr }, commandType: CommandType.StoredProcedure);
                rmm = multi.Read<ResponseMessageModel>().SingleOrDefault();
            }
            return rmm;

        }
    }
}
