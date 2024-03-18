using LMS_Library_API.Models.Notification;

namespace LMS__Elibrary_BE.Services.NotificationFeaturesServices
{
    public interface INotificationFeaturesService
    {
        Task<List<NotificationFeatures>> GetAllNotificationFeatures();
        Task<NotificationFeatures> GetNotificationFeaturesById(int featuresId);
        Task<string> AddNotificationFeatures(NotificationFeatures notificationFeatures);
        Task<string> UpdateNotificationFeatures(int featuresId, NotificationFeatures updatedNotificationFeatures);
        Task<string> DeleteNotificationFeatures(int featuresId);
    }
}
