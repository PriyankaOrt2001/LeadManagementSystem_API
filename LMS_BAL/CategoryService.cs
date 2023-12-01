using LMS_DAL;
using LMS_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_BAL
{
    public class CategoryService
    {
        readonly CategoryRepository repository = new CategoryRepository();
        public ResponseStatusModel UpdateCategory(LeadCategoryDetails cd)
        {
            return repository.UpdateCategory(cd);
        }
        public LeadCategoryModel GetLeadCategoryList()
        {
            return repository.GetLeadCategoryList();
        }
        public ResponseStatusModel AddCategory(LeadCategoryDetails lcd)
        {
            return repository.AddCategory(lcd);
        }
        public ResponseStatusModel RemoveCategory(int CategoryId)
        {
            return repository.RemoveCategory(CategoryId);
        }
        public LeadCategoryDetails ViewCategoryDetails(int Category_Id)
        {
            return repository.ViewCategoryDetails(Category_Id);
        }
    }
}
