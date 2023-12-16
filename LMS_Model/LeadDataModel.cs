using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Model
{
    public class LeadModel
    {
        public List<LeadDetails> LeadList
        {
            get; set;
        }
        public ResponseStatusModel Response { get; set; }
    }
    public class LeadDetails
    {
        public Int32 Id { get; set; }
        public Int32 RowNum { get; set; }
        public string ProjectTypeId { get; set; } = "";
        public string CreatedDate { get; set; } = "";
        public string UpdatedBy { get; set; } = "";
        public string CreatedBy { get; set; } = "";
        public string LeadId { get; set; } = "";
        public string CompanyId { get; set; } = "";
        public string CompanyName { get; set; } = "";
        public string ClientName { get; set; } = "";
        public string CategoryId { get; set; } = "";
        public string Category { get; set; } = "";
        public string TypeOfLeadId { get; set; } = "";
        public string TypeOfLead { get; set; } = "";
        public string ProductName { get; set; } = "";
        public string SourceId { get; set; } = "";
        public string Source { get; set; } = "";
        public string Reference { get; set; } = "";
        public string LeadSourceId { get; set; } = "";
        public string LeadSource { get; set; } = "";
        public string SpokesName { get; set; } = "";
        public string SpokesMobileNumber { get; set; } = "";
        public string SpokesEmailAddress { get; set; } = "";
        public string SpokesAddress { get; set; } = "";
        public string AlternateSpokesName { get; set; } = "";
        public string AlternateSpokesMobile { get; set; } = "";
        public string AlternateEmailAddress { get; set; } = "";
        public string AlternateSpokesAddress { get; set; } = "";
        public string PlanId { get; set; } = "";
        public string PlanName { get; set; } = "";
        public string PlanPrice { get; set; } = "";
        public string StatusType { get; set; } = "";
        public string AssignToId { get; set; } = "";
        public string AssignTo { get; set; } = "";
        public string ScheduleDate { get; set; } = "";
        public string ScheduleTime { get; set; } = "";
        public List<TypeOfLeadDetails> TypeOfLeadList { get; set; }
        public string FrontImgOfCardPath { get; set; } = "";
        public string FrontImgFileName { get; set; } = "";
        public string FrontImgBase64 { get; set; } = "";
        public string FrontImgFileType { get; set; } = "";
        public string BackImgOfCardPath { get; set; } = "";
        public string BackImgFileName { get; set; } = "";
        public string BackImgBase64 { get; set; } = "";
        public string BackImgFileType { get; set; } = "";
        public int Active { get; set; } = 0;
        public string ProjectType { get; set; } = "";
        public int IsFinal { get; set; } = 0;
        public string remarkCount { get; set; } = "";
        public string BackFileStatus { get; set; } = "";
        public string FrontFileStatus { get; set; } = "";
        public int IsFav { get; set; }
        public string Short_Company_Name { get; set; } = "";

    }
    public class CardImages
    {
        public string Base64 { get; set; } = "";
        public string Filename { get; set; } = "";
        public string ImagePath { get; set; } = "";
        public string ImgType { get; set; } = "";
        public string FileType { get; set; } = "";
    }
    public class RemarkModelList
    {
        public List<RemarkModel> RemarkModels
        {
            get; set;
        }
        public ResponseStatusModel Response { get; set; }
    }
    public class RemarkModel
    {
        public string CreatedBy
        {
            get; set;
        } = "";
        public string CreatedByName
        {
            get; set;
        } = "";
        public string CreatedDate
        {
            get; set;
        } = "";
        public string CreatedTime
        {
            get; set;
        } = "";
        public string Lead_Id
        {
            get; set;
        } = "";
        public string Remark
        {
            get; set;
        } = "";
        public string Remark_Id
        {
            get; set;
        } = "";
        public string Status
        {
            get; set;
        } = "";
        public string ClientName
        {
            get; set;
        } = "";
        public string RemarkStatus { get; set; }
    }
    public class CardImagesData
    {
        public string FrontImgOfCardPath { get; set; } = "";
        public string FrontImgFileName { get; set; } = "";
        public string FrontImgBase64 { get; set; } = "";
        public string FrontImgFileType { get; set; } = "";
        public string BackImgOfCardPath { get; set; } = "";
        public string BackImgFileName { get; set; } = "";
        public string BackImgBase64 { get; set; } = "";
        public string BackImgFileType { get; set; } = "";
    }
    public class GetLeadUpdatedByOwnerDetailsList
    {
        public List<GetLeadUpdatedByOwnerDetails> GetLeadUpdatedByOwnerDetails
        {
            get; set;
        }
        public ResponseStatusModel Response { get; set; }
    }
    public class GetLeadUpdatedByOwnerDetails
    {
        public string RowNum { get; set; }
        public string LeadId { get; set; }
        public string UpdatedBy { get; set; }
        public string UserName { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedTime { get; set; }
    }
    public class GetUserListToSendNotificationList
    {
        public List<GetUserListToSendNotification> GetUserListToSendNotification
        {
            get; set;
        }
        public ResponseStatusModel Response { get; set; }
    }
    public class GetUserListToSendNotification
    {
        public string UserId { get; set; }
        public string DeviceId { get; set; }
    }
    public class GetUserList
    {
        public List<GetUserDetails> GetUserDetails
        {
            get; set;
        }
        public ResponseStatusModel Response { get; set; }
    }
    public class GetUserDetails
    {
        public string UserID { get; set; }
        public string UserFullName { get; set; }
        public string UserName { get; set; }
        public string DeviceId { get; set; }
    }
    public class GetRemarkCount
    {
        public string TotalRemark { get; set; }
    }
    public class FilterBy
    {
        public string UserId { get;set; }
        public string CompanyId { get; set; } = "";
        public string Priority { get; set; } = "";
        public string CategoryId { get; set; } = "";
        public string AssignedId { get; set; } = "";
    }
    public class PagingParam
    {
        public string UserId { get; set; }
        public string SearchValue { get; set; }
        public int NoOfEntries { get; set; }
        public int PageIndex { get; set; }
        public string SortBy { get; set; }
    }
    public class LeadFilterParameters
    {
        public string UserId { get; set; }
        public List<int> CompanyId { get; set; }
        public List<int> CategoryId { get; set; }
        public List<string> Priority { get; set; }
        public List<int> AssigneeId { get; set; }
        public string SearchValue { get; set; }
    }
    public class ChangeLeadPriority
    {
        public string LeadId { get; set; }
        public string UpdatedBy { get; set; }
        public string Priority { get; set; }
    }
}
