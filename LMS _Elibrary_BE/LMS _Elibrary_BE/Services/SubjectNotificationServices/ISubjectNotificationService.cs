using LMS_Library_API.Models.AboutSubject;

namespace LMS__Elibrary_BE.Services.SubjectNotificationServices
{
    public interface ISubjectNotificationService
    {
        Task<List<SubjectNotification>> GetNotificationsForSubject(string subjectId);
        Task<List<SubjectNotification>> GetNotificationsForTeacher(Guid teacherId);
        Task<List<SubjectNotification>> GetNotifications();
        Task<SubjectNotification> GetNotificationsById(int notificationId);
        Task<string> AddNotification(SubjectNotification notification);
        Task<string> UpdateNotification( SubjectNotification updatedNotification);
        Task<string> RemoveNotification(int notificationId);
    }
}
