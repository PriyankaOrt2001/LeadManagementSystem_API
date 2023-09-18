using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Model
{
    public class ResponseMessageModel
    {
        public int Invoice_ID { get; set; }
        public int n { get; set; }
        public String RStatus { get; set; }
        public string msg { get; set; }
        public string isparam1 { get; set; }
        public string isparam2 { get; set; }
        public string isparam3 { get; set; }
        public string isparam4 { get; set; }
        public string isparam5 { get; set; }
        public int iparam1 { get; set; }
        public int iparam2 { get; set; }
        public decimal idparam1 { get; set; }
        public long ilparam1 { get; set; }
        public long ilparam2 { get; set; }
        public string AuthToken { get; set; }
        public int IsVerified { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public String CartItemsRightDIv { get; set; }
        public String CartTotalRightDIv { get; set; }
        public string MenuId { get; set; }
        public string AmtRecv { get; set; }
        public string AmtToRecv { get; set; }
        //public decimal AmtRecv { get; set; }
        //public decimal AmtToRecv { get; set; }
        public int iparam3 { get; set; }
        public int iparam4 { get; set; }
        public ResponseStatusModel response { get; set; }
    }
}
