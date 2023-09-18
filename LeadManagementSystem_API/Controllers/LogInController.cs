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
    public class LogInController : ApiController
    {
        EncryptDecryptService eds = new EncryptDecryptService();
        LogOutService los = new LogOutService();
        LoginService ls = new LoginService();

        [Route("api/v1/login")]
        [HttpPost]
        public HttpResponseMessage Login(LoginModel login)
        {
            LoginModel lm = new LoginModel();
            UserResponseModelViewModel urmvm = new UserResponseModelViewModel();
            urmvm.response = new ResponseStatusModel();
            if (string.IsNullOrEmpty(login.UserName) || string.IsNullOrEmpty(login.Password))
            {
                urmvm.response.n = 0;
                urmvm.response.RStatus = "Failed";
                urmvm.response.msg = "Username and password is mandatory";
            }
            else
            {
                login.Password = eds.Encrypt(login.Password);
                urmvm = ls.login(login);

            }
            return Request.CreateResponse(HttpStatusCode.OK, urmvm);
        }

        [Route("api/v1/logout")]
        [HttpGet]
        [TokenAuth]
        public HttpResponseMessage logout(string UserId)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = los.LogOut(UserId);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "logout" },
                    { "Controller", "LogIn" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);

        }
    }
}