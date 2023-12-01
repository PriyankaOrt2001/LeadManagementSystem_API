using LeadManagementSystem_API.Security;
using LeadManagementSystem_API.Services;
using LMS_BAL;
using LMS_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace LeadManagementSystem_API.Controllers
{
    [TokenAuth]
    public class LeadDataController : ApiController
    {
        readonly LeadDataService service = new LeadDataService();
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
                    registration_ids= deviceTokenes,
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
        [Route("api/v1/GetClientDetailsList")]
        public HttpResponseMessage GetClientDetailsList()
        {
            ClientModel cm = new ClientModel();
            try
            {
                cm = service.GetClientList();
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "GetClientDetailsList" },
                    { "Controller", "LeadDataController" }
                };
                cm.Response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, cm);
        }
        [HttpGet]
        [Route("api/v1/GetPlanDetailsList")]
        public HttpResponseMessage GetPlanDetailsList()
        {
            PlanDetailsModel cm = new PlanDetailsModel();
            try
            {
                cm = service.GetPlanDetailsList();
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "GetPlanDetailsList" },
                    { "Controller", "LeadDataController" }
                };
                cm.Response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, cm);
        }
        
        [HttpGet]
        [Route("api/v1/GetPlanPrice")]
        public HttpResponseMessage GetPlanPrice(int Plan_Id)
        {
            PlanDetails pd = new PlanDetails();
            try
            {
                pd = service.GetPlanPrice(Plan_Id);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "GetPlanPrice" },
                    { "Controller", "LeadDataController" }
                };
                rm.response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, pd);
        }
        [HttpGet]
        [Route("api/v1/GetLeadDetailsList")]
        public HttpResponseMessage GetLeadDetailsList(string UserId)
        {
            LeadModel lm = new LeadModel();
            CardImagesData cid = new CardImagesData();
            try
            {
                lm = service.GetLeadDetailsList(UserId);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "GetLeadDetailsList" },
                    { "Controller" , "LeadDataController" }
                };
                lm.Response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, lm);
        }
        [HttpPost]
        [Route("api/v1/GetLeadDataList")]
        public HttpResponseMessage GetLeadDataList(LeadFilterParameters leadFilterParameters)
        {
            LeadModel lm = new LeadModel();
            try
            {
                string companyIdString = string.Join(",", leadFilterParameters.CompanyId);
                string categoryIdString = string.Join(",", leadFilterParameters.CategoryId);
                string priorityString = string.Join(",", leadFilterParameters.Priority.Select(c => $"'{c}'"));
                string assigneeIdString = string.Join(",", leadFilterParameters.AssigneeId);
                lm = service.GetLeadDataList(leadFilterParameters.UserId,companyIdString, categoryIdString, priorityString, assigneeIdString);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "GetLeadDataList" },
                    { "Controller" , "LeadDataController" }
                };
                lm.Response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, lm);
        }
        [HttpPost]
        [Route("api/v1/FilterLeadTableDetails")] 
        public HttpResponseMessage FilterLeadTableDetails(FilterBy filterBy)
        {
            LeadModel lm = new LeadModel();
            try
            {
                lm = service.GetLeadDetailsList(filterBy.UserId);
                var filterLists = new List<List<string>> {
                filterBy.CompanyId?.Split(',').Select(s => s.Trim('\'')).ToList(),
                filterBy.CategoryId?.Split(',').Select(s => s.Trim('\'')).ToList(),
                filterBy.AssignedId?.Split(',').Select(s => s.Trim('\'')).ToList(),
                filterBy.Priority?.Split(',').Select(s => s.Trim('\'')).ToList()
                };
                var filters = new List<Func<LeadDetails, bool>> {
                data => filterLists[0]?.Contains(data.CompanyId) ?? true,
                data => filterLists[1]?.Contains(data.ProjectTypeId) ?? true,
                data => filterLists[2]?.Contains(data.AssignToId) ?? true,
                data => filterLists[3]?.Contains(data.Category) ?? true
                };
                lm.LeadList = filters.Aggregate(lm.LeadList, (current, filter) => current.Where(filter).ToList());

            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "FilterLeadTableDetails" },
                    { "Controller" , "LeadDataController" }
                }; 
                lm.Response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, lm);
        }

        [HttpGet]
        [Route("api/v1/GetRecentLeadDetailsList")]
        public HttpResponseMessage GetRecentLeadDetailsList()
        {
            LeadModel lm = new LeadModel();
            try
            {
                lm = service.GetRecentLeadDetailsList();
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "GetRecentLeadDetailsList" },
                    { "Controller" , "LeadDataController" }
                };
                lm.Response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, lm);
        }

        [HttpPost]
        [Route("api/v1/AddLead")]
        public HttpResponseMessage AddLead(LeadDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                var userlist = service.GetUserList();
                List<string> deviceTokens = userlist.GetUserDetails.Select(obj => obj.DeviceId).ToList();
                var userdetails = service.GetUserDetails(ld.CreatedBy);
                string deviceId = string.Empty;
                string title = $"{userdetails.UserFullName} added New Lead.";
                string body = "";

                if (!ld.ScheduleDate.Contains('/')  && ld.ScheduleDate!="")
                {
                    DateTime originalDate = DateTime.Parse(ld.ScheduleDate);
                    ld.ScheduleDate = originalDate.ToString("MM/dd/yyyy");
                }
                DataTable myDataTable = new DataTable();

                myDataTable.Columns.Add("RowID", typeof(int));
                myDataTable.Columns.Add("NotificationSendTo", typeof(string));
                myDataTable.Columns.Add("NotificationSendBy", typeof(string));
                myDataTable.Columns.Add("NotificationType", typeof(string));
                myDataTable.Columns.Add("NotificationMsg", typeof(string));
                myDataTable.Columns.Add("NotificationTitle", typeof(string));

                int j = 1;
                foreach (var value in userlist.GetUserDetails)
                {
                    myDataTable.Rows.Add(j, value.UserID, ld.CreatedBy, "Notification","", title);
                    j++;
                }

                List<CardImages> CardImages = new List<CardImages>();
                for (int i = 0; i < 2; i++)
                {
                    if (i == 0)
                    {
                        CardImages.Add(new CardImages()
                        {
                            Base64 = ld.FrontImgBase64,
                            Filename = ld.FrontImgFileName,
                            FileType = ld.FrontImgFileType,
                            ImagePath = ld.FrontImgOfCardPath,
                            ImgType = "front"
                        });
                    }
                    else if (i == 1)
                    { 
                        CardImages.Add(new CardImages()
                        {
                            Base64 = ld.BackImgBase64,
                            Filename = ld.BackImgFileName,
                            FileType = ld.BackImgFileType,
                            ImagePath = ld.BackImgOfCardPath,
                            ImgType = "back"
                        });
                    }
                }

                if (CardImages == null)
                {
                    if (userlist == null)
                    {
                        response = service.AddLead(ld, myDataTable);
                    }
                    else
                    {
                        SendNotificationToUser(deviceTokens, body, title);
                        response = service.AddLead(ld, myDataTable);
                    }
                }
                else
                {
                    foreach (var imagedata in CardImages)
                    {
                        if (!string.IsNullOrEmpty(imagedata.Base64) && !string.IsNullOrEmpty(imagedata.Filename))
                        {
                            string filename = imagedata.Filename;
                            FileInfo fi = new FileInfo(filename);
                            if (imagedata.Base64.Split(new string[] { "base64," }, StringSplitOptions.None).Length > 1)
                            {
                                imagedata.Base64 = imagedata.Base64.Split(new string[] { "base64," }, StringSplitOptions.None)[1];
                            }
                            byte[] byteArray = Convert.FromBase64String(imagedata.Base64);
                            MemoryStream stream = new MemoryStream(byteArray);
                            string extension = Path.GetExtension(imagedata.Filename).ToLower();
                            string[] extensions = { ".jpg", ".jpeg", ".png",".svg", ".jfif" };
                            if (string.IsNullOrEmpty(imagedata.Base64) || !extensions.Any(x => x.Equals(Path.GetExtension(imagedata.Filename).ToLower(), StringComparison.OrdinalIgnoreCase)))
                            {
                                response.msg = "Wrong File Format";
                            }
                            else
                            {
                                System.IO.BinaryReader r = new System.IO.BinaryReader(stream);
                                string fileclass = "";
                                byte buffer1;
                                try
                                {
                                    buffer1 = r.ReadByte();
                                    fileclass = buffer1.ToString();
                                    buffer1 = r.ReadByte();
                                    fileclass += buffer1.ToString();
                                }
                                catch (Exception ex)
                                {
                                    response.msg = "Wrong File Format";
                                }
                                if ((fileclass == "255216" && extension == ".jpg") || (fileclass == "13780" && extension == ".png")|| (fileclass == "255216" && extension == ".jpeg")|| (fileclass == "255216" && extension == ".jfif" ) || (fileclass== "6063" && extension==".svg"))
                                {
                                    var newFilename = Convert.ToString(Guid.NewGuid()).Replace("-", "");
                                    byte[] imageBytes = Convert.FromBase64String(imagedata.Base64);
                                    string ServerPath = System.Configuration.ConfigurationManager.AppSettings["serverUrl"];
                                    var path = HttpRuntime.AppDomainAppPath;
                                    var filepath = System.IO.Path.Combine(path, "Documents/" + newFilename + extension);
                                    if (!Directory.Exists(path + "Documents"))
                                    {
                                        Directory.CreateDirectory(path + "Documents");
                                    }
                                    System.IO.File.WriteAllBytes(filepath, imageBytes);
                                    if (imagedata.ImgType == "front")
                                    {
                                        ld.FrontImgFileType = fi.Extension;
                                        ld.FrontImgOfCardPath = ServerPath + "Documents/" + newFilename + extension;
                                    }
                                    else if (imagedata.ImgType == "back")
                                    {
                                        ld.FrontImgFileType = fi.Extension;
                                        ld.BackImgOfCardPath = ServerPath + "Documents/" + newFilename + extension;
                                    }
                                    else
                                    {
                                        imagedata.FileType = fi.Extension;
                                        imagedata.ImagePath = ServerPath + "Documents/" + newFilename + extension;
                                    }
                                }
                                else
                                {
                                    response.msg = "Wrong File Format";
                                }
                            }
                        }
                    }
                    if (response.msg == null)
                    {
                        if (userlist == null)
                        {
                            response = service.AddLead(ld,myDataTable);
                        }
                        else
                        {
                            SendNotificationToUser(deviceTokens, body, title);
                            response = service.AddLead(ld, myDataTable);
                        }
                    }
                    else
                    {
                        response.n = 0;
                        response.RStatus = "Failed";
                        response.LeadId = "";
                    }
                }
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "AddLead" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        [Route("api/v1/ViewLead")]
        public HttpResponseMessage ViewLead(string Lead_Id)
        {
            LeadDetails ld = new LeadDetails();
            CardImagesData cid = new CardImagesData();
            try
            {
                ld = service.ViewLead(Lead_Id);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "ViewLead" },
                    { "Controller", "LeadDataController" }
                };
                rm.response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, ld);
        }
        [HttpGet]
        [Route("api/v1/ViewLeadDetails")]
        public HttpResponseMessage ViewLeadDetails(string Lead_Id)
        {
            LeadDetails ld = new LeadDetails();
            CardImagesData cid = new CardImagesData();
            try
            {
                ld = service.ViewLeadDetails(Lead_Id);
                cid = service.GetImageDetailsList(Lead_Id);

            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "ViewLeadDetails" },
                    { "Controller", "LeadDataController" }
                };
                rm.response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, ld);
        }
        
        [HttpPost]
        [Route("api/v1/UpdateFinalLead")]
        public HttpResponseMessage UpdateFinalLead(LeadDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.UpdateFinalLead(ld);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "UpdateFinalLead" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        
        [HttpPost]
        [Route("api/v1/UpdateLead")]
        public HttpResponseMessage UpdateLead(LeadDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                CardImagesData cid = new CardImagesData();
                cid = service.GetImageList(ld.LeadId);
                if (!ld.ScheduleDate.Contains('/') && ld.ScheduleDate != "")
                {
                    DateTime originalDate = DateTime.Parse(ld.ScheduleDate);
                    ld.ScheduleDate = originalDate.ToString("MM/dd/yyyy");
                }
                List<CardImages> CardImages = new List<CardImages>();
                for (int i = 0; i < 2; i++)
                {
                    if (i == 0)
                    {
                        CardImages.Add(new CardImages()
                        {
                            Base64 = ld.FrontImgBase64,
                            Filename = ld.FrontImgFileName,
                            FileType = ld.FrontImgFileType,
                            ImagePath = ld.FrontImgOfCardPath,
                            ImgType = "front"
                        });
                    }
                    else if (i == 1)
                    {
                        CardImages.Add(new CardImages()
                        {
                            Base64 = ld.BackImgBase64,
                            Filename = ld.BackImgFileName,
                            FileType = ld.BackImgFileType,
                            ImagePath = ld.BackImgOfCardPath,
                            ImgType = "back"
                        });
                    }
                }

                if (CardImages == null)
                {
                    response = service.UpdateLead(ld);
                }
                else
                {
                    foreach (var imagedata in CardImages)
                    {
                        if (!string.IsNullOrEmpty(imagedata.Base64) && !string.IsNullOrEmpty(imagedata.Filename))
                        {
                            string filename = imagedata.Filename;
                            FileInfo fi = new FileInfo(filename);
                            imagedata.FileType = fi.Extension;
                            if (imagedata.Base64.Split(new string[] { "base64," }, StringSplitOptions.None).Length > 1)
                            {
                                imagedata.Base64 = imagedata.Base64.Split(new string[] { "base64," }, StringSplitOptions.None)[1];
                            }
                            byte[] byteArray = Convert.FromBase64String(imagedata.Base64);
                            MemoryStream stream = new MemoryStream(byteArray);
                            string extension = Path.GetExtension(imagedata.Filename).ToLower();
                            string[] extensions = { ".jpg", ".jpeg", ".png", ".svg", ".jfif" };
                            if (string.IsNullOrEmpty(imagedata.Base64) || !extensions.Any(x => x.Equals(Path.GetExtension(imagedata.Filename).ToLower(), StringComparison.OrdinalIgnoreCase)))
                            {
                                response.msg = "Wrong File Format";
                            }
                            else
                            {
                                System.IO.BinaryReader r = new System.IO.BinaryReader(stream);
                                string fileclass = "";
                                byte buffer1;
                                try
                                {
                                    buffer1 = r.ReadByte();
                                    fileclass = buffer1.ToString();
                                    buffer1 = r.ReadByte();
                                    fileclass += buffer1.ToString();
                                }
                                catch (Exception ex)
                                {
                                    response.msg = "Wrong File Format";

                                }
                                if ((fileclass == "255216" && extension == ".jpg") || (fileclass == "13780" && extension == ".png") || (fileclass == "255216" && extension == ".jpeg") || (fileclass == "255216" && extension == ".jfif") || (fileclass == "6063" && extension == ".svg"))
                                {
                                    var newFilename = Convert.ToString(Guid.NewGuid()).Replace("-", "");
                                    byte[] imageBytes = Convert.FromBase64String(imagedata.Base64);
                                    string ServerPath = System.Configuration.ConfigurationManager.AppSettings["serverUrl"];
                                    var path = HttpRuntime.AppDomainAppPath;
                                    var filepath = System.IO.Path.Combine(path, "Documents/" + newFilename + extension);
                                    if (!Directory.Exists(path + "Documents"))
                                    {
                                        Directory.CreateDirectory(path + "Documents");
                                    }
                                    System.IO.File.WriteAllBytes(filepath, imageBytes);
                                    if (imagedata.ImgType == "front")
                                    {
                                        ld.FrontImgFileType = fi.Extension;
                                        ld.FrontImgOfCardPath = ServerPath + "Documents/" + newFilename + extension;
                                    }
                                    else if (imagedata.ImgType == "back")
                                    {
                                        ld.FrontImgFileType = fi.Extension;
                                        ld.BackImgOfCardPath = ServerPath + "Documents/" + newFilename + extension;
                                    }
                                    else
                                    {
                                        imagedata.FileType = fi.Extension;
                                        imagedata.ImagePath = ServerPath + "Documents/" + newFilename + extension;
                                    }
                                }
                                else
                                {
                                    response.msg = "Wrong File Format";
                                }
                            }
                        }
                        else
                        {
                            if (imagedata.ImgType == "front")
                            {
                                if (ld.FrontFileStatus == null) { }
                                else
                                {
                                    ld.FrontImgOfCardPath = cid.FrontImgOfCardPath;
                                    ld.FrontImgFileType = cid.FrontImgFileType;
                                    ld.FrontImgFileName = cid.FrontImgFileName;
                                    ld.FrontImgBase64 = cid.FrontImgBase64;
                                }
                                if (ld.FrontImgOfCardPath != "")
                                {
                                    ld.FrontImgOfCardPath = cid.FrontImgOfCardPath;
                                    ld.FrontImgFileType = cid.FrontImgFileType;
                                    ld.FrontImgFileName = cid.FrontImgFileName;
                                    ld.FrontImgBase64 = cid.FrontImgBase64;
                                }
                            }
                            else if (imagedata.ImgType == "back")
                            {
                                if (ld.BackFileStatus == null) { }
                                else
                                {
                                    ld.BackImgBase64 = cid.BackImgBase64;
                                    ld.BackImgFileName = cid.BackImgFileName;
                                    ld.BackImgFileType = cid.BackImgFileType;
                                    ld.BackImgOfCardPath = cid.BackImgOfCardPath;
                                }
                                if (ld.BackImgOfCardPath != "")
                                {
                                    ld.BackImgBase64 = cid.BackImgBase64;
                                    ld.BackImgFileName = cid.BackImgFileName;
                                    ld.BackImgFileType = cid.BackImgFileType;
                                    ld.BackImgOfCardPath = cid.BackImgOfCardPath;
                                }
                            }
                            else { }
                        }
                    }
                    if (response.msg == null)
                    {
                        response = service.UpdateLead(ld);
                    }
                    else
                    {
                        response.n = 0;
                        response.RStatus = "Failed";
                        response.LeadId = "";
                    }
                }
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "UpdateLead" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        
        [HttpPost]
        [Route("api/v1/ChangeLeadStatus")]
        public HttpResponseMessage ChangeLeadStatus(LeadDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.ChangeLeadStatus(ld);
                if (ld.LeadId == null)
                {
                    response.LeadId = "";
                }
                else
                {
                    response.LeadId = ld.LeadId;
                }
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "UpdateLeadStatus" },
                    { "Controller", "LeadDataController" }
                };
                response.LeadId = "";
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("api/v1/AddToFav")]
        public HttpResponseMessage AddToFav(LeadDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.AddToFav(ld);
                if (ld.LeadId == null)
                {
                    response.LeadId = "";
                }
                else
                {
                    response.LeadId = ld.LeadId;
                }
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "UpdateLeadStatus" },
                    { "Controller", "LeadDataController" }
                };
                response.LeadId = "";
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        [Route("api/v1/RemoveLead")]
        public HttpResponseMessage RemoveLead(string LeadId,string UserId)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.RemoveLead(LeadId, UserId);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "RemoveLead" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        [Route("api/v1/RemovePlan")]
        public HttpResponseMessage RemovePlan(int id)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.RemovePlan(id);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "RemovePlan" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        [Route("api/v1/ViewPlanDetails")]
        public HttpResponseMessage ViewPlanDetails(int PlanId)
        {
            PlanDetails ld = new PlanDetails();
            try
            {
                ld = service.ViewPlanDetails(PlanId);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "ViewPlanDetails" },
                    { "Controller", "LeadDataController" }
                };
                rm.response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, ld);
        }
        [HttpPost]
        [Route("api/v1/AddNewPlan")]
        public HttpResponseMessage AddNewPlan(PlanDetails pd)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.AddNewPlan(pd);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "AddNewPlan" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpPost]
        [Route("api/v1/UpdatePlan")]
        public HttpResponseMessage UpdatePlan(PlanDetails pd)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.UpdatePlan(pd);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "UpdatePlan" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        
    }   
}