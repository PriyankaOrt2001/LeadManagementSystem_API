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
    public class LoginRepository
    {
        public UserResponseModelViewModel Login(LoginModel login)
        {
            UserResponseModelViewModel response = new UserResponseModelViewModel();
            string sql = "[dbo].[SP_Login_API]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    UserName = login.UserName,
                    Password = login.Password,
                    DeviceId = login.DeviceId
                }, commandType: CommandType.StoredProcedure);
                response.usermodel = multi.Read<UserModel>().SingleOrDefault();
                response.response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public UserResponseModelViewModel APILogIn(LoginModel login)
        {
            UserResponseModelViewModel response = new UserResponseModelViewModel();
            string sql = "[dbo].[SP_LogIn]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    UserName = login.UserName,
                    Password = login.Password,
                    DeviceId = login.DeviceId
                }, commandType: CommandType.StoredProcedure);
                response.usermodel = multi.Read<UserModel>().SingleOrDefault();
                response.response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
    }
}
