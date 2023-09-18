using LMS_BAL;
using LMS_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace LeadManagementSystem_API.Security
{
    public class TokenAuth: AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            TokenService Ts = new TokenService();
            bool ValidKey = false;
            IEnumerable<string> requestHeaders;
            var checkApiKeyExists = actionContext.Request.Headers.TryGetValues("authToken", out requestHeaders);
            if (checkApiKeyExists)
            {
                response = Ts.CheckToken(requestHeaders.FirstOrDefault());
                if (response.n == 1)
                    ValidKey = true;
            }
            if (!ValidKey)
            {
                response.msg = "Unauthorized";
                response.n = 401;
                response.RStatus = "Unauthorized";
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                return;
            }
            base.OnAuthorization(actionContext);
        }
    }
}