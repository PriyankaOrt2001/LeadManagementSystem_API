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
    public class TypeOfLeadRepository
    {
        public TypeOfLeadModel GetTypeOfLeadList(int Category_Id)
        {
            TypeOfLeadModel tolm = new TypeOfLeadModel();
            string sql = "[SP_TypeOfLeadDropdown]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    Category_Id = Category_Id
                },
                commandType: CommandType.StoredProcedure);
                tolm.TypeOfLeadList = multi.Read<TypeOfLeadDetails>().ToList();
            }
            return tolm;
        }
        public ResponseStatusModel AddTypeOfLead(TypeOfLeadDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_AddNewTypeOfLead]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    CreatedBy = ld.CreatedBy,
                    Category_Id = ld.Category_Id,
                    TypeOfLead = ld.TypeOfLead
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public ResponseStatusModel RemoveTypeOfLead(int TypeOfLeadId)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_RemoveTypeOfLead]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    TypeOfLead_ID = TypeOfLeadId
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public TypeOfLeadDetails ViewTypeOfLeadDetails(int TypeOfLead_ID)
        {
            TypeOfLeadDetails lm = new TypeOfLeadDetails();
            string sql = "[SP_ViewTypeOfLeadDetails]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    TypeOfLead_ID = TypeOfLead_ID
                },
                commandType: CommandType.StoredProcedure);
                lm = multi.Read<TypeOfLeadDetails>().SingleOrDefault();
            }
            return lm;
        }
        public ResponseStatusModel UpdateTypeOfLead(TypeOfLeadDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_UpdateTypeOfLead]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    Category_Id = ld.Category_Id,
                    CreatedBy = ld.CreatedBy,
                    TypeOfLead_ID = ld.TypeOfLead_ID,
                    TypeOfLead = ld.TypeOfLead
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public TypeOfLeadModel GetLeadTypesList()
        {
            TypeOfLeadModel lcm = new TypeOfLeadModel();
            string sql = "[SP_GetTypeOfLeadList]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {

                }, commandType: CommandType.StoredProcedure);
                lcm.TypeOfLeadList = multi.Read<TypeOfLeadDetails>().ToList();
            }
            return lcm;
        }
    }
}
