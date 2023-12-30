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
                    UserFullName = um.UserFullName,
                    UserName = um.UserName,
                    Password=um.Password,
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
       
    }
}
