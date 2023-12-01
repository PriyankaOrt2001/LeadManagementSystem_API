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
    public class CategoryRepository
    {
        public ResponseStatusModel UpdateCategory(LeadCategoryDetails cd)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_UpdateCategory]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    CreatedBy = cd.CreatedBy,
                    Category_Id = cd.Category_Id,
                    Category_Name = cd.Category_Name
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public LeadCategoryModel GetLeadCategoryList()
        {
            LeadCategoryModel lcm = new LeadCategoryModel();
            string sql = "[SP_CategoryDropdown]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {

                }, commandType: CommandType.StoredProcedure);
                lcm.LeadCategoryList = multi.Read<LeadCategoryDetails>().ToList();
            }
            return lcm;
        }
        public ResponseStatusModel AddCategory(LeadCategoryDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_AddNewCategory]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    CreatedBy = ld.CreatedBy,
                    Category_Name = ld.Category_Name
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public ResponseStatusModel RemoveCategory(int Category_Id)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_RemoveCategory]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    Category_Id = Category_Id
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public LeadCategoryDetails ViewCategoryDetails(int Category_Id)
        {
            LeadCategoryDetails lm = new LeadCategoryDetails();
            string sql = "[SP_ViewCategoryDetails]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    Category_Id = Category_Id
                },
                commandType: CommandType.StoredProcedure);
                lm = multi.Read<LeadCategoryDetails>().SingleOrDefault();
            }
            return lm;
        }
    }
}
