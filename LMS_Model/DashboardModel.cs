using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Model
{
    public class DashboardModel
    {
        public string TotalLeads
        {
            get;set;
        }
        public string OpenLeadsCount
        {
            get;set;
        }
        public string ClosedLeadsCount
        {
            get; set;
        }
        public string HoldLeadsCount
        {
            get;set;
        }
        public string ConvertedLeadsCount
        {
            get; set;
        }
        public string GhostLeadsCount
        {
            get; set;
        }
        public string PriceOfTotalLeads
        {
            get; set;
        }
        public string PriceOfOpenLeads
        {
            get; set;
        }
        public string PriceOfClosedLeads
        {
            get; set;
        }
        public string PriceOfHoldLeads
        {
            get; set;
        }
        public string PriceOfConvertedLeads
        {
            get; set;
        }
        public string PriceOfGhostLeads
        {
            get; set;
        }
        public List<LeadDetailsForChart> LeadList
        {
            get; set;
        }
        public ResponseStatusModel Response { get; set; }
    }
    public class LeadDetailsForChart
    {
        public string MonthName
        {
            get;set;
        }
        public string CountOfTotalLeads
        { 
            get; set; 
        }
        public string CountOfClosedLeads
        {
            get;set;
        }
        public string CountOfHoldLeads
        {
            get; set;
        }
    }
    public class LeadsCountModel
    {
        public string TotalLeads
        {
            get; set;
        }
        public string OpenLeadsCount
        {
            get; set;
        }
        public string ClosedLeadsCount
        {
            get; set;
        }
        public string HoldLeadsCount
        {
            get; set;
        }
        public string ConvertedLeadsCount
        {
            get; set;
        }
        public string GhostLeadsCount
        {
            get; set;
        }
        public string PriceOfTotalLeads
        {
            get; set;
        }
        public string PriceOfOpenLeads
        {
            get; set;
        }
        public string PriceOfClosedLeads
        {
            get; set;
        }
        public string PriceOfHoldLeads
        {
            get; set;
        }
        public string PriceOfConvertedLeads
        {
            get; set;
        }
        public string PriceOfGhostLeads
        {
            get; set;
        }
        public ResponseStatusModel Response { get; set; }
    }
    public class FavoriteLeads
    {
        public List<FavoriteLeadsDetails> FavoriteLeadsDetails
        {
            get; set;
        }
        public ResponseStatusModel Response { get; set; }
    }
    public class FavoriteLeadsDetails
    {
        public Int32 Id { get; set; }
        public Int32 RowNum { get; set; }
        public string CreatedDate { get; set; } = "";
        public string CreatedBy { get; set; } = "";
        public string LeadId { get; set; } = "";
        public string CompanyName { get; set; } = "";
        public string ClientName { get; set; } = "";
        public string Category { get; set; } = "";
        public string TypeOfLead { get; set; } = "";
        public string ProductName { get; set; } = "";
        public string Source { get; set; } = "";
        public string LeadSource { get; set; } = "";
        public string StatusType { get; set; } = "";
        public string AssignTo { get; set; } = "";
        public string ProjectType { get; set; } = "";
        public int IsFav { get; set; }
        public string ShortCompanyName { get; set; } = "";
    }
}
