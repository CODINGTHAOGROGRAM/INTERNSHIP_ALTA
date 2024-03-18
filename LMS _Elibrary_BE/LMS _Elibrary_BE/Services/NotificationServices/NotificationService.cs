using LMS__Elibrary_BE.Context;
using LMS_Library_API.Models.Notification;
using Microsoft.EntityFrameworkCore;

namespace LMS__Elibrary_BE.Services.NotificationServices
{
    public class NotificationService : INotificationService
    {
        private readonly DataContext _context;
        public NotificationService(DataContext context)
        {
            _context = context;
        }

        public async Task<string> AddNotification(Notification notification)
        {
            try
            {
                _context.Notifications.Add(notification);
                await _context.SaveChangesAsync();
                return "Thêm thành công";
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện" + ex.Message);
            }
        }

        public async Task<string> DeleteNotification(int notificationId)
        {
            try
            {
                var existing = await _context.Notifications.FirstOrDefaultAsync(x => x.Id == notificationId);
                if (existing != null)
                {
                    _context.Notifications.Remove(existing);
                    await _context.SaveChangesAsync();
                    return "Xóa thành công";
                }
                return "Không tìm thấy đối tượng cần xóa";
            }catch(Exception ex)
            {
                throw new Exception("Lỗi khi thêm" + ex.Message);
            }
        }


        public async Task<List<Notification>> GetAllNotifications()
        {
            try
            {
                return await _context.Notifications.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi thêm" + ex.Message);
            }
        }

        public async Task<List<Notification>> GetNotificationsByRecipientId(Guid recipientId)
        {
            try
            {
                return await _context.Notifications.Where(n => n.RecipientId == recipientId)
                                                   .ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi thêm" + ex.Message);
            }
        }

        public async Task<List<Notification>> GetUnreadNotificationsByRecipientId(Guid recipientId)
        {
            try
            {
                return await _context.Notifications.Where(n => n.RecipientId == recipientId && !n.IsRead)
                                                   .ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi thêm" + ex.Message);
            }
        }

        public async Task<string> MarkNotificationAsRead(int notificationId)
        {
            try
            {
                var notification = await _context.Notifications.FindAsync(notificationId);
                if (notification != null)
                {
                    notification.IsRead = true;
                    await _context.SaveChangesAsync();
                    return "Thông báo đã được đọc";
                }
                return "Không tìm thấy đối tượng";
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện" + ex.Message); 
            }
        }
    }
}
