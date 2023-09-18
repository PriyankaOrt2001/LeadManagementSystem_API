using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Model
{
    public class RoleDetailsModel
    {
        public List<RoleDetails> RoleList
        {
            get; set;
        }
        public ResponseStatusModel Response { get; set; }
    }
    public class RoleDetails
    {
        public string CreatedBy { get; set; }
        public int RowNum { get; set; }
        public int SrNo { get; set; }
        public int Role_Id { get; set; }
        public string Role_Name { get; set; }
        public string Role_Price { get; set; }
    }
}
