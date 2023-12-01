using LMS_DAL;
using LMS_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_BAL
{
    public class CompanyService
    {
        readonly CompanyRepository repository = new CompanyRepository();
        public ResponseStatusModel AddNewComapny(CompanyDetails cd)
        {
            return repository.AddNewComapny(cd);
        }
        public ResponseStatusModel RemoveComapny(int CompanyId)
        {
            return repository.RemoveCompany(CompanyId);
        }
        public CompanyDetails ViewCompanyDetails(int Company_Id)
        {
            return repository.ViewCompanyDetails(Company_Id);
        }
        public ResponseStatusModel UpdateCompany(CompanyDetails cmm)
        {
            return repository.UpdateCompany(cmm);
        }
        public CompanyModel GetCompanyList()
        {
            return repository.GetCompanyList();
        }
    }
}
