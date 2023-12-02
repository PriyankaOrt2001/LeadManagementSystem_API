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
    public class CompanyRepository
    {
        public ResponseStatusModel AddNewComapny(CompanyDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_AddNewCompany]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    CreatedBy = ld.CreatedBy,
                    Company_Name = ld.Company_Name,
                    Short_Company_Name=ld.Short_Company_Name
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public ResponseStatusModel RemoveCompany(int Company_Id)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_RemoveCompany]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    Company_Id = Company_Id
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public CompanyDetails ViewCompanyDetails(int Company_Id)
        {
            CompanyDetails lm = new CompanyDetails();
            string sql = "[SP_ViewCompanyDetails]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    Company_Id = Company_Id
                },
                commandType: CommandType.StoredProcedure);
                lm = multi.Read<CompanyDetails>().SingleOrDefault();
            }
            return lm;
        }
        public ResponseStatusModel UpdateCompany(CompanyDetails cmm)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_UpdateCompany]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    CreatedBy = cmm.CreatedBy,
                    Company_ID = cmm.Company_Id,
                    Company_Name = cmm.Company_Name,
                    Short_Company_Name=cmm.Short_Company_Name
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public CompanyModel GetCompanyList()
        {
            CompanyModel cm = new CompanyModel();
            string sql = "[SP_CompanyDropdown]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {

                }, commandType: CommandType.StoredProcedure);
                cm.CompanyList = multi.Read<CompanyDetails>().ToList();
            }
            return cm;
        }
    }
}
