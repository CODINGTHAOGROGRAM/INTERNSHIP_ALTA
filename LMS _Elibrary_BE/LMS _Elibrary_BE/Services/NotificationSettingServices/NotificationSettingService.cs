using LMS__Elibrary_BE.Context;
using LMS_Library_API.Models.Notification;
using Microsoft.EntityFrameworkCore;

namespace LMS__Elibrary_BE.Services.NotificationSettingServices
{
    public class NotificationSettingService : INotificationSettingService
    {
        private readonly DataContext _context;
        public NotificationSettingService(DataContext context)
        {
            _context = context;
        }
        public async Task<string> AddNotificationSetting(NotificationSetting notificationSetting)
        {
            try
            {
                _context.NotificationSetting.Add(notificationSetting);
                await _context.SaveChangesAsync();
                return "Thêm thành công";
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện" + ex.Message);
            }
        }

        public async Task<string> DeleteNotificationSetting(Guid userId, int featuresId)
        {
            try
            {
                var findId = await _context.NotificationSetting.FirstOrDefaultAsync(x => x.UserId == userId && x.FeaturesId == featuresId);
                if (findId != null)
                {
                    _context.Remove(findId);
                    await _context.SaveChangesAsync();
                    return "Xóa đối tượng thành công";
                }
                return "Không tìm thấy đối tượng cần xóa";
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện" + ex.Message);

            }
         
        }

        public async Task<List<NotificationSetting>> GetAllNotificationSettings()
        {
            try
            {
                return await _context.NotificationSetting.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện" + ex.Message);

            }
        }

        public async Task<NotificationSetting> GetNotificationSettingByUserIdAndFeaturesId(Guid userId, int featuresId)
        {
            try
            {
                return await _context.NotificationSetting.FirstOrDefaultAsync(x => x.UserId == userId && x.FeaturesId == featuresId);
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện" + ex.Message);

            }
        }

        public async Task<List<NotificationSetting>> GetNotificationSettingsByUserId(Guid userId)
        {
            try
            {
                return await _context.NotificationSetting.Where(x => x.UserId == userId)
                                                         .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện" + ex.Message);

            }
        }

        public async Task<string> UpdateNotificationSetting(NotificationSetting notificationSetting)
        {
            try
            {
                var existingSetting = await _context.NotificationSetting.FindAsync(notificationSetting.UserId, notificationSetting.FeaturesId);
                if (existingSetting == null)
                {
                    return "Không tìm thấy đối tượng";
                }
                existingSetting.UserId = notificationSetting.UserId;
                existingSetting.FeaturesId = notificationSetting.FeaturesId;
                existingSetting.ReceiveNotification = notificationSetting.ReceiveNotification;
                await _context.SaveChangesAsync();
                return "Cập nhật thành công";
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện" + ex.Message);

            }
        }
    }
}
