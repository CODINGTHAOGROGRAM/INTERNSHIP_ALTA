using LMS__Elibrary_BE.Context;
using LMS_Library_API.Models.AboutSubject;
using Microsoft.EntityFrameworkCore;

namespace LMS__Elibrary_BE.Services.CustomInfoOfSubjectServices
{
    public class CustomInfoOfSubjectService : ICustomInfoOfSubjectService
    {
        private readonly DataContext _context;
        public CustomInfoOfSubjectService(DataContext context)
        {
            _context = context;
        }
        public async Task<string> AddCustomInfoForSubject(CustomInfoOfSubject customInfo)
        {
            try
            {
                _context.CustomInfoOfSubjects.Add(customInfo);
                await _context.SaveChangesAsync();
                return ("Thêm mới thành công");
            }
            catch (Exception ex)
            {
                throw new Exception("Xảy ra lỗi khi thêm" + ex.Message, ex);
            }
        }

        public async Task<CustomInfoOfSubject> GetCustomInfoForSubject(string subjectId)
        {
            try
            {
                return await _context.CustomInfoOfSubjects.FirstOrDefaultAsync(s => s.subjectId == subjectId);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách" +ex.Message, ex);
            }
        }

        public async Task<string> RemoveCustomInfoForSubject(string subjectId)
        {
            try
            {
                var result = await _context.CustomInfoOfSubjects.FirstOrDefaultAsync(x => x.subjectId == subjectId);
                if (result != null)
                {
                    _context.CustomInfoOfSubjects.Remove(result);
                    await _context.SaveChangesAsync();
                    return "Xóa thông tin tùy chỉnh cho môn học thành công.";
                }
                return ("Không tìm thấy đối tượng cần xóa");
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi tìm đối tượng" + ex.Message, ex);
            }
        }

        public async Task<string> UpdateCustomInfoForSubject(string subjectId, CustomInfoOfSubject updatedCustomInfo)
        {
            try
            {
                var existingCustomInfo = await _context.CustomInfoOfSubjects.FirstOrDefaultAsync(c => c.subjectId == subjectId);
                if (existingCustomInfo != null)
                {
                    existingCustomInfo.title = updatedCustomInfo.title;
                    existingCustomInfo.content = updatedCustomInfo.content;
                    existingCustomInfo.status = updatedCustomInfo.status;
                    await _context.SaveChangesAsync();
                    return "Cập nhật thông tin tùy chỉnh cho môn học thành công.";
                }
                else
                {
                    return "Không tìm thấy thông tin tùy chỉnh cho môn học để cập nhật.";
                }
            }
            catch (Exception ex)
            {
                return "Lỗi khi cập nhật thông tin tùy chỉnh cho môn học: " + ex.Message;
            }
        }
    
    }
}
