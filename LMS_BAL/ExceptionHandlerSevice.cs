using LMS_DAL;
using LMS_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_BAL
{
    public class ExceptionHandlerSevice
    {
        readonly ExceptionHandlerRepository repository = new ExceptionHandlerRepository();
        public void SaveException(ExceptionModel em)
        {
            repository.SaveException(em);
        }
    }
}
