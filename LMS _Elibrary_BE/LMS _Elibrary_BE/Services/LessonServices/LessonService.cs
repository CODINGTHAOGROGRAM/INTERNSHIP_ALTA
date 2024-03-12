using LMS__Elibrary_BE.Context;
using LMS_Library_API.Models.AboutSubject;
using Microsoft.EntityFrameworkCore;

namespace LMS__Elibrary_BE.Services.LessonServices
{
    public class LessonService : ILessonService
    {
        private readonly DataContext _context;
        public LessonService(DataContext context)
        {
            _context = context;
        }
        public async Task<string> AddLesson(Lesson lesson)
        {
            try
            {
                _context.Lessons.Add(lesson);
                await _context.SaveChangesAsync();
                return "Lưu thành công";
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện thêm" +  ex.Message);
            }
        }

        public async Task<string> DeleteLesson(int lessonId)
        {
            try
            {
                var result = await _context.Lessons.FirstOrDefaultAsync(x => x.Id == lessonId);
                if(result != null)
                {
                    _context.Lessons.Remove(result);
                    await _context.SaveChangesAsync();
                    return "Xóa đối tượng thành công";
                }
                return "Không tìm thấy đối tượng cần xóa";
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi xóa bài học:" + ex.Message);
            }
        }

        public async Task<List<Lesson>> GetAllLessons()
        {
            try
            {
                return await _context.Lessons.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi truy cập vào danh sách" + ex.Message);
            }
        }

        public async Task<Lesson> GetLessonById(int lessonId)
        {
            try
            {
                return await _context.Lessons.FirstOrDefaultAsync(x => x.Id == lessonId);
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi truy cập đối tượng" + ex.Message);
            }
        }

        public async Task<List<Lesson>> GetLessonsByPart(int partId)
        {
            try
            {
                return await _context.Lessons.Where(x => x.partId == partId)
                                             .ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi truy cập danh sách" + ex.Message);
            }
        }

        public async Task<List<Lesson>> GetLessonsByTeacher(Guid teacherId)
        {
            try
            {
                return await _context.Lessons.Where(l => l.teacherCreatedId == teacherId)
                                             .ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi truy cập dữ liệu danh sách" + ex.Message);
            }
        }

        public async Task<string> UpdateLesson(int lessonId, Lesson updatedLesson)
        {
            try
            {
                var lesson = await _context.Lessons.FindAsync(lessonId);
                if (lesson != null)
                {
                    _context.Entry(lesson).CurrentValues.SetValues(updatedLesson);
                    await _context.SaveChangesAsync();
                    return "Cập nhật bài học thành công.";
                }
                else
                {
                    return "Không tìm thấy bài học cần cập nhật.";
                }
            }
            catch (Exception ex)
            {
                throw new Exception( "Lỗi khi cập nhật bài học: " + ex.Message);
            }
        }
    }
}
