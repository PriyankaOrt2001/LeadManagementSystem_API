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
    public class RemarkRepository
    {
        public GetRemarkCount GetRemarkCount(string Lead_Id)
        {
            GetRemarkCount rc = new GetRemarkCount();
            string sql = "[SP_GetRemarkCount]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    Lead_Id = Lead_Id
                },
                commandType: CommandType.StoredProcedure);
                rc = multi.Read<GetRemarkCount>().SingleOrDefault();
            }
            return rc;
        }
        public ResponseStatusModel UpdateRemark(RemarkModel rm)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_UpdateRemark]";

            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    LeadId = rm.Lead_Id,
                    CreatedBy = rm.CreatedBy,
                    Remark_Id = rm.Remark_Id,
                    Remark = rm.Remark
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public ResponseStatusModel AddRemark(RemarkModel remarkModel, DataTable dataTable)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_AddRemark]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    CreatedBy = remarkModel.CreatedBy,
                    Remark = remarkModel.Remark,
                    Lead_Id = remarkModel.Lead_Id,
                    Status = remarkModel.Status,
                    data = dataTable
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public GetUserList GetUserList()
        {
            GetUserList cm = new GetUserList();
            string sql = "[SP_GetUserList]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {

                }, commandType: CommandType.StoredProcedure);
                cm.GetUserDetails = multi.Read<GetUserDetails>().ToList();
            }
            return cm;
        }
        public GetUserDetails GetUserDetails(string UserId)
        {
            GetUserDetails ud = new GetUserDetails();
            string sql = "[SP_GetUserDetails]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    UserId = UserId
                },
                commandType: CommandType.StoredProcedure);
                ud = multi.Read<GetUserDetails>().SingleOrDefault();
            }
            return ud;
        }
        public LeadDetails ViewLead(string Lead_Id)
        {
            LeadDetails lm = new LeadDetails();
            string sql = "[SP_ViewLead]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    LeadId = Lead_Id
                },
                commandType: CommandType.StoredProcedure);
                lm = multi.Read<LeadDetails>().SingleOrDefault();
            }
            return lm;
        }
        public GetUserListToSendNotificationList GetUserListToSendNotification(string Lead_Id)
        {
            GetUserListToSendNotificationList cm = new GetUserListToSendNotificationList();
            string sql = "[SP_GetUserListToSendNotification]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    Lead_Id = Lead_Id
                }, commandType: CommandType.StoredProcedure);
                cm.GetUserListToSendNotification = multi.Read<GetUserListToSendNotification>().ToList();
            }
            return cm;
        }
        public RemarkModelList GetRemarksList(string Lead_Id)
        {
            RemarkModelList rml = new RemarkModelList();
            string sql = "[SP_GetRemarksList]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    Lead_Id = Lead_Id
                }, commandType: CommandType.StoredProcedure);
                rml.RemarkModels = multi.Read<RemarkModel>().ToList();
            }
            return rml;
        }
        public RemarkModelList GetRecentRemarksList()
        {
            RemarkModelList rml = new RemarkModelList();
            string sql = "[SP_GetRecentRemarksList]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {

                }, commandType: CommandType.StoredProcedure);
                rml.RemarkModels = multi.Read<RemarkModel>().ToList();
            }
            return rml;
        }
    }
}
