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
        public PlanDetails GetPlanPrice(int Plan_Id)
        {
            return repository.GetPlanPrice(Plan_Id);
        }
        public LeadModel GetLeadDetailsList(string UserId)
        {
            return repository.GetLeadDetailsList(UserId);
        }
        public LeadModel GetLeadDataList(string UserId,string companyIdString,string categoryIdString,string priorityString,string assigneeIdString)
        {
            return repository.GetLeadDataList(UserId,companyIdString, categoryIdString, priorityString, assigneeIdString);
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
        public ResponseStatusModel AddNewPlan(PlanDetails pd)
        {
            return repository.AddNewPlan(pd);
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
        public ResponseStatusModel ChangeLeadStatus(LeadDetails ld)
        {
            return repository.ChangeLeadStatus(ld);
        }
        public ResponseStatusModel RemoveLead(string LeadId,string UserId)
        {
            return repository.RemoveLead(LeadId, UserId);
        }
        public ResponseStatusModel RemovePlan(int PlanId)
        {
            return repository.RemovePlan(PlanId);
        }
        public ResponseStatusModel UpdatePlan(PlanDetails pd)
        {
            return repository.UpdatePlan(pd);
        }
        public ResponseStatusModel AddToFav(LeadDetails ld)
        {
            return repository.AddToFav(ld);
        }
        public GetUserDetails GetUserDetails(string UserId)
        {
            return repository.GetUserDetails(UserId);
        }
    }
}
