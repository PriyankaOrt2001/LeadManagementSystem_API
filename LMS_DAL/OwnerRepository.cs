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
    public class OwnerRepository
    {
        public LeadOwnerModel GetOwnerList()
        {
            LeadOwnerModel lsm = new LeadOwnerModel();
            string sql = "[SP_GetOwnerList]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {

                }, commandType: CommandType.StoredProcedure);
                lsm.LeadOwnerDetails = multi.Read<LeadOwnerDetails>().ToList();
            }
            return lsm;
        }
        public ResponseStatusModel AddNewLeadOwner(LeadOwnerDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_AddNewLeadOwner]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    CreatedBy = ld.CreatedBy,
                    OwnerName = ld.Owner_Name
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public ResponseStatusModel RemoveLeadOwner(int OwnerId)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_RemoveLeadOwner]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    OwnerId = OwnerId
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public LeadOwnerDetails ViewLeadOwner(int OwnerId)
        {
            LeadOwnerDetails lm = new LeadOwnerDetails();
            string sql = "[SP_ViewLeadOwner]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    OwnerId = OwnerId
                },
                commandType: CommandType.StoredProcedure);
                lm = multi.Read<LeadOwnerDetails>().SingleOrDefault();
            }
            return lm;
        }
        public ResponseStatusModel UpdateLeadOwner(LeadOwnerDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_UpdateLeadOwner]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    CreatedBy = ld.CreatedBy,
                    OwnerId = ld.Owner_Id,
                    OwnerName = ld.Owner_Name
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public GetLeadUpdatedByOwnerDetailsList GetLeadUpdatedByOwnerDetails(string LeadId)
        {
            GetLeadUpdatedByOwnerDetailsList od = new GetLeadUpdatedByOwnerDetailsList();
            string sql = "[SP_GetLeadUpdatedByOwnerDetails]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    LeadId = LeadId
                }, commandType: CommandType.StoredProcedure);
                od.GetLeadUpdatedByOwnerDetails = multi.Read<GetLeadUpdatedByOwnerDetails>().ToList();
            }
            return od;
        }
        public LeadSourceModel GetLeadSourceList()
        {
            LeadSourceModel lsm = new LeadSourceModel();
            string sql = "[SP_GetLeadSourceList]";
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
