using LMS__Elibrary_BE.Context;
using LMS_Library_API.Models.AboutUser;
using Microsoft.EntityFrameworkCore;

namespace LMS__Elibrary_BE.Services.ExamRecentViewsServices
{
    public class ExamRecentViewsService : IExamRecentViewsService
    {
        private readonly DataContext _context;
        public ExamRecentViewsService(DataContext context)
        {
            _context = context;
        }
        public async Task<string> AddExamRecentViews(ExamRecentViews examRecentViews)
        {
            try
            {
                _context.ExamRecentViews.Add(examRecentViews);
                await _context.SaveChangesAsync();
                return "Thêm thành công";

            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm" + ex.Message);
            }
        }


        public async Task<string> DeleteExamRecentViews(Guid userId, string examId)
        {
            try
            {
                var exam = await _context.ExamRecentViews.FirstOrDefaultAsync(x => x.UserId == userId && x.ExamId == examId);
                if (exam != null)
                {
                    _context.Remove(exam);
                    await _context.SaveChangesAsync();
                    return "Xóa thành công";
                }
                return "Không tìm thấy đối tượng cần xóa";
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện" + ex.Message);
            }
        }

        public async Task<List<ExamRecentViews>> GetAllExamRecentViews()
        {
            try
            {
                return await _context.ExamRecentViews.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện" + ex.Message);
            }
        }

        public async Task<List<ExamRecentViews>> GetExamRecentViewsByExamId(string examId)
        {
            try
            {
                return await _context.ExamRecentViews.Where(x => x.ExamId == examId)
                                                     .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện" + ex.Message);
            }
        }

        public async Task<List<ExamRecentViews>> GetExamRecentViewsByUserId(Guid userId)
        {
            try
            {
                return await _context.ExamRecentViews.Where(x => x.UserId == userId)
                                                     .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện" + ex.Message);
            }
        }
    }
}
