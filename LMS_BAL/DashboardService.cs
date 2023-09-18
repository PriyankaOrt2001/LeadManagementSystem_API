using LMS_DAL;
using LMS_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_BAL
{
    public class DashboardService
    {
        readonly DashboardRepository repository = new DashboardRepository();
        public DashboardModel GetCountsForDashboard()
        {
            return repository.GetCountsForDashboard();
        }
        public List<LeadDetailsForChart> ShowDatailInLineChart()
        {
            return repository.ShowDatailInLineChart();
        }
    }
}
