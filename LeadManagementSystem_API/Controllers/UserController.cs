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
    public class UserController : ApiController
    {
        EncryptDecryptService eds = new EncryptDecryptService();
        LogOutService los = new LogOutService();
        LoginService ls = new LoginService();
        readonly UserService service = new UserService();
        ResponseMessageModel rm = new ResponseMessageModel();
        [HttpGet]
        [Route("api/v1/GetUserList")]
        public HttpResponseMessage GetUserList()
        {
            UserResponseModelViewModel uvm = new UserResponseModelViewModel();
            try
            {
                uvm = service.GetUserList();
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "GetUserList" },
                    { "Controller", "UserController" }
                };
                uvm.response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, uvm);
        }
        [HttpPost]
        [Route("api/v1/AddNewUser")]
        public HttpResponseMessage AddNewUser(UserModel um)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                um.Password = eds.Encrypt(um.Password);
                response = service.AddNewUser(um);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "AddNewUser" },
                    { "Controller", "UserController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
       
    }
}