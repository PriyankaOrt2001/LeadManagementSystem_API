using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Model
{
    public class NotificationResponceModel
    {
        public string multicast_id { get; set; }
        public string success { get; set; }
        public string failure { get; set; }
        public string canonical_ids { get; set; }
        public List<results> results { get; set; }
    }
    public class results
    {
        public string error { get; set; }
    }
}
