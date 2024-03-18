using LMS_Library_API.Models.AboutUser;

namespace LMS__Elibrary_BE.Services.ExamRecentViewsServices
{
    public interface IExamRecentViewsService
    {
        Task<List<ExamRecentViews>> GetAllExamRecentViews();
        Task<List<ExamRecentViews>> GetExamRecentViewsByUserId(Guid userId);
        Task<List<ExamRecentViews>> GetExamRecentViewsByExamId(string examId);
        Task<string> AddExamRecentViews(ExamRecentViews examRecentViews);
        Task<string> UpdateExamRecentViews(ExamRecentViews examRecentViews);
        Task<string> DeleteExamRecentViews(Guid userId, string examId);
    }
}
