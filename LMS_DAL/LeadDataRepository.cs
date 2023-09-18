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
    public class LeadDataRepository
    {
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
        public PlanDetailsModel GetPlanDetailsList()
        {
            PlanDetailsModel pdm = new PlanDetailsModel();
            string sql = "[SP_PlanDetailsDropdown]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {

                }, commandType: CommandType.StoredProcedure);
                pdm.PlanList = multi.Read<PlanDetails>().ToList();
            }
            return pdm;
        }
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
        public LeadModel GetLeadDetailsList()
        {
            LeadModel lm = new LeadModel();
            string sql = "[SP_GetLeadDetailsList]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {

                }, commandType: CommandType.StoredProcedure);
                lm.LeadList = multi.Read<LeadDetails>().ToList();
            }
            return lm;
        }
        public CardImagesData GetImageDetailsList(string Lead_Id)
        {
            CardImagesData cid = new CardImagesData();
            string sql = "[SP_ViewLeadDetails]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    LeadId = Lead_Id
                }, commandType: CommandType.StoredProcedure);
                cid = multi.Read<CardImagesData>().FirstOrDefault();
            }
            return cid;
        }

        public LeadModel GetRecentLeadDetailsList()
        {
            LeadModel lm = new LeadModel();
            string sql = "[SP_RecentLeads]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {

                }, commandType: CommandType.StoredProcedure);
                lm.LeadList = multi.Read<LeadDetails>().ToList();
            }
            return lm;
        }
        public ResponseStatusModel AddLead(LeadDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_AddNewLeadDetails]";

            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    CreatedBy = ld.CreatedBy,
                    CompanyName = ld.CompanyName,
                    ClientName = ld.ClientName,
                    Category = ld.Category,
                    TypeOfLead = ld.TypeOfLead,
                    ProductName = ld.ProductName,
                    Source = ld.Source,
                    Reference = ld.Reference,
                    LeadSource = ld.LeadSource,
                    SpokesName = ld.SpokesName,
                    SpokesMobileNumber = ld.SpokesMobileNumber,
                    SpokesEmailAddress = ld.SpokesEmailAddress,
                    SpokesAddress = ld.SpokesAddress,
                    AlternateSpokesName = ld.AlternateSpokesName,
                    AlternateSpokesMobile = ld.AlternateSpokesMobile,
                    AlternateEmailAddress = ld.AlternateEmailAddress,
                    PlanName = ld.PlanName,
                    PlanPrice = ld.PlanPrice,
                    StatusType = ld.StatusType,
                    AssignTo = ld.AssignTo,
                    ScheduleDate = ld.ScheduleDate,
                    ScheduleTime = ld.ScheduleTime,
                    FrontImgOfCardPath = ld.FrontImgOfCardPath,
                    ProjectType = ld.ProjectType,
                    FrontImgFileName = ld.FrontImgFileName,
                    FrontImgBase64 = ld.FrontImgBase64,
                    FrontImgFileType = ld.FrontImgFileType,
                    BackImgOfCardPath = ld.BackImgOfCardPath,
                    BackImgFileName = ld.BackImgFileName,
                    BackImgBase64 = ld.BackImgBase64,
                    BackImgFileType = ld.BackImgFileType,
                    IsFinal = ld.IsFinal

                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
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
        public ResponseStatusModel AddNewEmployee(AssignToDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_AddNewEmployee]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    CreatedBy = ld.CreatedBy,
                    Employee_Name = ld.Employee_Name
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
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
        public ResponseStatusModel AddNewPlan(PlanDetails pd)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_AddNewPlan]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    CreatedBy = pd.CreatedBy,
                    Plan_Name = pd.Plan_Name,
                    Plan_Price = pd.Plan_Price
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public ResponseStatusModel AddNewComapny(CompanyDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_AddNewCompany]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    CreatedBy = ld.CreatedBy,
                    Company_Name = ld.Company_Name
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
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
        public LeadDetails ViewLeadDetails(string Lead_Id)
        {
            LeadDetails lm = new LeadDetails();
            string sql = "[SP_ViewLeadDetails]";
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
        public CardImagesData GetImageList(string Lead_Id)
        {
            CardImagesData lm = new CardImagesData();
            string sql = "[SP_GetImageList]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    LeadId = Lead_Id
                },
                commandType: CommandType.StoredProcedure);
                lm = multi.Read<CardImagesData>().SingleOrDefault();
            }
            return lm;
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
        public AssignToDetails ViewAssignToDetails(int Employee_Id)
        {
            AssignToDetails lm = new AssignToDetails();
            string sql = "[SP_ViewAssignToDetails]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    Employee_Id = Employee_Id
                },
                commandType: CommandType.StoredProcedure);
                lm = multi.Read<AssignToDetails>().SingleOrDefault();
            }
            return lm;
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
        public PlanDetails GetPlanPrice(int PlanId)
        {
            PlanDetails lm = new PlanDetails();
            string sql = "[SP_GetPlanPrice]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    Plan_Id = PlanId
                },
                commandType: CommandType.StoredProcedure);
                lm = multi.Read<PlanDetails>().SingleOrDefault();
            }
            return lm;
        }
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
        public ResponseStatusModel UpdateFinalLead(LeadDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_UpdateFinalLead]";

            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    LeadId = ld.LeadId,
                    CreatedBy = ld.CreatedBy,

                    PlanName = ld.PlanName,
                    PlanPrice = ld.PlanPrice,
                    StatusType = ld.StatusType,
                    AssignTo = ld.AssignTo,
                    ScheduleDate = ld.ScheduleDate,
                    ScheduleTime = ld.ScheduleTime,
                    ProjectType = ld.ProjectType,
                    IsFinal = ld.IsFinal

                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public ResponseStatusModel UpdateFinalDraftLead(LeadDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_UpdateFinalDraftLead]";

            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    LeadId = ld.LeadId,
                    CreatedBy = ld.CreatedBy,

                    PlanName = ld.PlanName,
                    PlanPrice = ld.PlanPrice,
                    StatusType = ld.StatusType,
                    AssignTo = ld.AssignTo,
                    ScheduleDate = ld.ScheduleDate,
                    ScheduleTime = ld.ScheduleTime,
                    ProjectType = ld.ProjectType,
                    IsFinal = ld.IsFinal

                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public ResponseStatusModel UpdateFirstDraftLead(LeadDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_UpdateFirstDraftLead]";

            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    LeadId = ld.LeadId,
                    CreatedBy = ld.CreatedBy,
                    CompanyName = ld.CompanyName,
                    ClientName = ld.ClientName,
                    Category = ld.Category,
                    TypeOfLead = ld.TypeOfLead,
                    ProductName = ld.ProductName,
                    Source = ld.Source,
                    Reference = ld.Reference,
                    LeadSource = ld.LeadSource,
                    ProjectType = ld.ProjectType,
                    FrontImgOfCardPath = ld.FrontImgOfCardPath,

                    FrontImgFileName = ld.FrontImgFileName,
                    FrontImgBase64 = ld.FrontImgBase64,
                    FrontImgFileType = ld.FrontImgFileType,
                    BackImgOfCardPath = ld.BackImgOfCardPath,
                    BackImgFileName = ld.BackImgFileName,
                    BackImgBase64 = ld.BackImgBase64,
                    BackImgFileType = ld.BackImgFileType

                }, commandType: CommandType.StoredProcedure) ;
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public ResponseStatusModel UpdateLead(LeadDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_UpdateLead]";

            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    LeadId = ld.LeadId,
                    CreatedBy = ld.CreatedBy,
                    CompanyName = ld.CompanyName,
                    ClientName = ld.ClientName,
                    Category = ld.Category,
                    TypeOfLead = ld.TypeOfLead,
                    ProductName = ld.ProductName,
                    Source = ld.Source,
                    Reference = ld.Reference,
                    LeadSource = ld.LeadSource,
                    SpokesName = ld.SpokesName,
                    SpokesMobileNumber = ld.SpokesMobileNumber,
                    SpokesEmailAddress = ld.SpokesEmailAddress,
                    SpokesAddress = ld.SpokesAddress,
                    AlternateSpokesName = ld.AlternateSpokesName,
                    AlternateSpokesMobile = ld.AlternateSpokesMobile,
                    AlternateEmailAddress = ld.AlternateEmailAddress,
                    PlanName = ld.PlanName,
                    PlanPrice = ld.PlanPrice,
                    StatusType = ld.StatusType,
                    AssignTo = ld.AssignTo,
                    ScheduleDate = ld.ScheduleDate,
                    ScheduleTime = ld.ScheduleTime,
                    FrontImgOfCardPath = ld.FrontImgOfCardPath,
                    ProjectType = ld.ProjectType,
                    FrontImgFileName = ld.FrontImgFileName,
                    FrontImgBase64 = ld.FrontImgBase64,
                    FrontImgFileType = ld.FrontImgFileType,
                    BackImgOfCardPath = ld.BackImgOfCardPath,
                    BackImgFileName = ld.BackImgFileName,
                    BackImgBase64 = ld.BackImgBase64,
                    BackImgFileType = ld.BackImgFileType,
                    IsFinal = ld.IsFinal

                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public ResponseStatusModel UpdateDraftLead(LeadDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_UpdateDraftLead]";

            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    LeadId = ld.LeadId,

                    SpokesName = ld.SpokesName,
                    SpokesMobileNumber = ld.SpokesMobileNumber,
                    SpokesEmailAddress = ld.SpokesEmailAddress,
                    SpokesAddress = ld.SpokesAddress,
                    AlternateSpokesName = ld.AlternateSpokesName,
                    AlternateSpokesMobile = ld.AlternateSpokesMobile,
                    AlternateEmailAddress = ld.AlternateEmailAddress
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }

        public ResponseStatusModel AddRemark(RemarkModel remarkModel)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_AddRemark]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    CreatedBy = remarkModel.CreatedBy,
                    Remark = remarkModel.Remark,
                    Lead_Id = remarkModel.Lead_Id
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
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
        public ResponseStatusModel ChangeLeadStatus(LeadDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_ChangeLeadStatus]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    Lead_Id = ld.LeadId,
                    UpdatedBy = ld.UpdatedBy,
                    Status = ld.StatusType
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
        public ResponseStatusModel RemoveEmployee(int Employee_Id)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_RemoveEmployee]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    Employee_Id = Employee_Id
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
        public ResponseStatusModel RemovePlan(int Plan_Id)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_RemovePlan]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    Plan_Id = Plan_Id
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
                    Company_Name = cmm.Company_Name
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
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
        public ResponseStatusModel UpdateTypeOfLead(TypeOfLeadDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_UpdateTypeOfLead]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    CreatedBy = ld.CreatedBy,
                    TypeOfLead_ID = ld.TypeOfLead_ID,
                    TypeOfLead = ld.TypeOfLead
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public ResponseStatusModel UpdateEmployee(AssignToDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_UpdateEmployee]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    CreatedBy = ld.CreatedBy,
                    Employee_Id = ld.Employee_Id,
                    Employee_Name = ld.Employee_Name
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
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
        public ResponseStatusModel UpdatePlan(PlanDetails pd)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_UpdatePlan]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    CreatedBy = pd.CreatedBy,
                    Plan_Id = pd.Plan_Id,
                    Plan_Name = pd.Plan_Name,
                    Plan_Price = pd.Plan_Price
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public PlanDetails ViewPlanDetails(int Plan_Id)
        {
            PlanDetails lm = new PlanDetails();
            string sql = "[SP_ViewPlanDetails]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    Plan_Id = Plan_Id
                },
                commandType: CommandType.StoredProcedure);
                lm = multi.Read<PlanDetails>().SingleOrDefault();
            }
            return lm;
        }
    }
}
