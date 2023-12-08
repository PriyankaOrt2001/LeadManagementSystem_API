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
    public class AssigneeController : ApiController
    {
        readonly AssigneeService service = new AssigneeService();
        ResponseMessageModel rm = new ResponseMessageModel();
        [HttpGet]
        [Route("api/v1/GetAssignToList")]
        public HttpResponseMessage GetAssignToList()
        {
            AssignToModel am = new AssignToModel();
            try
            {
                am = service.GetAssignToList();
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "GetAssignToList" },
                    { "Controller", "AssigneeController" }
                };
                am.Response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, am);
        }
        [HttpPost]
        [Route("api/v1/AddNewAssignee")]
        public HttpResponseMessage AddNewAssignee(AssignToDetails lcd)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.AddNewAssignee(lcd);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "AddNewAssignee" },
                    { "Controller", "AssigneeController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        [Route("api/v1/RemoveAssignee")]
        public HttpResponseMessage RemoveAssignee(int id)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.RemoveAssignee(id);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "RemoveAssignee" },
                    { "Controller", "AssigneeController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        [Route("api/v1/ViewAssignToDetails")]
        public HttpResponseMessage ViewAssignToDetails(int Assignee_Id)
        {
            AssignToDetails ld = new AssignToDetails();
            try
            {
                ld = service.ViewAssignToDetails(Assignee_Id);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "ViewAssignToDetails" },
                    { "Controller", "AssigneeController" }
                };
                rm.response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, ld);
        }
        [HttpPost]
        [Route("api/v1/UpdateAssignee")]
        public HttpResponseMessage UpdateAssignee(AssignToDetails atd)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.UpdateAssignee(atd);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "UpdateAssignee" },
                    { "Controller", "AssigneeController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

    }
}