using LMS_DAL;
using LMS_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_BAL
{
    public class RemarkService
    {
        readonly RemarkRepository repository = new RemarkRepository();
        public GetRemarkCount GetRemarkCount(string Lead_Id)
        {
            return repository.GetRemarkCount(Lead_Id);
        }
        public ResponseStatusModel UpdateRemark(RemarkModel rm)
        {
            return repository.UpdateRemark(rm);
        }
        public ResponseStatusModel AddRemark(RemarkModel remarkModel, DataTable dataTable)
        {
            return repository.AddRemark(remarkModel, dataTable);
        }
        public GetUserList GetUserList()
        {
            return repository.GetUserList();
        }
        public GetUserDetails GetUserDetails(string UserId)
        {
            return repository.GetUserDetails(UserId);
        }
        public LeadDetails ViewLead(string Lead_Id)
        {
            return repository.ViewLead(Lead_Id);
        }
        public GetUserListToSendNotificationList GetUserListToSendNotification(string Lead_Id)
        {
            return repository.GetUserListToSendNotification(Lead_Id);
        }
        public RemarkModelList GetRemarksList(string Lead_Id)
        {
            return repository.GetRemarksList(Lead_Id);
        }
        public RemarkModelList GetRecentRemarksList()
        {
            return repository.GetRecentRemarksList();
        }
    }
}
