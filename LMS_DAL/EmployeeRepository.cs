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
    public class EmployeeRepository
    {
        public AssignToModel GetAssignToList()
        {
            AssignToModel am = new AssignToModel();
            string sql = "[SP_AssignToDropdown]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {

                }, commandType: CommandType.StoredProcedure);
                am.AssignToList = multi.Read<AssignToDetails>().ToList();
            }
            return am;
        }
        public ResponseStatusModel AddNewAssignee(AssignToDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_AddNewAssignee]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    CreatedBy = ld.CreatedBy,
                    Assignee_Name = ld.Assignee_Name
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public ResponseStatusModel RemoveAssignee(int Assignee_Id)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_RemoveAssignee]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    Assignee_Id = Assignee_Id
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public AssignToDetails ViewAssignToDetails(int Assignee_Id)
        {
            AssignToDetails lm = new AssignToDetails();
            string sql = "[SP_ViewAssignToDetails]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    Assignee_Id = Assignee_Id
                },
                commandType: CommandType.StoredProcedure);
                lm = multi.Read<AssignToDetails>().SingleOrDefault();
            }
            return lm;
        }
        public ResponseStatusModel UpdateAssignee(AssignToDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_UpdateAssignee]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    CreatedBy = ld.CreatedBy,
                    Assignee_Id = ld.Assignee_Id,
                    Assignee_Name = ld.Assignee_Name
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
    }
}
