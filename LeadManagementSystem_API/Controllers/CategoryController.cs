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
    public class CategoryController : ApiController
    {
        readonly CategoryService service = new CategoryService();
        ResponseMessageModel rm = new ResponseMessageModel();
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
                    { "Controller", "CategoryController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
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
                    { "Controller", "CategoryController" }
                };
                lcm.Response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, lcm);
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
                    { "Controller", "CategoryController" }
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
                    { "Controller", "CategoryController" }
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
                    { "Controller", "CategoryController" }
                };
                rm.response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, ld);
        }
    }
}