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
        public SubCategoryModel GetSubCategoryList(int Category_Id)
        {
            SubCategoryModel tolm = new SubCategoryModel();
            string sql = "[SP_SubCategoryDropdown]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    Category_Id = Category_Id
                },
                commandType: CommandType.StoredProcedure);
                tolm.SubCategoryList = multi.Read<SubCategoryDetails>().ToList();
            }
            return tolm;
        }
        public ResponseStatusModel AddSubCategory(SubCategoryDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_AddNewSubCategory]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    CreatedBy = ld.CreatedBy,
                    Category_Id = ld.Category_Id,
                    SubCategory = ld.SubCategory
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public ResponseStatusModel RemoveSubCategory(int SubCategoryId)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_RemoveSubCategory]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    SubCategory_ID = SubCategoryId
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public SubCategoryDetails ViewSubCategoryDetails(int SubCategory_ID)
        {
            SubCategoryDetails lm = new SubCategoryDetails();
            string sql = "[SP_ViewSubCategoryDetails]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    SubCategory_ID = SubCategory_ID
                },
                commandType: CommandType.StoredProcedure);
                lm = multi.Read<SubCategoryDetails>().SingleOrDefault();
            }
            return lm;
        }
        public ResponseStatusModel UpdateSubCategory(SubCategoryDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_UpdateSubCategory]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    Category_Id = ld.Category_Id,
                    CreatedBy = ld.CreatedBy,
                    SubCategory_ID = ld.SubCategory_ID,
                    SubCategory = ld.SubCategory
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public SubCategoryModel GetSubCategoryList()
        {
            SubCategoryModel lcm = new SubCategoryModel();
            string sql = "[SP_GetSubCategoryList]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {

                }, commandType: CommandType.StoredProcedure);
                lcm.SubCategoryList = multi.Read<SubCategoryDetails>().ToList();
            }
            return lcm;
        }
    }
}
