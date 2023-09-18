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
    public class PermissionRepository
    {
        public ResponseStatusModel InsertPermission(string xmlstr)
        {

            ResponseStatusModel rmm = new ResponseStatusModel();
            string sql = "Setting_InsertScreenrolemapping";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new { flag = "1", xmlstr = xmlstr }, commandType: CommandType.StoredProcedure);
                rmm = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return rmm;
        }
        public ResponseStatusModel AddRolePermission(string RoleID, string MenuID,string SessionID)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[dbo].[Admin_AddRolePermission]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    RoleID = RoleID,
                    MenuID = MenuID,
                    SessionID = SessionID
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public RolePermissionViewModel GetRolePermission(string RoleID)
        {
            RolePermissionViewModel permissionresponse = new RolePermissionViewModel();
            string sql = "[dbo].[Admin_GetRolePermission]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    RoleID = RoleID
                }, commandType: CommandType.StoredProcedure);
                permissionresponse.rolepermission = multi.Read<RolePermissionModel>().ToList();
                permissionresponse.Response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return permissionresponse;
        }
    }
}
