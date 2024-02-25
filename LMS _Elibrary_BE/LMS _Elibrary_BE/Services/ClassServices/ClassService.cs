using LMS__Elibrary_BE.Context;
using LMS_Library_API.Models;
using Microsoft.EntityFrameworkCore;

namespace LMS__Elibrary_BE.Services.ClassServices
{
    public class ClassService : IClassService
    {
        private readonly DataContext _context;
        public ClassService(DataContext context)
        {
            _context = context;
        }

        public async Task<string> AddNewClass(Class classObj)
        {
            try
            {
                _context.Classes.Add(classObj);
                await _context.SaveChangesAsync();
                return "Thêm lớp học thành công!";
            }
            catch (Exception ex)
            {
                return "Lỗi khi thêm lớp học: " + ex.Message;
            }
        }

        public async Task<string> DeleteClass(string id)
        {
            try
            {
                var classToDelete = await _context.Classes.FindAsync(id);
                if (classToDelete == null)
                {
                    return "Không tìm thấy lớp học để xóa.";
                }

                _context.Classes.Remove(classToDelete);
                await _context.SaveChangesAsync();

                return "Xóa lớp học thành công!";
            }
            catch (Exception ex)
            {
                return "Lỗi khi xóa lớp học: " + ex.Message;
            }
        }

        public async Task<List<Class>> GetAllClass()
        {
            try
            {
                return await _context.Classes.ToListAsync();
            }
            catch(Exception ex)
            {
                return new List<Class>();
            }
        }

        public async Task<Class> GetById(string id)
        {
            try
            {
                return await _context.Classes.FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                return new Class();
            }
        }

        public async Task<string> UpdateClass(Class classObj)
        {
            try
            {
                var existingClass = await _context.Classes.FindAsync(classObj.Id);
                if (existingClass == null)
                {
                    return "Không tìm thấy lớp học để cập nhật.";
                }

                existingClass.name = classObj.name;
                existingClass.totalStudent = classObj.totalStudent;

                await _context.SaveChangesAsync();

                return "Cập nhật lớp học thành công!";
            }
            catch (Exception ex)
            {
                return "Lỗi khi cập nhật lớp học: " + ex.Message;
            }
        }
    }
}
