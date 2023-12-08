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
        public DashboardModel GetLeadsCount()
        {
            return repository.GetLeadsCount();
        }
        public List<LeadDetailsForChart> ShowDatailInLineChart()
        {
            return repository.ShowDatailInLineChart();
        }
        public FavoriteLeads GetFavoriteLeads(string UserId)
        {
            return repository.GetFavoriteLeads(UserId);
        }
        public NumbersOfWeek GetWeekNumbers()
        {
            return repository.GetWeekNumbers();
        }
        public LeadDataByWeek GetLeadDataByWeek(int WeekNumber)
        {
            return repository.GetLeadDataByWeek(WeekNumber);
        }
        public LeadCountsWithAssignee GetLeadCountsWithAssignee()
        {
            return repository.GetLeadCountsWithAssignee();
        }
        public CategoryPriceList GetCategoryPriceByStatus(string StatusType)
        {
            return repository.GetCategoryPriceByStatus(StatusType);
        }
        public DashboardModel GetLeadsPriceByDates(LeadsAmountByDate amountByDate)
        {
            return repository.GetLeadsPriceByDates(amountByDate);
        }
    }
}
