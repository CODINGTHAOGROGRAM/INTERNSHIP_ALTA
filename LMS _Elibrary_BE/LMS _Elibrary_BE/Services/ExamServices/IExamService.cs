using LMS_Library_API.Models.Exams;

namespace LMS__Elibrary_BE.Services.ExamServices
{
    public interface IExamService
    {
        Task<List<Exam>> GetAllExam();
        Task<Exam> GetExamById(string Id);
        Task<string> UpdateExam(Exam exam);
        Task<string> AddNewExam(Exam exam);
        Task<string> DeleteExam(string Id);
        Task<IEnumerable<Exam>> SearchExam(string searchTerm, string[] searchFields = null);
        Task<Exam> GetExamByUserId(string CreatorId);
    }
}
