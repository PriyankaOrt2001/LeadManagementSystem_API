﻿using LeadManagementSystem_API.Security;
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
    public class DashboardController : ApiController
    {
        readonly DashboardService service = new DashboardService();
        ResponseMessageModel rm = new ResponseMessageModel();
        [HttpGet]
        [Route("api/v1/GetCountsForDashboard")]
        public HttpResponseMessage GetCountsForDashboard()
        {
            DashboardModel dm = new DashboardModel();
            try
            {
                dm = service.GetLeadsCount();
                dm.LeadList = service.ShowDatailInLineChart();
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "GetCountsForDashboard" },
                    { "Controller", "DashboardController" }
                };
                rm.response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, dm);
        }
        [HttpGet]
        [Route("api/v1/GetLeadsCounts")]
        public HttpResponseMessage GetLeadsCounts()
        {
            DashboardModel dm = new DashboardModel();
            try
            {
                dm = service.GetCountsForDashboard();
                dm.LeadList = service.ShowDatailInLineChart();
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "GetCountsForDashboard" },
                    { "Controller", "DashboardController" }
                };
                rm.response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, dm);
        }
        [HttpGet]
        [Route("api/v1/GetFavoriteLeads")]
        public HttpResponseMessage GetFavoriteLeads(string UserId)
        {
            FavoriteLeads lm = new FavoriteLeads();
            try
            {
                lm = service.GetFavoriteLeads(UserId);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "GetFavoriteLeads" },
                    { "Controller" , "LeadDataController" }
                };
                lm.Response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, lm);
        }
        [HttpGet]
        [Route("api/v1/GetWeekNumbers")]
        public HttpResponseMessage GetWeekNumbers()
        {
            NumbersOfWeek now = new NumbersOfWeek();
            try
            {
                now = service.GetWeekNumbers();
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "NumbersOfWeek" },
                    { "Controller", "DashboardController" }
                };
                rm.response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, now);
        }
        [HttpGet]
        [Route("api/v1/GetLeadDataByWeek")]
        public HttpResponseMessage GetLeadDataByWeek(int WeekNumber)
        {
            LeadDataByWeek ldb = new LeadDataByWeek();
            try
            {
                ldb = service.GetLeadDataByWeek(WeekNumber);
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "GetLeadDataByWeek" },
                    { "Controller", "DashboardController" }
                };
                rm.response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, ldb);
        }
        [HttpGet]
        [Route("api/v1/GetLeadCountsWithAssignee")]
        public HttpResponseMessage GetLeadCountsWithAssignee()
        {
            LeadCountsWithAssignee lcwa = new LeadCountsWithAssignee();
            try
            {
                lcwa = service.GetLeadCountsWithAssignee();
            }
            catch(Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "Action", "GetLeadCountsWithAssignee" },
                    { "Controller", "DashboardController" }
                };
                rm.response = ExceptionHandler.ExceptionSave(values, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, lcwa);
        }
    }
}