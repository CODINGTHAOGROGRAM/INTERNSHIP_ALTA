using LMS_Library_API.Models.AboutSubject;

namespace LMS__Elibrary_BE.Services.LessonServices
{
    public interface ILessonService
    {
        Task<List<Lesson>> GetAllLessons();
        Task<Lesson> GetLessonById(int lessonId);
        Task<List<Lesson>> GetLessonsByPart(int partId);
        Task<List<Lesson>> GetLessonsByTeacher(Guid teacherId);
        Task<string> AddLesson(Lesson lesson);
        Task<string> UpdateLesson(int lessonId, Lesson updatedLesson);
        Task<string> DeleteLesson(int lessonId);

    }
}
