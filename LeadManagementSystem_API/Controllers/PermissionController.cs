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
    public class PermissionController : ApiController
    {
        ResponseMessageModel rm = new ResponseMessageModel();
        PermissionService ps = new PermissionService();
        [Route("api/v1/AddRolePermission")]
        [HttpPost]
        public HttpResponseMessage AddRolePermission(permission permission)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = ps.AddRolePermission(permission.RoleID, permission.MenuId,permission.SessionID);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "AddRolePermission" },
                    { "Controller", "PermissionController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        [Route("api/v1/GetRolePermission")]
        public HttpResponseMessage GetRolePermission(string RoleId)
        {
            RolePermissionViewModel rpvm = new RolePermissionViewModel();
            try
            {
                rpvm = ps.GetRolePermission(RoleId);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "GetRolePermission" },
                    { "Controller", "PermissionController" }
                };
                rm.response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, rpvm);
        }
    }
}