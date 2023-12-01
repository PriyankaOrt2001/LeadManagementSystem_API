using LeadManagementSystem_API.Services;
using LMS_BAL;
using LMS_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace LeadManagementSystem_API.Controllers
{
    public class RemarkController : ApiController
    {
        readonly RemarkService service = new RemarkService();
        ResponseMessageModel rm = new ResponseMessageModel();
        public void SendNotificationToUser(List<string> deviceTokenes, string text, string title)
        {
            var result = new List<string>();
            try
            {
                var SERVER_KEY_TOKEN = "AAAAdFKUt_M:APA91bHkpzqinGJfXBhgQsntqSzEmovuR8J8I2hg3e8HbjFatHN0EY2F3Z8Dj1NkJ2DDGoZSBfYA3LTh5OIysFD_6_VZsY0uLRrHY2xTOyBHcBvrWykCRj26vik6tGhJHl2rFUu_YN-b";
                var senderId = "499601684467";
                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                var data = new
                {
                    registration_ids = deviceTokenes,
                    notification = new
                    {
                        body = text,
                        title = title,
                        icon = "myicon"
                    }
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(data);

                Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                tRequest.Headers.Add(string.Format("Authorization: key={0}", SERVER_KEY_TOKEN));
                tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                tRequest.ContentLength = byteArray.Length;
                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                string sResponseFromServer = tReader.ReadToEnd();
                                result.Add("Error: " + sResponseFromServer);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                string str = ex.Message;

            }
        }

        [HttpGet]
        [Route("api/v1/GetRemarkCount")]
        public HttpResponseMessage GetRemarkCount(string Lead_Id)
        {
            GetRemarkCount rc = new GetRemarkCount();
            try
            {
                rc = service.GetRemarkCount(Lead_Id);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "GetRemarkCount" },
                    { "Controller", "LeadDataController" }
                };
                rm.response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, rc);
        }
        [HttpPost]
        [Route("api/v1/UpdateRemark")]
        public HttpResponseMessage UpdateRemark(RemarkModel rm)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.UpdateRemark(rm);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "UpdateRemark" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpPost]
        [Route("api/v1/AddRemarkAndNotify")]
        public HttpResponseMessage AddRemarkAndNotify(RemarkModel remarkModel)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                var userlist = service.GetUserList();
                List<string> deviceTokens = userlist.GetUserDetails.Select(obj => obj.DeviceId).ToList();
                var userdetails = service.GetUserDetails(remarkModel.CreatedBy);
                var productname = service.ViewLead(remarkModel.Lead_Id);
                string deviceId = string.Empty;
                string ProductName = string.Empty;
                if (productname.ClientName == null)
                {
                    ProductName = "";
                }
                else { ProductName = productname.ClientName; };
                string title = $"New Remark added to {ProductName} by {userdetails.UserFullName}.";
                string body = remarkModel.Remark;

                DataTable myDataTable = new DataTable();

                myDataTable.Columns.Add("RowID", typeof(int));
                myDataTable.Columns.Add("NotificationSendTo", typeof(string));
                myDataTable.Columns.Add("NotificationSendBy", typeof(string));
                myDataTable.Columns.Add("NotificationType", typeof(string));
                myDataTable.Columns.Add("NotificationMsg", typeof(string));
                myDataTable.Columns.Add("NotificationTitle", typeof(string));

                int i = 1;
                foreach (var value in userlist.GetUserDetails)
                {
                    myDataTable.Rows.Add(i, value.UserID, remarkModel.CreatedBy, "Reminder", remarkModel.Remark, title);
                    i++;
                }

                if (userlist == null)
                {
                    response = service.AddRemark(remarkModel, myDataTable);
                }
                else
                {
                    SendNotificationToUser(deviceTokens, body, title);
                    response = service.AddRemark(remarkModel, myDataTable);
                }
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "AddRemarkAndNotify" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpPost]
        [Route("api/v1/AddRemark")]
        public HttpResponseMessage AddRemark(RemarkModel remarkModel)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                var userlist = service.GetUserListToSendNotification(remarkModel.Lead_Id);
                List<string> deviceTokens = userlist.GetUserListToSendNotification.Select(obj => obj.DeviceId).ToList();
                var userdetails = service.GetUserDetails(remarkModel.CreatedBy);
                var productname = service.ViewLead(remarkModel.Lead_Id);
                string deviceId = string.Empty;
                string ProductName = string.Empty;
                if (productname.ClientName == null)
                {
                    ProductName = "";
                }
                else { ProductName = productname.ClientName; };
                string title = $"New Remark added to {ProductName} by {userdetails.UserFullName}.";
                string body = remarkModel.Remark;

                DataTable myDataTable = new DataTable();

                myDataTable.Columns.Add("RowID", typeof(int));
                myDataTable.Columns.Add("NotificationSendTo", typeof(string));
                myDataTable.Columns.Add("NotificationSendBy", typeof(string));
                myDataTable.Columns.Add("NotificationType", typeof(string));
                myDataTable.Columns.Add("NotificationMsg", typeof(string));
                myDataTable.Columns.Add("NotificationTitle", typeof(string));

                int i = 1;
                foreach (var value in userlist.GetUserListToSendNotification)
                {
                    myDataTable.Rows.Add(i, value.UserId, remarkModel.CreatedBy, "Reminder", remarkModel.Remark, title);
                    i++;
                }

                if (userlist == null)
                {
                    response = service.AddRemark(remarkModel, myDataTable);
                }
                else
                {
                    SendNotificationToUser(deviceTokens, body, title);
                    response = service.AddRemark(remarkModel, myDataTable);
                }
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "AddRemark" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        [Route("api/v1/GetRemarksList")]
        public HttpResponseMessage GetRemarksList(string Lead_Id)
        {
            RemarkModelList rml = new RemarkModelList();
            try
            {
                rml = service.GetRemarksList(Lead_Id);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "GetRemarksList" },
                    { "Controller" , "LeadDataController" }
                };
                rml.Response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, rml);
        }
        [HttpGet]
        [Route("api/v1/GetRecentRemarksList")]
        public HttpResponseMessage GetRecentRemarksList()
        {
            RemarkModelList rml = new RemarkModelList();
            try
            {
                rml = service.GetRecentRemarksList();
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "GetRecentRemarksList" },
                    { "Controller" , "LeadDataController" }
                };
                rml.Response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, rml);
        }
    }
}