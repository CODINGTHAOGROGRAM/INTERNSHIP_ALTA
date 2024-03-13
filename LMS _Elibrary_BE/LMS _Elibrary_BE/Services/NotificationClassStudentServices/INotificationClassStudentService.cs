using LMS_Library_API.Models.AboutSubject;

namespace LMS__Elibrary_BE.Services.NotificationClassStudentServices
{
    public interface INotificationClassStudentService
    {
        Task<List<NotificationClassStudent>> GetNotificationsForClass(string classId);
        Task<string> AddNotificationForClass(NotificationClassStudent notification);
        Task<string> RemoveNotificationFromClass(int notificationId);


    }
}
