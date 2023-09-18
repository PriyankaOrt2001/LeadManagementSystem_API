using LMS_DAL;
using LMS_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_BAL
{
    public class TokenService
    {
        TokenRepository tr = new TokenRepository();

        public ResponseStatusModel CheckToken(string Token)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            if (!string.IsNullOrEmpty(Token))
                response = tr.CheckToken(Token);
            else
            {
                response.msg = "Unauthorized";
                response.n = 0;
                response.RStatus = "Unauthorized";
            }
            return response;
        }
    }
}
