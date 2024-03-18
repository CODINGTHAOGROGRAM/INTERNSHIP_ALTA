using LMS_Library_API.Models.Notification;

namespace LMS__Elibrary_BE.Services.NotificationSettingServices
{
    public interface INotificationSettingService
    {
        Task<List<NotificationSetting>> GetAllNotificationSettings();
        Task<List<NotificationSetting>> GetNotificationSettingsByUserId(Guid userId);
        Task<NotificationSetting> GetNotificationSettingByUserIdAndFeaturesId(Guid userId, int featuresId);
        Task<string> AddNotificationSetting(NotificationSetting notificationSetting);
        Task<string> UpdateNotificationSetting(NotificationSetting notificationSetting);
        Task<string> DeleteNotificationSetting(Guid userId, int featuresId);
    }
}
