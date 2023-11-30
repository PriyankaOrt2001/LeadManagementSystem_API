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
    public class OwnerController : ApiController
    {
        readonly LeadDataService service = new LeadDataService();
        ResponseMessageModel rm = new ResponseMessageModel();
        [HttpGet]
        [Route("api/v1/GetOwnerList")]
        public HttpResponseMessage GetOwnerList()
        {
            LeadOwnerModel lsm = new LeadOwnerModel();
            try
            {
                lsm = service.GetOwnerList();
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "GetOwnerList" },
                    { "Controller", "LeadDataController" }
                };
                lsm.Response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, lsm);
        }
        [HttpPost]
        [Route("api/v1/AddNewLeadOwner")]
        public HttpResponseMessage AddNewLeadOwner(LeadOwnerDetails lcd)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.AddNewLeadOwner(lcd);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "AddNewLeadOwner" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        [Route("api/v1/RemoveLeadOwner")]
        public HttpResponseMessage RemoveLeadOwner(int id)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.RemoveLeadOwner(id);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "RemoveLeadOwner" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        [Route("api/v1/ViewLeadOwner")]
        public HttpResponseMessage ViewLeadOwner(int OwnerId)
        {
            LeadOwnerDetails ld = new LeadOwnerDetails();
            try
            {
                ld = service.ViewLeadOwner(OwnerId);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "ViewLeadOwner" },
                    { "Controller", "LeadDataController" }
                };
                rm.response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, ld);
        }

        [HttpPost]
        [Route("api/v1/UpdateLeadOwner")]
        public HttpResponseMessage UpdateLeadOwner(LeadOwnerDetails sd)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.UpdateLeadOwner(sd);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "UpdateLeadOwner" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        [Route("api/v1/GetLeadUpdatedByOwnerDetailsList")]
        public HttpResponseMessage GetLeadUpdatedByOwnerDetailsList(string LeadId)
        {
            GetLeadUpdatedByOwnerDetailsList od = new GetLeadUpdatedByOwnerDetailsList();
            try
            {
                od = service.GetLeadUpdatedByOwnerDetails(LeadId);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "GetLeadUpdatedByOwnerDetailsList" },
                    { "Controller", "LeadDataController" }
                };
                od.Response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, od);
        }
        [HttpGet]
        [Route("api/v1/GetLeadSourceList")]
        public HttpResponseMessage GetLeadSourceList()
        {
            LeadSourceModel lsm = new LeadSourceModel();
            try
            {
                lsm = service.GetLeadSourceList();
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "GetLeadSourceList" },
                    { "Controller", "LeadDataController" }
                };
                lsm.Response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, lsm);
        }
    }
}