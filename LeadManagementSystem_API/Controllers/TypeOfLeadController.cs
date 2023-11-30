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
    public class TypeOfLeadController : ApiController
    {
        readonly LeadDataService service = new LeadDataService();
        ResponseMessageModel rm = new ResponseMessageModel();

        [HttpGet]
        [Route("api/v1/GetTypeOfLeadList")]
        public HttpResponseMessage GetTypeOfLeadList(int Category_Id)
        {
            TypeOfLeadModel tolm = new TypeOfLeadModel();
            try
            {
                tolm = service.GetTypeOfLeadList(Category_Id);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "GetTypeOfLeadList" },
                    { "Controller", "LeadDataController" }
                };
                tolm.Response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, tolm);
        }
        [HttpPost]
        [Route("api/v1/AddTypeOfLead")]
        public HttpResponseMessage AddTypeOfLead(TypeOfLeadDetails tol)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.AddTypeOfLead(tol);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "AddTypeOfLead" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        [Route("api/v1/RemoveTypeOfLead")]
        public HttpResponseMessage RemoveTypeOfLead(int id)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.RemoveTypeOfLead(id);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "RemoveTypeOfLead" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        [Route("api/v1/ViewTypeOfLeadDetails")]
        public HttpResponseMessage ViewTypeOfLeadDetails(int TypeOfLead_ID)
        {
            TypeOfLeadDetails ld = new TypeOfLeadDetails();
            try
            {
                ld = service.ViewTypeOfLeadDetails(TypeOfLead_ID);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "ViewTypeOfLeadDetails" },
                    { "Controller", "LeadDataController" }
                };
                rm.response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, ld);
        }

        [HttpPost]
        [Route("api/v1/UpdateTypeOfLead")]
        public HttpResponseMessage UpdateTypeOfLead(TypeOfLeadDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.UpdateTypeOfLead(ld);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "UpdateTypeOfLead" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        [Route("api/v1/GetLeadTypesList")]
        public HttpResponseMessage GetLeadTypesList()
        {
            TypeOfLeadModel lcm = new TypeOfLeadModel();
            try
            {
                lcm = service.GetLeadTypesList();
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "GetLeadTypesList" },
                    { "Controller", "LeadDataController" }
                };
                lcm.Response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, lcm);
        }
    }
}