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
    public class LogOutRepository
    {
        public ResponseStatusModel LogOut(string UserId)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple("[dbo].[SP_AddLogOutDetails]", new { User_Id = UserId }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().FirstOrDefault();
            }
            return response;
        }
    }
}
