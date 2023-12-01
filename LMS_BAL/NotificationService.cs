using LMS_DAL;
using LMS_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_BAL
{
    public class NotificationService
    {
        readonly NotificationRepository repository = new NotificationRepository();
        public NotificationDetailsList NotificationDetails(string UserId)
        {
            return repository.NotificationDetails(UserId);
        }
        public NotificationDetailsList RecentNotificationDetails(string UserId)
        {
            return repository.RecentNotificationDetails(UserId);
        }
        public ResponseStatusModel UpdateNotificationSeenStatus(string UserId)
        {
            return repository.UpdateNotificationSeenStatus(UserId);
        }
        public GetCountOfUnSeenNotification GetCountOfUnSeenNotification(string UserId)
        {
            return repository.GetCountOfUnSeenNotification(UserId);
        }
    }
}
