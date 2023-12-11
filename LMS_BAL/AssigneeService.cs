using LMS_DAL;
using LMS_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_BAL
{
    public class AssigneeService
    {
        readonly AssigneeRepository repository = new AssigneeRepository();
        public AssignToModel GetAssignToList()
        {
            return repository.GetAssignToList();
        }
        public AssigneeModel GetAssigneeList()
        {
            return repository.GetAssigneeList();
        }
        public ResponseStatusModel AddNewAssignee(AssigneeDetails ld)
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
        public ResponseStatusModel UpdateAssignee(AssigneeDetails ad)
        {
            return repository.UpdateAssignee(ad);
        }
    }
}
