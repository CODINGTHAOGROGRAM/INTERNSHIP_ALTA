using LMS_Library_API.Models.AboutSubject;

namespace LMS__Elibrary_BE.Services.NotificationClassStudentServices
{
    public interface INotificationClassStudentService
    {
        //Task<List<NotificationClassStudent>> GetNotificationsForClass(string classId);
        //Task<string> AddNotificationForClass(NotificationClassStudent notification);
        //Task<string> RemoveNotificationFromClass(int notificationId);
        //Task<NotificationClassStudent> GetNotificationSubjectById(int notificationId);
        //Task<string> UpdateNotification(int notificationId, NotificationClassStudent updatedNotification);
        //Task<List<NotificationClassStudent>> GetNotificationsForStudent(Guid studentId);
        //Task<List<NotificationClassStudent>> GetUnreadNotificationsForStudent(Guid studentId);
        //Task<string> MarkNotificationAsRead(int notificationId);
        //Task<string> MarkAllNotificationsAsReadForStudent(Guid studentId);
        //Task<List<NotificationClassStudent>> GetUnreadNotificationsForClass(string classId);
        //Task<string> DeleteNotificationSubject(int notificationId);
        //Task<string> RemoveNotificationFromStudent(int notificationId, Guid studentId);
        //Task<string> MarkNotificationAsReadForStudent(int notificationId, Guid studentId);

        Task<List<NotificationClassStudent>> GetNotificationsForClass(string classId);
        Task<List<NotificationClassStudent>> GetNotificationsForStudent(Guid studentId);
        Task<List<NotificationClassStudent>> GetNotifications();
        Task<string> AddNotification(NotificationClassStudent notification);
        Task<string> RemoveNotificationFromClass(string classId);
        Task<string> RemoveNotificationFromStudent(Guid studentId);
        Task<string> UpdateNotification( NotificationClassStudent updatedNotification);
    }
}
