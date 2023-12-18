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
        public SubCategoryModel GetSubCategoryList(int Category_Id)
        {
            return repository.GetSubCategoryList(Category_Id);
        }
        public TypeOfLeadModel GetTypeOfLeadList(int Category_Id)
        {
            return repository.GetTypeOfLeadList(Category_Id);
        }
        public ResponseStatusModel AddSubCategory(SubCategoryDetails tol)
        {
            return repository.AddSubCategory(tol);
        }
        public ResponseStatusModel RemoveSubCategory(int SubCategoryId)
        {
            return repository.RemoveSubCategory(SubCategoryId);
        }
        public SubCategoryDetails ViewSubCategoryDetails(int SubCategory_ID)
        {
            return repository.ViewSubCategoryDetails(SubCategory_ID);
        }
        public ResponseStatusModel UpdateSubCategory(SubCategoryDetails ld)
        {
            return repository.UpdateSubCategory(ld);
        }
        public SubCategoryModel GetSubCategoryList()
        {
            return repository.GetSubCategoryList();
        }
    }
}
