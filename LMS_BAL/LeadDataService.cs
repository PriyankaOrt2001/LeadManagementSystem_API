using LMS_DAL;
using LMS_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_BAL
{
    public class LeadDataService
    {
        readonly LeadDataRepository repository = new LeadDataRepository();
        public CompanyModel GetCompanyList()
        {
            return repository.GetCompanyList();
        }
        public ClientModel GetClientList()
        {
            return repository.GetClientList();
        }
        public GetUserListToSendNotificationList GetUserListToSendNotification(string Lead_Id)
        {
            return repository.GetUserListToSendNotification(Lead_Id);
        }
        public GetUserList GetUserList()
        {
            return repository.GetUserList();
        }
        public PlanDetailsModel GetPlanDetailsList()
        {
            return repository.GetPlanDetailsList();
        }
        public AssignToModel GetAssignToList()
        {
            return repository.GetAssignToList();
        }
        public LeadSourceModel GetLeadSourceList()
        {
            return repository.GetLeadSourceList();
        }
        public LeadSourceModel GetSourceList()
        {
            return repository.GetSourceList();
        }
        public LeadOwnerModel GetOwnerList()
        {
            return repository.GetOwnerList();
        }
        public LeadCategoryModel GetLeadCategoryList()
        {
            return repository.GetLeadCategoryList();
        }
        public TypeOfLeadModel GetTypeOfLeadList(int Category_Id)
        {
            return repository.GetTypeOfLeadList(Category_Id);
        }
        public PlanDetails GetPlanPrice(int Plan_Id)
        {
            return repository.GetPlanPrice(Plan_Id);
        }
        public GetRemarkCount GetRemarkCount(string Lead_Id)
        {
            return repository.GetRemarkCount(Lead_Id);
        }
        public GetCountOfUnSeenNotification GetCountOfUnSeenNotification(string UserId)
        {
            return repository.GetCountOfUnSeenNotification(UserId);
        }
        public TypeOfLeadModel GetLeadTypesList()
        {
            return repository.GetLeadTypesList();
        }
        public LeadModel GetLeadDetailsList(string UserId)
        {
            return repository.GetLeadDetailsList(UserId);
        }
        public LeadModel GetLeadDataList(PagingParam pagingParam)
        {
            return repository.GetLeadDataList(pagingParam);
        }
        public LeadModel FilterLeadTableDetails(FilterBy filterBy)
        {
            return repository.FilterLeadTableDetails(filterBy);
        }
        public CardImagesData GetImageDetailsList(string Lead_Id)
        {
            return repository.GetImageDetailsList(Lead_Id);
        }
        public LeadModel GetRecentLeadDetailsList()
        {
            return repository.GetRecentLeadDetailsList();
        }
        public ResponseStatusModel AddLead(LeadDetails ld,DataTable myDataTable)
        {
            return repository.AddLead(ld, myDataTable);
        }
        public ResponseStatusModel AddNewLeadSource(LeadSourceDetails ld)
        {
            return repository.AddNewLeadSource(ld);
        }
        public ResponseStatusModel AddNewLeadOwner(LeadOwnerDetails ld)
        {
            return repository.AddNewLeadOwner(ld);
        }
        public ResponseStatusModel AddNewEmployee(AssignToDetails ld)
        {
            return repository.AddNewEmployee(ld);
        }
        public ResponseStatusModel AddCategory(LeadCategoryDetails lcd)
        {
            return repository.AddCategory(lcd);
        }
        public ResponseStatusModel AddNewPlan(PlanDetails pd)
        {
            return repository.AddNewPlan(pd);
        }
        public ResponseStatusModel AddNewComapny(CompanyDetails cd)
        {
            return repository.AddNewComapny(cd);
        }
        public ResponseStatusModel AddTypeOfLead(TypeOfLeadDetails tol)
        {
            return repository.AddTypeOfLead(tol);
        }
        public ResponseStatusModel AddRemark(RemarkModel remarkModel, DataTable dataTable)
        {
            return repository.AddRemark(remarkModel, dataTable);
        }
        public LeadDetails ViewLead(string Lead_Id)
        {
            return repository.ViewLead(Lead_Id);
        }
        public LeadDetails ViewLeadDetails(string Lead_Id)
        {
            return repository.ViewLeadDetails(Lead_Id);
        }
        public CardImagesData GetImageList(string Lead_Id)
        {
            return repository.GetImageList(Lead_Id);
        }
        public LeadCategoryDetails ViewCategoryDetails(int Category_Id)
        {
            return repository.ViewCategoryDetails(Category_Id);
        }
        public TypeOfLeadDetails ViewTypeOfLeadDetails(int TypeOfLead_ID)
        {
            return repository.ViewTypeOfLeadDetails(TypeOfLead_ID);
        }
        public CompanyDetails ViewCompanyDetails(int Company_Id)
        {
            return repository.ViewCompanyDetails(Company_Id);
        }
        public AssignToDetails ViewAssignToDetails(int Employee_Id)
        {
            return repository.ViewAssignToDetails(Employee_Id);
        }
        public LeadSourceDetails ViewLeadSource(int SourceId)
        {
            return repository.ViewLeadSource(SourceId);
        }
        public LeadOwnerDetails ViewLeadOwner(int OwnerId)
        {
            return repository.ViewLeadOwner(OwnerId);
        }
        public PlanDetails ViewPlanDetails(int PlanId)
        {
            return repository.ViewPlanDetails(PlanId);
        }
        public ResponseStatusModel UpdateDraftLead(LeadDetails ld)
        {
            return repository.UpdateDraftLead(ld);
        }

        public ResponseStatusModel UpdateFirstDraftLead(LeadDetails ld)
        {
            return repository.UpdateFirstDraftLead(ld);
        }
        public ResponseStatusModel UpdateFinalLead(LeadDetails ld)
        {
            return repository.UpdateFinalLead(ld);
        }
        public ResponseStatusModel UpdateFinalDraftLead(LeadDetails ld)
        {
            return repository.UpdateFinalDraftLead(ld);
        }
        public ResponseStatusModel UpdateLead(LeadDetails ld)
        {
            return repository.UpdateLead(ld);
        }
        public RemarkModelList GetRemarksList(string Lead_Id)
        {
            return repository.GetRemarksList(Lead_Id);
        }
        public RemarkModelList GetRecentRemarksList()
        {
            return repository.GetRecentRemarksList();
        }
        public ResponseStatusModel ChangeLeadStatus(LeadDetails ld)
        {
            return repository.ChangeLeadStatus(ld);
        }
        public ResponseStatusModel RemoveComapny(int CompanyId)
        {
            return repository.RemoveCompany(CompanyId);
        }
        public ResponseStatusModel RemoveLead(string LeadId,string UserId)
        {
            return repository.RemoveLead(LeadId, UserId);
        }
        public ResponseStatusModel RemoveEmployee(int Employee_Id)
        {
            return repository.RemoveEmployee(Employee_Id);
        }
        public ResponseStatusModel RemoveCategory(int CategoryId)
        {
            return repository.RemoveCategory(CategoryId);
        }
        public ResponseStatusModel RemoveTypeOfLead(int TypeOfLeadId)
        {
            return repository.RemoveTypeOfLead(TypeOfLeadId);
        }
        public ResponseStatusModel RemoveLeadSource(int SourceId)
        {
            return repository.RemoveLeadSource(SourceId);
        }
        public ResponseStatusModel RemoveLeadOwner(int OwnerId)
        {
            return repository.RemoveLeadOwner(OwnerId);
        }
        public NotificationDetailsList NotificationDetails(string UserId)
        {
            return repository.NotificationDetails(UserId);
        }
        public NotificationDetailsList RecentNotificationDetails(string UserId)
        {
            return repository.RecentNotificationDetails(UserId);
        }
        public ResponseStatusModel RemovePlan(int PlanId)
        {
            return repository.RemovePlan(PlanId);
        }
        public ResponseStatusModel UpdateCompany(CompanyDetails cmm)
        {
            return repository.UpdateCompany(cmm);
        }
        public ResponseStatusModel UpdateCategory(LeadCategoryDetails cd)
        {
            return repository.UpdateCategory(cd);
        }
        public ResponseStatusModel UpdateTypeOfLead(TypeOfLeadDetails ld)
        {
            return repository.UpdateTypeOfLead(ld);
        }
        public ResponseStatusModel UpdateEmployee(AssignToDetails ad)
        {
            return repository.UpdateEmployee(ad);
        }
        public ResponseStatusModel UpdateLeadSource(LeadSourceDetails sd)
        {
            return repository.UpdateLeadSource(sd);
        }
        public ResponseStatusModel UpdateLeadOwner(LeadOwnerDetails sd)
        {
            return repository.UpdateLeadOwner(sd);
        }
        public ResponseStatusModel UpdatePlan(PlanDetails pd)
        {
            return repository.UpdatePlan(pd);
        }
        public ResponseStatusModel AddToFav(LeadDetails ld)
        {
            return repository.AddToFav(ld);
        }
        public GetLeadUpdatedByOwnerDetailsList GetLeadUpdatedByOwnerDetails(string LeadId)
        {
            return repository.GetLeadUpdatedByOwnerDetails(LeadId);
        }
        public GetUserDetails GetUserDetails(string UserId)
        {
            return repository.GetUserDetails(UserId);
        }
        public ResponseStatusModel UpdateRemark(RemarkModel rm)
        {
            return repository.UpdateRemark(rm);
        }
        public ResponseStatusModel UpdateNotificationSeenStatus(string UserId)
        {
            return repository.UpdateNotificationSeenStatus(UserId);
        }
    }
}
