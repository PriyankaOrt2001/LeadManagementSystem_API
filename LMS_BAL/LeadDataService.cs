using LMS_DAL;
using LMS_Model;
using System;
using System.Collections.Generic;
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
        public TypeOfLeadModel GetLeadTypesList()
        {
            return repository.GetLeadTypesList();
        }
        public LeadModel GetLeadDetailsList()
        {
            return repository.GetLeadDetailsList();
        }
        public CardImagesData GetImageDetailsList(string Lead_Id)
        {
            return repository.GetImageDetailsList(Lead_Id);
        }
        public LeadModel GetRecentLeadDetailsList()
        {
            return repository.GetRecentLeadDetailsList();
        }
        public ResponseStatusModel AddLead(LeadDetails ld)
        {
            return repository.AddLead(ld);
        }
        public ResponseStatusModel AddNewLeadSource(LeadSourceDetails ld)
        {
            return repository.AddNewLeadSource(ld);
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
        public ResponseStatusModel AddRemark(RemarkModel remarkModel)
        {
            return repository.AddRemark(remarkModel);
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
        public ResponseStatusModel ChangeLeadStatus(LeadDetails ld)
        {
            return repository.ChangeLeadStatus(ld);
        }
        public ResponseStatusModel RemoveComapny(int CompanyId)
        {
            return repository.RemoveCompany(CompanyId);
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
        public ResponseStatusModel UpdatePlan(PlanDetails pd)
        {
            return repository.UpdatePlan(pd);
        }
        public ResponseStatusModel AddToFav(LeadDetails ld)
        {
            return repository.AddToFav(ld);
        }
    }
}
