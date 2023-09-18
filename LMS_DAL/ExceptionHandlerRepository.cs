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
    public class ExceptionHandlerRepository
    {
        public void SaveException(ExceptionModel em)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                string sql = "[SP_SaveExceptions]";
                response = conn.Query<ResponseStatusModel>(sql, new
                {
                    UserId = em.Userid,
                    ExceptionType = em.Etype,
                    ExceptionSource = em.Esource,
                    ExceptionMgs = em.Emsg,
                    ExceptionUrl = em.Eurl,
                    ActionName = em.Actionname,
                    IpAddress = em.Ipaddress,
                    ControllerName = em.Controllername
                }, null, true, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
