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
    public class MenuItemController : ApiController
    {
        MenuItemService mis = new MenuItemService();
        [HttpGet]
        [Route("api/v1/GetMeanuItemDetailsList")]
        public HttpResponseMessage GetMeanuItemDetailsList()
        {
            MenuItemViewModel menuitemresponse = new MenuItemViewModel();
            try
            {
                menuitemresponse = mis.GetAllSideMenuItem();
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "GetMeanuItemDetailsList" },
                    { "Controller" , "LeadDataController" }
                };
                menuitemresponse.Response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, menuitemresponse);
        }

    }
}