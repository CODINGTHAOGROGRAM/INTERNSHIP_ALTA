using LMS_Library_API.Models.Notification;

namespace LMS__Elibrary_BE.Services.NotificationServices
{
    public interface INotificationService
    {
        Task<List<Notification>> GetAllNotifications();
        Task<List<Notification>> GetNotificationsByRecipientId(Guid recipientId);
        Task<List<Notification>> GetUnreadNotificationsByRecipientId(Guid recipientId);
        Task<string> AddNotification(Notification notification);
        Task<string> MarkNotificationAsRead(int notificationId);
        Task<string> DeleteNotification(int notificationId);
    }
}
