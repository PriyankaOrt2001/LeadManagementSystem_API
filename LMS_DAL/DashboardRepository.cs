using Dapper;
using LMS_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_DAL
{
    public class DashboardRepository
    {
        public DashboardModel GetCountsForDashboard()
        {
            DashboardModel dm = new DashboardModel();
            string sql = "[SP_DashBoardCount]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {

                }, commandType: CommandType.StoredProcedure);
                dm= multi.Read<DashboardModel>().FirstOrDefault();
            }
            return dm;
        }
        public DashboardModel GetLeadsCount()
        {
            DashboardModel dm = new DashboardModel();
            string sql = "[SP_DashBoardCount]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {

                }, commandType: CommandType.StoredProcedure);
                dm = multi.Read<DashboardModel>().FirstOrDefault();
            }
            return dm;
        }
        public List<LeadDetailsForChart> ShowDatailInLineChart()
        {
            List<LeadDetailsForChart> dm = new List<LeadDetailsForChart>();
            string sql = "[SP_ShowDatailInLineChart]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {

                }, commandType: CommandType.StoredProcedure);
                dm = multi.Read<LeadDetailsForChart>().ToList();
            }
            return dm;
        }
        public FavoriteLeads GetFavoriteLeads(string UserId)
        {
            FavoriteLeads lm = new FavoriteLeads();
            string sql = "[SP_GetFavoriteLeads]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    UserId = UserId
                }, commandType: CommandType.StoredProcedure);
                lm.FavoriteLeadsDetails = multi.Read<FavoriteLeadsDetails>().ToList();
                lm.Response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return lm;
        }
        public NumbersOfWeek GetWeekNumbers()
        {
            NumbersOfWeek now = new NumbersOfWeek();
            string sql = "[SP_GetWeekNumbers]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                   
                }, commandType: CommandType.StoredProcedure);
                now.NumberOfWeek = multi.Read<NumberOfWeek>().ToList();
                now.Response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return now;
        }
        public LeadDataByWeek GetLeadDataByWeek(int WeekNumber)
        {
            LeadDataByWeek ldb = new LeadDataByWeek();
            string storedProcedure = "[SP_GetLeadDataByDate]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(storedProcedure, new
                {
                    WeekNumber= WeekNumber
                }, commandType: CommandType.StoredProcedure);
                ldb.LeadDetailsByWeek = multi.Read<LeadDetailsByWeek>().ToList();
                ldb.Response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return ldb;
        }
        public LeadCountsWithAssignee GetLeadCountsWithAssignee()
        {
            LeadCountsWithAssignee counts = new LeadCountsWithAssignee();
            string storedProcedure = "[SP_GetLeadCountsWithAssignee]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(storedProcedure, new
                {

                }, commandType: CommandType.StoredProcedure);
                counts.LeadCounts = multi.Read<LeadCounts>().ToList();
                counts.Response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return counts;
        }
        public CategoryPriceList GetCategoryPriceByStatus(string StatusType)
        {
            CategoryPriceList cp = new CategoryPriceList();
            string storedProcedure = "[SP_GetPriceOfCategoryByStatus]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(storedProcedure, new
                {
                    StatusType = StatusType
                }, commandType: CommandType.StoredProcedure);
                cp = multi.Read<CategoryPriceList>().SingleOrDefault();
            }
            return cp;
        }
        public DashboardModel GetLeadsPriceByDates(LeadsAmountByDate amountByDate)
        {
            DashboardModel dm = new DashboardModel();
            string sql = "[SP_GetLeadsPriceByDates]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    FromDate=amountByDate.FromDate,
                    ToDate=amountByDate.ToDate
                }, commandType: CommandType.StoredProcedure);
                dm = multi.Read<DashboardModel>().FirstOrDefault();
                dm.Response = multi.Read<ResponseStatusModel>().FirstOrDefault();
            }
            return dm;
        }
    }
}
