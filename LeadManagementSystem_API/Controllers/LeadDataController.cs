
using LeadManagementSystem_API.Security;
using LeadManagementSystem_API.Services;
using LMS_BAL;
using LMS_Model;
using System;
using System.Collections.Generic;
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
    [TokenAuth]
    public class LeadDataController : ApiController
    {
        readonly LeadDataService service = new LeadDataService();
        ResponseMessageModel rm = new ResponseMessageModel();


        [HttpGet]
        [Route("api/v1/notificationsend")]
        public HttpResponseMessage notificationsend(Notification notification)
        {
            string SERVER_KEY_TOKEN = "BHRp5rPa85ZpngKNOxdnfKMdt_1Sp0hF1SM-33_aGo-4NXSFsZdwerDHrwkzsJlj3AsnwZZi67Oqrpduo5uLAwM";
            var SENDER_ID = "499601684467";
            var deviceId = "b6cd33d4fabd0703";
            WebRequest tRequest;
            tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "post";
            tRequest.ContentType = " application/json";

            tRequest.Headers.Add(string.Format("Authorization: key={0}", SERVER_KEY_TOKEN));
            tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));

            var a = new
            {
                notification = new
                {
                    notification.title,
                    notification.text,
                    icon = "https://domain/path/to/logo.png",
                    sound = "mySound"
                },
                to = deviceId
            };

            byte[] byteArray = Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(a));
            tRequest.ContentLength = byteArray.Length;

            Stream dataStream = tRequest.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse tResponse = tRequest.GetResponse();
            dataStream = tResponse.GetResponseStream();

            StreamReader tReader = new StreamReader(dataStream);
            string sResponseFromServer = tReader.ReadToEnd();

            tReader.Close();
            dataStream.Close();
            tResponse.Close();

            //return sResponseFromServer;
            return Request.CreateResponse(HttpStatusCode.OK, notification);
        }

        [HttpGet]
        [Route("api/v1/pushnotification")]
        public HttpResponseMessage sendnotification(Notification obj)
        {
            try
            {
                var applicationID = "BHRp5rPa85ZpngKNOxdnfKMdt_1Sp0hF1SM-33_aGo-4NXSFsZdwerDHrwkzsJlj3AsnwZZi67Oqrpduo5uLAwM";

                var senderId = "499601684467";

                string deviceId = "euxqdp------ioIdL87abVL";

                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");

                tRequest.Method = "post";

                tRequest.ContentType = "application/json";

                var data = new

                {

                    to = deviceId,

                    notification = new

                    {

                        body = obj.text,

                        title = obj.title,

                        icon = "myicon"

                    }
                };

                var serializer = new JavaScriptSerializer();

                var json = serializer.Serialize(data);

                Byte[] byteArray = Encoding.UTF8.GetBytes(json);

                tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));

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

                                String sResponseFromServer = tReader.ReadToEnd();

                                string str = sResponseFromServer;

                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {

                string str = ex.Message;

            }
            return Request.CreateResponse(HttpStatusCode.OK, obj);
        }


        [HttpGet]
        [Route("api/v1/GetCompanyList")]
        public HttpResponseMessage GetCompanyList()
        {
            CompanyModel cm = new CompanyModel();
            try
            {
                cm = service.GetCompanyList();
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "GeCompanyList" },
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
                    { "Controller", "LeadDataController" }
                };
                am.Response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, am);
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
        [HttpGet]
        [Route("api/v1/GetLeadCategoryList")]
        public HttpResponseMessage GetLeadCategoryList()
        {
            LeadCategoryModel lcm = new LeadCategoryModel();
            try
            {
                lcm = service.GetLeadCategoryList();
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "GetLeadCategoryList" },
                    { "Controller", "LeadDataController" }
                };
                lcm.Response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, lcm);
        }
        [HttpGet]
        [Route("api/v1/GetLeadTypesList")]
        public HttpResponseMessage GetLeadTypesList()
        {
            TypeOfLeadModel lcm = new TypeOfLeadModel();
            try
            {
                lcm = service.GetLeadTypesList();
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "GetLeadTypesList" },
                    { "Controller", "LeadDataController" }
                };
                lcm.Response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, lcm);
        }
        [HttpGet]
        [Route("api/v1/GetTypeOfLeadList")]
        public HttpResponseMessage GetTypeOfLeadList(int Category_Id)
        {
            TypeOfLeadModel tolm = new TypeOfLeadModel();
            try
            {
                tolm = service.GetTypeOfLeadList(Category_Id);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "GetTypeOfLeadList" },
                    { "Controller", "LeadDataController" }
                };
                tolm.Response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, tolm);
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
        public HttpResponseMessage GetLeadDetailsList()
        {
            LeadModel lm = new LeadModel();
            CardImagesData cid = new CardImagesData();
            try
            {
                lm = service.GetLeadDetailsList();
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
                    response = service.AddLead(ld);
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
                            string[] extensions = { ".jpg", ".jpeg", ".png" };
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
                                if ((fileclass == "255216" && extension == ".jpg") || (fileclass == "13780" && extension == ".png"))
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
                    response = service.AddLead(ld);

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
        [HttpPost]
        [Route("api/v1/AddLeadSource")]
        public HttpResponseMessage AddLeadSource(LeadSourceDetails lcd)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.AddNewLeadSource(lcd);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "AddNewLeadSource" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpPost]
        [Route("api/v1/AddNewEmployee")]
        public HttpResponseMessage AddNewEmployee(AssignToDetails lcd)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.AddNewEmployee(lcd);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "AddNewEmployee" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpPost]
        [Route("api/v1/AddCategory")]
        public HttpResponseMessage AddCategory(LeadCategoryDetails lcd)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.AddCategory(lcd);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "AddCategory" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpPost]
        [Route("api/v1/AddNewComapny")]
        public HttpResponseMessage AddNewComapny(CompanyDetails lcd)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.AddNewComapny(lcd);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "AddNewComapny" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpPost]
        [Route("api/v1/AddTypeOfLead")]
        public HttpResponseMessage AddTypeOfLead(TypeOfLeadDetails tol)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.AddTypeOfLead(tol);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "AddTypeOfLead" },
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
        [Route("api/v1/UpdateDraftLead")]
        public HttpResponseMessage UpdateDraftLead(LeadDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.UpdateDraftLead(ld);

            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "UpdateDraftLead" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
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
        [Route("api/v1/UpdateFinalDraftLead")]
        public HttpResponseMessage UpdateFinalDraftLead(LeadDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.UpdateFinalDraftLead(ld);

            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "UpdateFinalDraftLead" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("api/v1/UpdateFirstDraftLead")]
        public HttpResponseMessage UpdateFirstDraftLead(LeadDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                CardImagesData cid = new CardImagesData();
                cid = service.GetImageList(ld.LeadId);

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
                    response = service.UpdateFirstDraftLead(ld);
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
                            string[] extensions = { ".jpg", ".jpeg", ".png" };
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
                                if ((fileclass == "255216" && extension == ".jpg") || (fileclass == "13780" && extension == ".png"))
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

                            }
                            else { }
                        }
                    }

                    response = service.UpdateFirstDraftLead(ld);
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
        [Route("api/v1/UpdateLead")]
        public HttpResponseMessage UpdateLead(LeadDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                CardImagesData cid = new CardImagesData();
                cid = service.GetImageList(ld.LeadId);

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
                            string[] extensions = { ".jpg", ".jpeg", ".png" };
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
                                if ((fileclass == "255216" && extension == ".jpg") || (fileclass == "13780" && extension == ".png"))
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

                    response = service.UpdateLead(ld);
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
        [Route("api/v1/AddRemark")]
        public HttpResponseMessage AddRemark(RemarkModel remarkModel)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.AddRemark(remarkModel);
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
        [Route("api/v1/RemoveEmployee")]
        public HttpResponseMessage RemoveEmployee(int id)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.RemoveEmployee(id);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "RemoveEmployee" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        [Route("api/v1/RemoveCompany")]
        public HttpResponseMessage RemoveCompany(int id)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.RemoveComapny(id);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "RemoveCompany" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        [Route("api/v1/RemoveCategory")]
        public HttpResponseMessage RemoveCategory(int id)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.RemoveCategory(id);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "RemoveCategory" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        [Route("api/v1/RemoveLeadSource")]
        public HttpResponseMessage RemoveLeadSource(int id)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.RemoveLeadSource(id);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "RemoveLeadSource" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        [Route("api/v1/RemoveTypeOfLead")]
        public HttpResponseMessage RemoveTypeOfLead(int id)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.RemoveTypeOfLead(id);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "RemoveTypeOfLead" },
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
        [Route("api/v1/ViewCategoryDetails")]
        public HttpResponseMessage ViewCategoryDetails(int Category_Id)
        {
            LeadCategoryDetails ld = new LeadCategoryDetails();
            try
            {
                ld = service.ViewCategoryDetails(Category_Id);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "ViewCategoryDetails" },
                    { "Controller", "LeadDataController" }
                };
                rm.response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, ld);
        }
        [HttpGet]
        [Route("api/v1/ViewTypeOfLeadDetails")]
        public HttpResponseMessage ViewTypeOfLeadDetails(int TypeOfLead_ID)
        {
            TypeOfLeadDetails ld = new TypeOfLeadDetails();
            try
            {
                ld = service.ViewTypeOfLeadDetails(TypeOfLead_ID);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "ViewTypeOfLeadDetails" },
                    { "Controller", "LeadDataController" }
                };
                rm.response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, ld);
        }
        [HttpGet]
        [Route("api/v1/ViewCompanyDetails")]
        public HttpResponseMessage ViewCompanyDetails(int Company_Id)
        {
            CompanyDetails ld = new CompanyDetails();
            try
            {
                ld = service.ViewCompanyDetails(Company_Id);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "ViewCompanyDetails" },
                    { "Controller", "LeadDataController" }
                };
                rm.response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, ld);
        }
        [HttpGet]
        [Route("api/v1/ViewAssignToDetails")]
        public HttpResponseMessage ViewAssignToDetails(int Employee_Id)
        {
            AssignToDetails ld = new AssignToDetails();
            try
            {
                ld = service.ViewAssignToDetails(Employee_Id);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "ViewAssignToDetails" },
                    { "Controller", "LeadDataController" }
                };
                rm.response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, ld);
        }
        [HttpGet]
        [Route("api/v1/ViewLeadSource")]
        public HttpResponseMessage ViewLeadSource(int SourceId)
        {
            LeadSourceDetails ld = new LeadSourceDetails();
            try
            {
                ld = service.ViewLeadSource(SourceId);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "ViewLeadSource" },
                    { "Controller", "LeadDataController" }
                };
                rm.response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, ld);
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
        [Route("api/v1/UpdateCompany")]
        public HttpResponseMessage UpdateCompany(CompanyDetails cmm)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.UpdateCompany(cmm);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "UpdateCompany" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpPost]
        [Route("api/v1/UpdateCategory")]
        public HttpResponseMessage UpdateCategory(LeadCategoryDetails cd)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.UpdateCategory(cd);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "UpdateCategory" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpPost]
        [Route("api/v1/UpdateTypeOfLead")]
        public HttpResponseMessage UpdateTypeOfLead(TypeOfLeadDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.UpdateTypeOfLead(ld);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "UpdateTypeOfLead" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpPost]
        [Route("api/v1/UpdateEmployee")]
        public HttpResponseMessage UpdateEmployee(AssignToDetails atd)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.UpdateEmployee(atd);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "UpdateEmployee" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpPost]
        [Route("api/v1/UpdateLeadSource")]
        public HttpResponseMessage UpdateLeadSource(LeadSourceDetails sd)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.UpdateLeadSource(sd);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "UpdateLeadSource" },
                    { "Controller", "LeadDataController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
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