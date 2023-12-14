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
        public string CountOfOpenLeads
        {
            get; set;
        }
        public string CountOfGhostLeads
        {
            get; set;
        }
        public string CountOfConvertedLeads
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
    public class NumbersOfWeek
    {
        public List<NumberOfWeek> NumberOfWeek
        {
            get; set;
        }
        public ResponseStatusModel Response { get; set; }
    }
    public class NumberOfWeek
    {
        public string Week { get; set; }
        public int WeekNumber { get; set; }
    }
    public class LeadDataByWeek
    {
        public List<LeadDetailsByWeek> LeadDetailsByWeek
        {
            get; set;
        }
        public ResponseStatusModel Response { get; set; }
    }
    public class LeadDetailsByWeek
    {
        public string DateOfWeek { get; set; }
        public int HotLeadsCount { get; set; }
        public int ColdLeadsCount { get; set; }
        public int WarmLeadsCount { get; set; }
    }
    public class LeadCountsWithAssignee
    {
        public List<LeadCounts> LeadCounts
        {
            get; set;
        }
        public ResponseStatusModel Response { get; set; }
    }
    public class LeadCounts
    {
        public string AssigneeName { get; set; }
        public string AssigneeId { get; set; }
        public int TotalAllocatedLeads { get; set; }
        public int ClosedLeadsCount { get; set; }
        public int GhostLeadsCount { get; set; }
        public int ConvertedLeadsCount { get; set; }
        public int HoldLeadsCount { get; set; }
        public int OpenLeadsCount { get; set; }
    }
    public class CategoryPrice
    {
        public List<CategoryPriceList> CategoryPriceList
        {
            get; set;
        }
        public ResponseStatusModel Response { get; set; }
    }
    public class CategoryPriceList
    {
        public int HotLeadsAmount { get; set; }
        public int ColdLeadsAmount { get; set; }
        public int WarmLeadsAmount { get; set; }
        public int GhostLeadsAmount { get; set; }
    }
    public class LeadsAmountByDate
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string StatusType { get; set; }
    }
}
