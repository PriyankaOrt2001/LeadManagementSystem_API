using LMS_DAL;
using LMS_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_BAL
{
    public class EmployeeService
    {
        readonly EmployeeRepository repository = new EmployeeRepository();
        public AssignToModel GetAssignToList()
        {
            return repository.GetAssignToList();
        }
        public ResponseStatusModel AddNewAssignee(AssignToDetails ld)
        {
            return repository.AddNewAssignee(ld);
        }
        public ResponseStatusModel RemoveAssignee(int Assignee_Id)
        {
            return repository.RemoveAssignee(Assignee_Id);
        }
        public AssignToDetails ViewAssignToDetails(int Assignee_Id)
        {
            return repository.ViewAssignToDetails(Assignee_Id);
        }
        public ResponseStatusModel UpdateAssignee(AssignToDetails ad)
        {
            return repository.UpdateAssignee(ad);
        }
    }
}
