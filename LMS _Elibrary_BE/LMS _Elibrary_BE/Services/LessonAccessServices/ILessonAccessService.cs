using LMS_Library_API.Models.AboutSubject;

namespace LMS__Elibrary_BE.Services.LessonAccessServices
{
    public interface ILessonAccessService
    {
        Task<LessonAccess> GetLessonAccessById(int lessonId);
        Task<LessonAccess> GetLessonAccessForClass(int lessonId, string classId);
        Task<string> AddLessonAccessForClass(int lessonId, string classId, bool isForAllClasses);
        Task<string> RemoveLessonAccessForClass(int lessonId, string classId);
        Task<string> UpdateLessonAccess(int id, LessonAccess updatedLessonAccess);
        Task<string> DeleteLessonAccess(int lessonId);
    }
}
