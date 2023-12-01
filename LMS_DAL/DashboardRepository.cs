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
            }
            return lm;
        }
    }
}
