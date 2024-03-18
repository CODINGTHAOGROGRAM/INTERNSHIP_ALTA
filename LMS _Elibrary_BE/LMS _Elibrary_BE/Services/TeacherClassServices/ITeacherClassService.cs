using LMS_Library_API.Models.AboutUser;

namespace LMS__Elibrary_BE.Services.TeacherClassServices
{
    public interface ITeacherClassService
    {
        Task<List<TeacherClass>> GetAllTeacherClasses();
        Task<List<TeacherClass>> GetTeacherClassesByTeacherId(Guid teacherId);
        Task<List<TeacherClass>> GetTeacherClassesByClassId(string classId);
        Task<string> AddTeacherClass(TeacherClass teacherClass);
        Task<string> UpdateTeacherClass(TeacherClass teacherClass);
        Task<string> RemoveTeacherFromClass(Guid teacherId, string classId);
    }
}
