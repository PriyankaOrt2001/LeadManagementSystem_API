using LMS_BAL;
using LMS_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeadManagementSystem_API.Services
{
    public class ExceptionHandler
    {
        public static ResponseStatusModel ExceptionSave(IDictionary<string, object> CB, Exception ex)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            ExceptionModel em = new ExceptionModel();
            ExceptionHandlerSevice es = new ExceptionHandlerSevice();
            em.Etype = ex.GetType().ToString();
            em.Ipaddr = "";
            em.Emsg = Convert.ToString(ex.Message) + "||InnerException=" + Convert.ToString(ex.InnerException) + "||StackTrace=" + Convert.ToString(ex.StackTrace) + "||HelpLink=" + Convert.ToString(ex.HelpLink) + "||HResult=" + Convert.ToString(ex.HResult);
            if (CB.ContainsKey("action"))
            {
                em.Actionname = CB["action"].ToString();
            }
            if (CB.ContainsKey("controller"))
            {
                em.Controllername = CB["controller"].ToString();
            }
            em.Esource = "API Controller";
            es.SaveException(em);
            response.msg = "An Exception Occured Please Try Agian later.";
            response.n = 0;
            response.RStatus = "Failed";
            return response;
        }
    }
}