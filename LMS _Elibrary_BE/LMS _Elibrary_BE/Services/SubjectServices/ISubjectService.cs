using LMS_Library_API.Models;

namespace LMS__Elibrary_BE.Services.SubjectServices
{
    public interface ISubjectService
    {
        Task<List<Subject>> GetSubjects();
        Task<Subject> GetSubjectById(string subjectId);
        Task<string> AddNewSubject(Subject subject);
        Task<string> UpdateSubject(Subject subject);
        Task<string> DeleteSubject(string subjectId);
        Task<string> AddStudentToSubject(string subjectId, string studentId);
        Task<string> RemoveStudentFromSubject(string subjectId, string studentId);
        Task<IEnumerable<Subject>> SearchSubjects(string searchTerm, string[] searchFields);
        Task<List<Subject>> GetSubjectByUserId(string userId);
        Task<bool> ToggleFavoriteSubject(string subjectId, string studentId);
        Task<bool> MarkSubjectAsRead(string subjectId, string studentId);
        //Task<IEnumerable<Subject>> GetFavoriteSubjects(int studentId);
        //Task<IEnumerable<Subject>> GetCompletedSubjectsAsync(int studentId);

    }
}

