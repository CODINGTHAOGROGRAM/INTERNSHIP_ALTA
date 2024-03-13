using LMS_Library_API.Models.AboutSubject;

namespace LMS__Elibrary_BE.Services.LessonAnswerServices
{
    public interface ILessonAnswerService
    {
        Task<List<LessonAnswer>> GetAnswersForLessonQuestion(int lessonQuestionId);
        Task<List<LessonAnswer>> GetAllAnswers();
        Task<LessonAnswer> GetAnswerById(int answerId);
        Task<string> AddAnswerToLessonQuestion(LessonAnswer answer);
        Task<string> UpdateAnswerToLessonQuestion(int answerId, LessonAnswer updatedAnswer);
        Task<string> DeleteAnswerToLessonQuestion(int answerId);
    }
}
