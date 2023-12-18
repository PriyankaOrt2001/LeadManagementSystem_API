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
    public class TypeOfLeadController : ApiController
    {
        readonly TypeOfLeadService service = new TypeOfLeadService();
        ResponseMessageModel rm = new ResponseMessageModel();

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
                    { "Controller", "TypeOfLeadController" }
                };
                tolm.Response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, tolm);
        }

        [HttpGet]
        [Route("api/v1/GetSubCategoryList")]
        public HttpResponseMessage GetSubCategoryList(int Category_Id)
        {
            SubCategoryModel tolm = new SubCategoryModel();
            try
            {
                tolm = service.GetSubCategoryList(Category_Id);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "GetSubCategoryList" },
                    { "Controller", "TypeOfLeadController" }
                };
                tolm.Response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, tolm);
        }
        [HttpPost]
        [Route("api/v1/AddSubCategory")]
        public HttpResponseMessage AddSubCategory(SubCategoryDetails tol)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.AddSubCategory(tol);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "AddSubCategory" },
                    { "Controller", "TypeOfLeadController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        [Route("api/v1/RemoveSubCategory")]
        public HttpResponseMessage RemoveSubCategory(int id)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.RemoveSubCategory(id);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "RemoveSubCategory" },
                    { "Controller", "TypeOfLeadController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        [Route("api/v1/ViewSubCategoryDetails")]
        public HttpResponseMessage ViewSubCategoryDetails(int SubCategory_ID)
        {
            SubCategoryDetails ld = new SubCategoryDetails();
            try
            {
                ld = service.ViewSubCategoryDetails(SubCategory_ID);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "ViewSubCategoryDetails" },
                    { "Controller", "TypeOfLeadController" }
                };
                rm.response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, ld);
        }

        [HttpPost]
        [Route("api/v1/UpdateSubCategory")]
        public HttpResponseMessage UpdateSubCategory(SubCategoryDetails ld)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            try
            {
                response = service.UpdateSubCategory(ld);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "UpdateSubCategory" },
                    { "Controller", "TypeOfLeadController" }
                };
                response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        [Route("api/v1/GetSubCategoryList")]
        public HttpResponseMessage GetSubCategoryList()
        {
            SubCategoryModel lcm = new SubCategoryModel();
            try
            {
                lcm = service.GetSubCategoryList();
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "GetLeadTypesList" },
                    { "Controller", "SubCategoryController" }
                };
                lcm.Response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, lcm);
        }
    }
}