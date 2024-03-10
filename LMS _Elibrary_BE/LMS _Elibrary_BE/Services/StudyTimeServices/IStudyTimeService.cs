
using LMS_Library_API.Models.AboutStudent;
using LMS_Library_API.Models;

namespace LMS__Elibrary_BE.Services.StudyTimeServices
{
    public interface IStudyTimeService
    {
        Task<List<StudyTime>> GetStudyTimeForStudent(Guid studentId);
        Task<List<Subject>> GetSubjectsStudiedByStudent(Guid studentId);
        Task<string> AddStudyTime(Guid studentId, string subjectId, int totalTime);
    }
}
