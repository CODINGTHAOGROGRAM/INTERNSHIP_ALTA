using LMS__Elibrary_BE.Context;
using LMS_Library_API.Models;
using LMS_Library_API.Models.AboutSubject;
using LMS_Library_API.Models.Notification;
using Microsoft.EntityFrameworkCore;

namespace LMS__Elibrary_BE.Services.NotificationClassStudentServices
{
    public class NotificationCLassStudentService : INotificationClassStudentService
    {
        private readonly DataContext _context;
        public NotificationCLassStudentService(DataContext context)
        {
            _context = context;
        }
        public async Task<string> AddNotification(NotificationClassStudent notification)
        {
            try
            {
                _context.NotificationClassStudents.Add(notification);
                await _context.SaveChangesAsync();
                return "Thêm thông báo lớp học thành công";
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện thêm" + ex.Message);
            }
        }

        public async Task<List<NotificationClassStudent>> GetNotificationsForClass(string classId)
        {
            try
            {
                return await _context.NotificationClassStudents.Where(x => x.classId == classId)
                                                               .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy xuất danh sách" + ex.Message);
            }
        }

        public async Task<List<NotificationClassStudent>> GetNotifications()
        {
            try
            {
                return await _context.NotificationClassStudents.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi truy vấn danh sách" + ex.Message);
            }
        }
        public async Task<List<NotificationClassStudent>> GetNotificationsForStudent(Guid studentId)
        {
            try
            {
                return await _context.NotificationClassStudents.Where(x => x.studentId == studentId)
                                                               .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy xuất danh sách" + ex.Message);
            }
        }

        public async Task<string> RemoveNotificationFromClass(string classId)
        {
            try
            {
                var exist = await _context.NotificationClassStudents.FirstOrDefaultAsync(x =>x.classId == classId);
                if(exist != null)
                {
                    _context.Remove(exist);
                    await _context.SaveChangesAsync();
                    return "Xóa thành công";
                }
                return "Không tìm thấy thông báo cần xóa ";
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi truy vấn danh sách" + ex.Message);
            }
        }

        

        public async Task<string> UpdateNotification(NotificationClassStudent updatedNotification)
        {

            try
            {
                var ex = await _context.NotificationClassStudents.FirstOrDefaultAsync(x => x.subjectNotificationId == updatedNotification.subjectNotificationId 
                                                                                      && x.classId == updatedNotification.classId
                                                                                      && x.studentId == updatedNotification.studentId);
                if (ex == null)
                {
                    return "Không tìm thấy thông báo cần cập nhật";
                }
                ex.subjectNotificationId = updatedNotification.subjectNotificationId;
                ex.studentId = updatedNotification.studentId;
                ex.classId = updatedNotification.classId;
                ex.isForAllStudent = updatedNotification.isForAllStudent;
                ex.IsRead = updatedNotification.IsRead;
                
                if (ex.studentId != null)
                {
                    ex.isForAllStudent = true;
                }
                else
                {
                    ex.isForAllStudent = false;

                }
                await _context.SaveChangesAsync();
                return "Thay đổi thành công";
            }
            catch(Exception ex) 
            {
                throw new Exception("Lỗi khi thực hiện" + ex.Message);
            }
        }

   

        public async Task<string> RemoveNotificationFromStudent(Guid studentId)
        {

            try
            {
                var exist = await _context.NotificationClassStudents.FirstOrDefaultAsync(x => x.studentId == studentId);
                if (exist != null)
                {
                    _context.Remove(exist);
                    await _context.SaveChangesAsync();
                    return "Xóa thành công";
                }
                return "Không tìm thấy thông báo cần xóa ";
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy vấn danh sách" + ex.Message);
            }
        }

        #region exx
        //public async Task<string> DeleteNotificationSubject(int notificationId)
        //{
        //    try
        //    {
        //        var existingNoti = await _context.NotificationClassStudents.FirstOrDefaultAsync(x => x.subjectNotificationId == notificationId);
        //        if (existingNoti != null)
        //        {
        //            _context.Remove(existingNoti);
        //            await _context.SaveChangesAsync();
        //            return "Xóa thành công";
        //        }
        //        return "Không tìm thấy thông báo cần xóa";
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Lỗi khi xử lý" + ex.Message);
        //    }
        //}
        //public async Task<NotificationClassStudent> GetNotificationSubjectById(int notificationId)
        //{
        //    try
        //    {
        //        return await _context.NotificationClassStudents.FirstOrDefaultAsync(x => x.subjectNotificationId == notificationId);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Lôi khi truy vấn danh sách" + ex.Message);
        //    }
        //}
        //public async Task<List<NotificationClassStudent>> GetNotificationsForStudent(Guid studentId)
        //{
        //    try
        //    {
        //        return await _context.NotificationClassStudents.Where(x => x.studentId == studentId)
        //                                                       .ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Lỗi khi truy xuất danh sách" + ex.Message);
        //    }
        //}
        //public async Task<List<NotificationClassStudent>> GetUnreadNotificationsForClass(string classId)
        //{
        //    try
        //    {
        //        return await _context.NotificationClassStudents.Where(x => x.classId == classId && x.IsRead)
        //                                                       .ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Lỗi khi truy cập danh sách" + ex.Message);
        //    }
        //}
        //public async Task<List<NotificationClassStudent>> GetUnreadNotificationsForStudent(Guid studentId)
        //{
        //    try
        //    {
        //        return await _context.NotificationClassStudents.Where(x => x.studentId == studentId && x.IsRead)
        //                                                       .ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Lỗi khi truy cập danh sách" + ex.Message);
        //    }
        //}
        //public async Task<string> MarkAllNotificationsAsReadForStudent(Guid studentId)
        //{
        //    try
        //    {
        //        var notifications = await _context.NotificationClassStudents
        //                           .Where(notification => notification.studentId == studentId && !notification.IsRead)
        //                           .ToListAsync();

        //        foreach (var notification in notifications)
        //        {
        //            notification.IsRead = true;
        //        }

        //        await _context.SaveChangesAsync();
        //        return "Tất cả thông báo được đánh dấu là đã đọc";
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Lỗi khi thực hiện chức năng" + ex.Message);
        //    }
        //}
        //public async Task<string> RemoveNotificationFromStudent(int notificationId, Guid studentId)
        //{
        //    try
        //    {
        //        var notification = await _context.NotificationClassStudents.FindAsync(notificationId);
        //        if (notification == null)
        //            return "Thông báo không được tìm thấy";

        //        if (notification.studentId != studentId)
        //            return "Thông báo không thuộc về sinh viên được chỉ định";

        //        _context.NotificationClassStudents.Remove(notification);
        //        await _context.SaveChangesAsync();
        //        return "Thông báo đã đước xóa thành công";
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Lỗi khi thực hiện" + ex.Message);
        //    }

        //}
        //public async Task<string> UpdateNotification(int notificationId, NotificationClassStudent updatedNotification)
        //{
        //    throw new Exception();
        //}

        //public Task<string> AddClassNotificationForStudent(NotificationClassStudent notification)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion
    }
}
