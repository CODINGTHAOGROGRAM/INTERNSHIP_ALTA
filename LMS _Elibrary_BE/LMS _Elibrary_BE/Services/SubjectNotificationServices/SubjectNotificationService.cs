using LMS__Elibrary_BE.Context;
using LMS_Library_API.Models.AboutSubject;
using Microsoft.EntityFrameworkCore;

namespace LMS__Elibrary_BE.Services.SubjectNotificationServices
{
    public class SubjectNotificationService : ISubjectNotificationService
    {
        private readonly DataContext _context;
        public SubjectNotificationService(DataContext context)
        {
            _context = context;
        }

        public async Task<string> AddNotification(SubjectNotification notification)
        {
            try
            {
                _context.SubjectNotifications.Add(notification);
                await _context.SaveChangesAsync();
                return "Thêm thành công";
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện" + ex.Message);
            }
        }

        public async Task<List<SubjectNotification>> GetNotifications()
        {
            try
            {
                return await _context.SubjectNotifications.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi truy vấn danh sách" + ex.Message);
            }
        }

        public async Task<SubjectNotification> GetNotificationsById(int notificationId)
        {
            try
            {
                return await _context.SubjectNotifications.FirstOrDefaultAsync(x => x.Id == notificationId);
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi truy vấn" + ex.Message);
            }
        }

        public async Task<List<SubjectNotification>> GetNotificationsForSubject(string subjectId)
        {
            try
            {
                return await _context.SubjectNotifications.Where(x => x.subjectId == subjectId)
                                                          .ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi truy vấn danh sách" + ex.Message);
            }
        }

        public async Task<List<SubjectNotification>> GetNotificationsForTeacher(Guid teacherId)
        {
            try
            {
                return await _context.SubjectNotifications.Where(x => x.teacherId == teacherId)
                                                          .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy vấn danh sách" + ex.Message);
            }
        }

        public async Task<string> RemoveNotification(int notificationId)
        {
            try
            {
                var existting = await _context.SubjectNotifications.FirstOrDefaultAsync(x => x.Id == notificationId);
                if(existting == null)
                {
                    return "Không tìm thấy đối tượng cần xóa";
                }
                _context.Remove(existting);
                await _context.SaveChangesAsync();
                return "Xóa thành công";
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi truy cập danh sách");
            }
        }

        public async Task<string> UpdateNotification(SubjectNotification updatedNotification)
        {
            try
            {
                var ex = await _context.SubjectNotifications.FindAsync(updatedNotification.Id);
                if(ex == null)
                {
                    return "Không tìm thấy đối tượng cần cập nhật";
                }
                ex.Id = updatedNotification.Id;
                ex.title = updatedNotification.title;
                ex.content = updatedNotification.content;
                ex.CreatedDate = updatedNotification.CreatedDate;
                await _context.SaveChangesAsync();
                return "Thay đổi thành công";
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi truy cập" + ex.Message);
            }
        }
    }
}
