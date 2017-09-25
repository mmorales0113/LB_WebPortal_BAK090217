using Abp.Notifications;
using WebPortal.Dto;

namespace WebPortal.Notifications.Dto
{
    public class GetUserNotificationsInput : PagedInputDto
    {
        public UserNotificationState? State { get; set; }
    }
}