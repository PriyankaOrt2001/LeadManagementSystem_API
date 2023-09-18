using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Model
{
    public class LeadCategoryModel
    {
        public List<LeadCategoryDetails> LeadCategoryList
        {
            get; set;
        }
        public ResponseStatusModel Response { get; set; }
    }
    public class LeadCategoryDetails
    {
        public int CreatedBy { get; set; }
        public int RowNum { get; set; }
        public int SrNo { get; set; }
        public int Category_Id { get; set; }
        public string Category_Name { get; set; }
    }
    public class TypeOfLeadModel
    {
        public List<TypeOfLeadDetails> TypeOfLeadList
        {
            get; set;
        }
        public ResponseStatusModel Response { get; set; }
    }
    public class TypeOfLeadDetails
    {
        public int CreatedBy { get; set; }
        public int RowNum { get; set; }
        public int SrNo { get; set; }
        public string Category_Name { get; set; }
        public int Category_Id { get; set; }
        public int TypeOfLead_ID { get; set; }
        public string TypeOfLead { get; set; }
    }
}
