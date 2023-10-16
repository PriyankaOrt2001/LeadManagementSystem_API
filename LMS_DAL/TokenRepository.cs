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
    public class TokenRepository
    {
        public ResponseStatusModel CheckToken(string Token,string userid)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            if (!string.IsNullOrEmpty(Token))
            {
                using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
                {
                    var multi = conn.QueryMultiple("[dbo].[CheckToken]", new { Token, userid }, commandType: CommandType.StoredProcedure);
                    response = multi.Read<ResponseStatusModel>().SingleOrDefault();
                }
            }
            else
            {
                response.msg = "Unauthorized";
                response.n = 0;
                response.RStatus = "Unauthorized";
            }
            return response;
        }
    }
}
