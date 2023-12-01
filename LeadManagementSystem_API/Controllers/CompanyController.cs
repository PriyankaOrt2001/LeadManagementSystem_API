using LeadManagementSystem_API.Services;
using LMS_BAL;
using LMS_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace LeadManagementSystem_API.Controllers
{
    public class CompanyController : ApiController
    {
        readonly CompanyService service = new CompanyService();
        ResponseMessageModel rm = new ResponseMessageModel();

        [HttpPost]
        [Route("api/v1/AddNewComapny")]
        public HttpResponseMessage AddNewComapny(CompanyDetails lcd)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.AddNewComapny(lcd);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "AddNewComapny" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        [Route("api/v1/RemoveCompany")]
        public HttpResponseMessage RemoveCompany(int id)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.RemoveComapny(id);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "RemoveCompany" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        [Route("api/v1/ViewCompanyDetails")]
        public HttpResponseMessage ViewCompanyDetails(int Company_Id)
        {
            CompanyDetails ld = new CompanyDetails();
            try
            {
                ld = service.ViewCompanyDetails(Company_Id);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "ViewCompanyDetails" },
                    { "Controller", "LeadDataController" }
                };
                rm.response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, ld);
        }

        [HttpPost]
        [Route("api/v1/UpdateCompany")]
        public HttpResponseMessage UpdateCompany(CompanyDetails cmm)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.UpdateCompany(cmm);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "UpdateCompany" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        [Route("api/v1/GetCompanyList")]
        public HttpResponseMessage GetCompanyList()
        {
            CompanyModel cm = new CompanyModel();
            try
            {
                cm = service.GetCompanyList();
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "GeCompanyList" },
                    { "Controller", "LeadDataController" }
                };
                cm.Response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, cm);
        }
    }
}