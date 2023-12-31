﻿using Dapper;
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
        public ClientModel GetClientList()
        {
            ClientModel cm = new ClientModel();
            string sql = "[SP_GetClientNameList]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {

                }, commandType: CommandType.StoredProcedure);
                cm.ClientList = multi.Read<ClientDetails>().ToList();
            }
            return cm;
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
        public LeadModel GetLeadDetailsList(string UserId)
        {
            LeadModel lm = new LeadModel();
            string sql = "[SP_GetLeadDetailsList]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    UserId= UserId
                }, commandType: CommandType.StoredProcedure);
                lm.LeadList = multi.Read<LeadDetails>().ToList();
            }
            return lm;
        }
        public LeadModel GetLeadDataList(string UserId,string companyIdString,string categoryIdString,string priorityString,string assigneeIdString,string searchValueString)
        {
            LeadModel lm = new LeadModel();
            string sql = "[SP_GetLeadDataList]";
            using(IDbConnection conn=new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    UserId = UserId,
                    CompanyId = companyIdString,
                    CategoryId = categoryIdString,
                    Priority = priorityString,
                    AssigneeId = assigneeIdString,
                    SearchValue = searchValueString
                }, commandType: CommandType.StoredProcedure);
                lm.LeadList = multi.Read<LeadDetails>().ToList();
            }
            return lm;
        }
        public LeadModel FilterLeadTableDetails(FilterBy filterBy)
        {
            LeadModel lm = new LeadModel();
            string sql = "[SP_FilterLeadTableDetails]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    UserId = filterBy.UserId,
                    CompanyId = filterBy.CompanyId,
                    CategoryId= filterBy.CategoryId,
                    Priority= filterBy.Priority,
                    AssignedId= filterBy.AssignedId
                }, commandType: CommandType.StoredProcedure) ;
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
        public ResponseStatusModel AddLead(LeadDetails ld, DataTable dataTable)
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
                    Category = ld.Category, //pass Priority value from front
                    TypeOfLead = ld.TypeOfLead, //pass Sub Category value from front
                    ProductName = ld.ProductName,
                    Source = ld.Source, // pass Owner Name value
                    Reference = ld.Reference,
                    LeadSource = ld.LeadSource,
                    SpokesName = ld.SpokesName,
                    SpokesMobileNumber = ld.SpokesMobileNumber,
                    SpokesEmailAddress = ld.SpokesEmailAddress,
                    SpokesAddress = ld.SpokesAddress,
                    AlternateSpokesName = ld.AlternateSpokesName,
                    AlternateSpokesMobile = ld.AlternateSpokesMobile,
                    AlternateEmailAddress = ld.AlternateEmailAddress,
                    AlternateSpokesAddress = ld.AlternateSpokesAddress,
                    PlanName = ld.PlanName,
                    PlanPrice = ld.PlanPrice,
                    StatusType = ld.StatusType,
                    AssignTo = ld.AssignTo,
                    ScheduleDate = ld.ScheduleDate,
                    ScheduleTime = ld.ScheduleTime,
                    FrontImgOfCardPath = ld.FrontImgOfCardPath,
                    ProjectType = ld.ProjectType, //pass Category value from front
                    FrontImgFileName = ld.FrontImgFileName,
                    FrontImgBase64 = ld.FrontImgBase64,
                    FrontImgFileType = ld.FrontImgFileType,
                    BackImgOfCardPath = ld.BackImgOfCardPath,
                    BackImgFileName = ld.BackImgFileName,
                    BackImgBase64 = ld.BackImgBase64,
                    BackImgFileType = ld.BackImgFileType,
                    IsFinal = ld.IsFinal,
                    data = dataTable
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
                    AlternateSpokesAddress = ld.AlternateSpokesAddress,
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
        public ResponseStatusModel ChangeLeadPriority(ChangeLeadPriority clp)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_ChangeLeadPriority]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    Lead_Id = clp.LeadId,
                    UpdatedBy = clp.UpdatedBy,
                    Priority = clp.Priority
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
        public ResponseStatusModel AddToFav(LeadDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_AddToFav]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    Lead_Id = ld.LeadId,
                    UpdatedBy = ld.UpdatedBy,
                    IsFav = ld.IsFav
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }        
        public ResponseStatusModel RemoveLead(string LeadId,string UserId)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[SP_RemoveLead]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    LeadId = LeadId,
                    UserId = UserId
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
