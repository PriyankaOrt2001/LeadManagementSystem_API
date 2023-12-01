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
    public class LeadSourceRepository
    {
        public ResponseStatusModel AddNewLeadSource(LeadSourceDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_AddNewLeadSource]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    CreatedBy = ld.CreatedBy,
                    SourceName = ld.Source_Name
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public ResponseStatusModel RemoveLeadSource(int SourceId)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_RemoveLeadSource]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    SourceId = SourceId
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public LeadSourceDetails ViewLeadSource(int SourceId)
        {
            LeadSourceDetails lm = new LeadSourceDetails();
            string sql = "[SP_ViewLeadSource]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    SourceId = SourceId
                },
                commandType: CommandType.StoredProcedure);
                lm = multi.Read<LeadSourceDetails>().SingleOrDefault();
            }
            return lm;
        }
        public ResponseStatusModel UpdateLeadSource(LeadSourceDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_UpdateLeadSource]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    CreatedBy = ld.CreatedBy,
                    SourceId = ld.Source_Id,
                    SourceName = ld.Source_Name
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public LeadSourceModel GetSourceList()
        {
            LeadSourceModel lsm = new LeadSourceModel();
            string sql = "[SP_GetSourceList]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {

                }, commandType: CommandType.StoredProcedure);
                lsm.LeadSourceDetails = multi.Read<LeadSourceDetails>().ToList();
            }
            return lsm;
        }
    }
}
