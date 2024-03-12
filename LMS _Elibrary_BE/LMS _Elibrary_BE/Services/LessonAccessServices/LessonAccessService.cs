using LMS__Elibrary_BE.Context;
using LMS_Library_API.Models.AboutSubject;
using Microsoft.EntityFrameworkCore;

namespace LMS__Elibrary_BE.Services.LessonAccessServices
{
    public class LessonAccessService : ILessonAccessService
    {
        private readonly DataContext _context;
        public LessonAccessService(DataContext context)
        {
            _context = context;
        }
        public async Task<string> AddLessonAccessForClass(int lessonId, string classId, bool isForAllClasses)
        {
            try
            {
                var existingLessonAccess = await _context.LessonAccess.FirstOrDefaultAsync(la => la.lessonId == lessonId && la.classId == classId);
                if (existingLessonAccess != null)
                {
                    return "Quyền truy cập bài học cho lớp này đã tồn tại.";
                }

                var lessonAccess = new LessonAccess
                {
                    lessonId = lessonId,
                    classId = classId,
                    isForAllClasses = isForAllClasses
                };

                _context.LessonAccess.Add(lessonAccess);
                await _context.SaveChangesAsync();

                return "Quyền truy cập được thêm thành công.";
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm quyền" + ex.Message);
            }
        }

        public async Task<string> DeleteLessonAccess(int lessonId)
        {
            try
            {
                var exitsLesson = await _context.LessonAccess.FirstOrDefaultAsync(x => x.lessonId == lessonId);
                if (exitsLesson != null)
                {
                    _context.Remove(exitsLesson);
                    await _context.SaveChangesAsync();
                    return "Xóa quyền truy cập thành công";
                }
                return "Không tìm thấy quyền cần xóa";
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi truy cập quyền để xóa" + ex.Message);
            }
        }

        public async Task<LessonAccess> GetLessonAccessById(int lessonId)
        {
            try
            {
                return await _context.LessonAccess.FirstOrDefaultAsync(x => x.lessonId == lessonId);
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi try cập " + ex.Message);
            }
        }

        public async Task<LessonAccess> GetLessonAccessForClass(int lessonId, string classId)
        {
            try
            {
                var lessonAccess = await _context.LessonAccess.FirstOrDefaultAsync(la => la.lessonId == lessonId && la.classId == classId);
                return lessonAccess;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi truy xuất quyền truy cập bài học cho lớp học" + ex.Message, ex);
            }

        }

        public async Task<string> RemoveLessonAccessForClass(int lessonId, string classId)
        {

            try
            {
                var lessonAccess = await _context.LessonAccess.FirstOrDefaultAsync(la => la.lessonId == lessonId && la.classId == classId);
                if (lessonAccess != null)
                {
                    _context.LessonAccess.Remove(lessonAccess);
                    await _context.SaveChangesAsync();
                    return "Xóa thành công";
                }
                else
                {
                    return "Không tìm thấy đối tượng cần xóa";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa quyền truy cập bài học cho lớp học " + ex.Message, ex);
            }
        }

        public async Task<string> UpdateLessonAccess(int id, LessonAccess updatedLessonAccess)
        {
            try
            {
                var lessonAccess = await _context.LessonAccess.FindAsync(id);
                if (lessonAccess != null)
                {
                    lessonAccess.isForAllClasses = updatedLessonAccess.isForAllClasses;
                    _context.Entry(lessonAccess).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return "Cập nhật thành công";
                }
                else
                {
                    return "Không tìm thấy đối tượng cần cập nhật";
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception("Lỗi khi cập nhật đối tượng"+ ex.Message, ex);
            }
        }
    }
}
