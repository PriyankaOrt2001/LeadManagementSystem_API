using LMS_DAL;
using LMS_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_BAL
{
    public class LeadSourceService
    {
        readonly LeadSourceRepository repository = new LeadSourceRepository();
        public ResponseStatusModel AddNewLeadSource(LeadSourceDetails ld)
        {
            return repository.AddNewLeadSource(ld);
        }
        public ResponseStatusModel RemoveLeadSource(int SourceId)
        {
            return repository.RemoveLeadSource(SourceId);
        }
        public LeadSourceDetails ViewLeadSource(int SourceId)
        {
            return repository.ViewLeadSource(SourceId);
        }
        public ResponseStatusModel UpdateLeadSource(LeadSourceDetails sd)
        {
            return repository.UpdateLeadSource(sd);
        }
        public LeadSourceModel GetSourceList()
        {
            return repository.GetSourceList();
        }
    }
}
