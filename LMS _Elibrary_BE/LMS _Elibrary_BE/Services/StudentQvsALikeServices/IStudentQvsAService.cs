using LMS_Library_API.Models;

namespace LMS__Elibrary_BE.Services.StudentQvsALikeServices
{
    public interface IStudentQvsAService
    {
        // Lấy danh sách câu hỏi mà học sinh này thích
        Task<IEnumerable<StudentQvsAService>> GetQuestionsLikedByStudent(Guid studentId);

        // Lấy danh sách câu trả lời mà học sinh này thích
        Task<IEnumerable<StudentQvsAService>> GetAnswersLikedByStudent(Guid studentId);

        Task<IEnumerable<Student>> GetStudentsWhoLikedAnswer(string answerId);
        Task<IEnumerable<Student>> GetStudentsWhoLikedQuestion(string questionId);

        // Bật tắt trạng thái thích cho câu hỏi và trả lời
        Task ToggleQuestionLike(Guid studentId, string questionId);
        Task ToggleAnswerLike(Guid studentId, string answerId);

    }
}
