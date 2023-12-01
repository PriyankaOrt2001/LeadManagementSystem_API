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
    public class LeadSourceController : ApiController
    {
        readonly LeadSourceService service = new LeadSourceService();
        ResponseMessageModel rm = new ResponseMessageModel();
        [HttpPost]
        [Route("api/v1/AddLeadSource")]
        public HttpResponseMessage AddLeadSource(LeadSourceDetails lcd)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.AddNewLeadSource(lcd);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "AddNewLeadSource" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        [Route("api/v1/RemoveLeadSource")]
        public HttpResponseMessage RemoveLeadSource(int id)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.RemoveLeadSource(id);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "RemoveLeadSource" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }


        [HttpGet]
        [Route("api/v1/ViewLeadSource")]
        public HttpResponseMessage ViewLeadSource(int SourceId)
        {
            LeadSourceDetails ld = new LeadSourceDetails();
            try
            {
                ld = service.ViewLeadSource(SourceId);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "ViewLeadSource" },
                    { "Controller", "LeadDataController" }
                };
                rm.response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, ld);
        }

        [HttpPost]
        [Route("api/v1/UpdateLeadSource")]
        public HttpResponseMessage UpdateLeadSource(LeadSourceDetails sd)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.UpdateLeadSource(sd);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "UpdateLeadSource" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        [Route("api/v1/GetSourceList")]
        public HttpResponseMessage GetSourceList()
        {
            LeadSourceModel lsm = new LeadSourceModel();
            try
            {
                lsm = service.GetSourceList();
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "GetSourceList" },
                    { "Controller", "LeadDataController" }
                };
                lsm.Response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, lsm);
        }
        
    }
}