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
    public class NotificationRepository
    {
        public NotificationDetailsList NotificationDetails(string UserId)
        {
            NotificationDetailsList lm = new NotificationDetailsList();
            string sql = "[SP_NotificationDetails]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    UserId = UserId
                },
                commandType: CommandType.StoredProcedure);
                lm.NotificationDetails = multi.Read<NotificationDetails>().ToList();
            }
            return lm;
        }
        public NotificationDetailsList RecentNotificationDetails(string UserId)
        {
            NotificationDetailsList lm = new NotificationDetailsList();
            string sql = "[SP_RecentNotificationDetails]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    UserId = UserId
                },
                commandType: CommandType.StoredProcedure);
                lm.NotificationDetails = multi.Read<NotificationDetails>().ToList();
            }
            return lm;
        }
        public ResponseStatusModel UpdateNotificationSeenStatus(string UserId)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_UpdateNotificationSeenStatus]";

            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    UserId = UserId
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public GetCountOfUnSeenNotification GetCountOfUnSeenNotification(string UserId)
        {
            GetCountOfUnSeenNotification rc = new GetCountOfUnSeenNotification();
            string sql = "[SP_GetCountOfUnSeenNotification]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    UserId = UserId
                },
                commandType: CommandType.StoredProcedure);
                rc = multi.Read<GetCountOfUnSeenNotification>().SingleOrDefault();
            }
            return rc;
        }
    }
}
