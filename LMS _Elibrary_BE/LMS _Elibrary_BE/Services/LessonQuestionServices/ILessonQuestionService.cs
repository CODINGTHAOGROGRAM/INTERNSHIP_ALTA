using LMS_Library_API.Models.AboutSubject;

namespace LMS__Elibrary_BE.Services.LessonQuestionServices
{
    public interface ILessonQuestionService
    {
        Task<List<LessonQuestion>> GetQuestionsForLesson(int lessonId);
        Task<List<LessonQuestion>> GetQuestions();
        Task<LessonQuestion> GetQuestionById(int questionId);
        Task<string> AddQuestionToLesson(LessonQuestion question);
        Task<string> UpdateQuestionForLesson(int questionId, LessonQuestion updatedQuestion);
        Task<string> DeleteQuestionFromLesson(int questionId);
    }
}
