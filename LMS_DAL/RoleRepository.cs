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
    public class RoleRepository
    {
        public RoleDetailsModel GetRoleDetailsList()
        {
            RoleDetailsModel rdm = new RoleDetailsModel();
            string sql = "[SP_GetRoleDetailsList]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {

                }, commandType: CommandType.StoredProcedure);
                rdm.RoleList = multi.Read<RoleDetails>().ToList();
            }
            return rdm;
        }
        public ResponseStatusModel AddNewRole(RoleDetails rd)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_AddNewRole]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    Role_Name = rd.Role_Name
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public ResponseStatusModel UpdateRole(RoleDetails rd)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_UpdateRole]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    Role_Id = rd.Role_Id,
                    Role_Name = rd.Role_Name
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public ResponseStatusModel RemoveRole(int Role_Id)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_RemoveRole]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    Role_Id = Role_Id
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public RoleDetails ViewRole(int Role_Id)
        {
            RoleDetails rd = new RoleDetails();
            string sql = "[SP_ViewRole]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    Role_Id = Role_Id
                },
                commandType: CommandType.StoredProcedure);
                rd = multi.Read<RoleDetails>().SingleOrDefault();
            }
            return rd;
        }
    }
}
