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
    public class NotificationDataController : ApiController
    {
        readonly LeadDataService service = new LeadDataService();
        ResponseMessageModel rm = new ResponseMessageModel();
        [HttpGet]
        [Route("api/v1/NotificationDetails")]
        public HttpResponseMessage NotificationDetails(string UserId)
        {
            NotificationDetailsList NotificationDetailsList = new NotificationDetailsList();
            try
            {
                NotificationDetailsList = service.NotificationDetails(UserId);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "NotificationDetails" },
                    { "Controller", "LeadDataController" }
                };
                NotificationDetailsList.Response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, NotificationDetailsList);
        }
        [HttpGet]
        [Route("api/v1/RecentNotificationDetails")]
        public HttpResponseMessage RecentNotificationDetails(string UserId)
        {
            NotificationDetailsList NotificationDetailsList = new NotificationDetailsList();
            try
            {
                NotificationDetailsList = service.RecentNotificationDetails(UserId);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "RecentNotificationDetails" },
                    { "Controller", "LeadDataController" }
                };
                NotificationDetailsList.Response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, NotificationDetailsList);
        }

        [HttpGet]
        [Route("api/v1/UpdateNotificationSeenStatus")]
        public HttpResponseMessage UpdateNotificationSeenStatus(string UserId)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.UpdateNotificationSeenStatus(UserId);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "UpdateNotificationSeenStatus" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        [Route("api/v1/GetCountOfUnSeenNotification")]
        public HttpResponseMessage GetCountOfUnSeenNotification(string UserId)
        {
            GetCountOfUnSeenNotification rc = new GetCountOfUnSeenNotification();
            try
            {
                rc = service.GetCountOfUnSeenNotification(UserId);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "GetCountOfUnSeenNotification" },
                    { "Controller", "LeadDataController" }
                };
                rm.response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, rc);
        }
    }
}