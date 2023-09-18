using LeadManagementSystem_API.Security;
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
    [TokenAuth]
    public class RoleController : ApiController
    {
        readonly RoleService service = new RoleService();
        ResponseMessageModel rm = new ResponseMessageModel();
        [HttpGet]
        [Route("api/v1/GetRoleDetailsList")]
        public HttpResponseMessage GetRoleDetailsList()
        {
            RoleDetailsModel rdm = new RoleDetailsModel();
            try
            {
                rdm = service.GetRoleDetailsList();
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "GetRoleDetailsList" },
                    { "Controller", "RoleController" }
                };
                rdm.Response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, rdm);
        }
        [HttpPost]
        [Route("api/v1/AddNewRole")]
        public HttpResponseMessage AddNewRole(RoleDetails rd)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.AddNewRole(rd);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "AddNewRole" },
                    { "Controller", "RoleController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpPost]
        [Route("api/v1/UpdateRole")]
        public HttpResponseMessage UpdateRole(RoleDetails rd)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.UpdateRole(rd);

            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "UpdateRole" },
                    { "Controller", "RoleController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        [Route("api/v1/RemoveRole")]
        public HttpResponseMessage RemoveRole(int Role_Id)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.RemoveRole(Role_Id);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "RemoveRole" },
                    { "Controller", "RoleController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        [Route("api/v1/ViewRole")]
        public HttpResponseMessage ViewRole(int Role_Id)
        {
            RoleDetails rd = new RoleDetails();
            try
            {
                rd = service.ViewRole(Role_Id);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "ViewRole" },
                    { "Controller", "RoleController" }
                };
                rm.response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, rd);
        }
    }
}