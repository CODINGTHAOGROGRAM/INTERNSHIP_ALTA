using LMS__Elibrary_BE.Context;
using LMS_Library_API.Models;
using LMS_Library_API.Models.AboutUser;
using Microsoft.EntityFrameworkCore;

namespace LMS__Elibrary_BE.Services.TeacherClassServices
{
    public class TeacherClassService : ITeacherClassService
    {
        private readonly DataContext _context;
        public TeacherClassService(DataContext context)
        {
            _context = context;
        }
        public async Task<string> AddTeacherClass(TeacherClass teacherClass)
        {
            try
            {
                _context.TeacherClasses.Add(teacherClass);
                await _context.SaveChangesAsync();
                return "Thêm thành công";
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện " + ex.Message);
            }
        }

        public async Task<List<TeacherClass>> GetAllTeacherClasses()
        {
            try
            {
                return await _context.TeacherClasses.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện " + ex.Message);
            }
        }

        public async Task<List<TeacherClass>> GetTeacherClassesByClassId(string classId)
        {
            try
            {
                return await _context.TeacherClasses.Where(x => x.classId == classId)
                                                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện " + ex.Message);
            }
        }

        public async Task<List<TeacherClass>> GetTeacherClassesByTeacherId(Guid teacherId)
        {
            try
            {
                return await _context.TeacherClasses.Where(x => x.teacherId == teacherId)
                                                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện " + ex.Message);
            }
        }

        public async Task<string> RemoveTeacherFromClass(Guid teacherId, string classId)
        {
            try
            {
                var teacherClass = await _context.TeacherClasses.FirstOrDefaultAsync(tc => tc.teacherId == teacherId && tc.classId == classId);
                if (teacherClass != null)
                {
                    _context.TeacherClasses.Remove(teacherClass);
                    await _context.SaveChangesAsync();
                    return "Giảng viên đã được xóa ra khỏi lớp.";
                }
                return "Không tìm thấy đối tượng cần xóa.";
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện " + ex.Message);
            }
        }

        public async Task<string> UpdateTeacherClass(TeacherClass teacherClass)
        {
            try
            {
                var existingTeacherClass = await _context.TeacherClasses.FirstOrDefaultAsync(tc => tc.teacherId == teacherClass.teacherId && tc.classId ==teacherClass.classId);
                if (existingTeacherClass != null)
                {
                    existingTeacherClass.teacherId = teacherClass.teacherId;
                    existingTeacherClass.classId = teacherClass.classId;
                    _context.TeacherClasses.Update(existingTeacherClass);
                    await _context.SaveChangesAsync();
                    return "Thay đổi thành công.";
                }
                return "Đối tượng không tìm thấy để cập nhật";
            }
            catch(Exception ex )
            {
                throw new Exception("Lỗi khi thực hiện " + ex.Message);
            }
        }
    }
}
