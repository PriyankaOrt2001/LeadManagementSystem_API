using LMS_DAL;
using LMS_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_BAL
{
    public class TypeOfLeadService
    {
        readonly TypeOfLeadRepository repository = new TypeOfLeadRepository();
        public TypeOfLeadModel GetTypeOfLeadList(int Category_Id)
        {
            return repository.GetTypeOfLeadList(Category_Id);
        }
        public ResponseStatusModel AddTypeOfLead(TypeOfLeadDetails tol)
        {
            return repository.AddTypeOfLead(tol);
        }
        public ResponseStatusModel RemoveTypeOfLead(int TypeOfLeadId)
        {
            return repository.RemoveTypeOfLead(TypeOfLeadId);
        }
        public TypeOfLeadDetails ViewTypeOfLeadDetails(int TypeOfLead_ID)
        {
            return repository.ViewTypeOfLeadDetails(TypeOfLead_ID);
        }
        public ResponseStatusModel UpdateTypeOfLead(TypeOfLeadDetails ld)
        {
            return repository.UpdateTypeOfLead(ld);
        }
        public TypeOfLeadModel GetLeadTypesList()
        {
            return repository.GetLeadTypesList();
        }
    }
}
