using LMS_DAL;
using LMS_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_BAL
{
    public class OwnerService
    {
        readonly OwnerRepository repository = new OwnerRepository();
        public LeadOwnerModel GetOwnerList()
        {
            return repository.GetOwnerList();
        }
        public ResponseStatusModel AddNewLeadOwner(LeadOwnerDetails ld)
        {
            return repository.AddNewLeadOwner(ld);
        }
        public ResponseStatusModel RemoveLeadOwner(int OwnerId)
        {
            return repository.RemoveLeadOwner(OwnerId);
        }
        public LeadOwnerDetails ViewLeadOwner(int OwnerId)
        {
            return repository.ViewLeadOwner(OwnerId);
        }
        public ResponseStatusModel UpdateLeadOwner(LeadOwnerDetails sd)
        {
            return repository.UpdateLeadOwner(sd);
        }
        public GetLeadUpdatedByOwnerDetailsList GetLeadUpdatedByOwnerDetails(string LeadId)
        {
            return repository.GetLeadUpdatedByOwnerDetails(LeadId);
        }
        public LeadSourceModel GetLeadSourceList()
        {
            return repository.GetLeadSourceList();
        }
    }
}
