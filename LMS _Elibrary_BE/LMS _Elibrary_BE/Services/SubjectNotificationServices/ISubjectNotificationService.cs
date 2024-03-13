using LMS_Library_API.Models.AboutSubject;

namespace LMS__Elibrary_BE.Services.SubjectNotificationServices
{
    public interface ISubjectNotificationService
    {
        Task<List<SubjectNotification>> GetNotificationsForSubject(string subjectId);
        Task<string> AddNotificationForSubject(SubjectNotification notification);
        Task<string> UpdateNotificationForSubject(int notificationId, SubjectNotification updatedNotification);
        Task<string> RemoveNotificationFromSubject(int notificationId);


    }
}
