using LMS__Elibrary_BE.Context;
using LMS_Library_API.Models.Notification;
using Microsoft.EntityFrameworkCore;

namespace LMS__Elibrary_BE.Services.NotificationFeaturesServices
{
    public class NotificationFeaturesService : INotificationFeaturesService
    {
        private readonly DataContext _context;
        public NotificationFeaturesService(DataContext context)
        {
            _context = context;
        }
        public async Task<string> AddNotificationFeatures(NotificationFeatures notificationFeatures)
        {
            try
            {
                _context.NotificationFeatures.Add(notificationFeatures);
                await _context.SaveChangesAsync();
                return "Lưu thành công";
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện" + ex.Message);
            }
        }

        public async Task<string> DeleteNotificationFeatures(int featuresId)
        {
            try
            {
                var existing = await _context.NotificationFeatures.FirstOrDefaultAsync(x => x.Id == featuresId);
                if(existing != null)
                {
                    _context.Remove(existing);
                    await _context.SaveChangesAsync();
                    return "Xóa thành công";
                }
                return "Không tìm thấy đối tượng cần xóa";
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện" + ex.Message);
            }
            
        }

        public async Task<List<NotificationFeatures>> GetAllNotificationFeatures()
        {
            try
            {
                return await _context.NotificationFeatures.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện" + ex.Message);
            }
        }

        public async Task<NotificationFeatures> GetNotificationFeaturesById(int featuresId)
        {
            try
            {
                return await _context.NotificationFeatures.FirstOrDefaultAsync(x => x.Id == featuresId);
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện" + ex.Message);
            }
        }

        public async Task<string> UpdateNotificationFeatures(int featuresId, NotificationFeatures updatedNotificationFeatures)
        {
            try
            {
                var ex = await _context.NotificationFeatures.FirstOrDefaultAsync(x => x.Id == featuresId);
                if(ex != null)
                {
                    ex.Id = updatedNotificationFeatures.Id;

                    _context.NotificationFeatures.Update(ex);
                    await _context.SaveChangesAsync();
                    return "Thay đổi thành công";
                }
                return "Không tìm thấy đối tượng cần cập nhật";
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện" + ex.Message);
            }
        }
    }
}
