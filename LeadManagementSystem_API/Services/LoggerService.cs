using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace LeadManagementSystem_API.Services
{
    public static class Logger
    {
        public static void LogEntryToFile(string Message)
        {
            Message = Message + Environment.NewLine + "@ " + DateTime.Now.ToString();

            try
            {
                //string filepath = System.Web.HttpContext.Current.Server.MapPath("~/LogPath/");  //Text File Path
                string filepath = ConfigurationManager.AppSettings["LogPath"];
                if (!System.IO.Directory.Exists(filepath))
                {
                    System.IO.Directory.CreateDirectory(filepath);
                }
                filepath = filepath + DateTime.Today.ToString("dd-MM-yy") + ".txt";   //Text File Name
                if (!System.IO.File.Exists(filepath))
                {
                    System.IO.File.Create(filepath).Dispose();
                }
                using (System.IO.StreamWriter sw = System.IO.File.AppendText(filepath))
                {
                    sw.WriteLine(Environment.NewLine);
                    sw.WriteLine(Message);
                    sw.WriteLine(Environment.NewLine);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    {"action","Logger"},{"controller","LeadManagementSystem_API"}
                };
                ExceptionHandler.ExceptionSave(values, ex);
            }
        }
    }
}