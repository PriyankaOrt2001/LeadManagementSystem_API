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
    public class UserRepository
    {
        public UserResponseModelViewModel GetUserList()
        {
            UserResponseModelViewModel um = new UserResponseModelViewModel();
            string sql = "[SP_GetUserList]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {

                }, commandType: CommandType.StoredProcedure);
                um.usermodellist = multi.Read<UserModel>().ToList();
            }
            return um;
        }
        public ResponseStatusModel AddNewUser(UserModel um)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_AddNewUser]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    Created_By=um.CreatedBy,
                    UserName = um.UserName,
                    Email=um.Email,
                    Password=um.Password,
                    PhoneNo=um.Phone_No,
                    Role_Id=um.Role_Id
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public ResponseStatusModel UpdateUser(UserModel um)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_UpdateUser]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    UserID = um.UserID,
                    UserName = um.UserName,
                    Email=um.Email,
                    Phone_No=um.Phone_No,
                    Password=um.Password,
                    Role_Id=um.Role_Id
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public ResponseStatusModel RemoveUser(int UserID)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_RemoveUser]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    UserID = UserID
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public UserModel ViewUser(int UserID)
        {
            UserModel um = new UserModel();
            string sql = "[SP_ViewUser]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    UserID = UserID
                },
                commandType: CommandType.StoredProcedure);
                um = multi.Read<UserModel>().SingleOrDefault();
            }
            return um;
        }
    }
}
