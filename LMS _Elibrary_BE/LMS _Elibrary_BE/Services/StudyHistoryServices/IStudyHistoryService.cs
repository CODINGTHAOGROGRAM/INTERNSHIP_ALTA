using LMS_Library_API.Models.AboutStudent;
using LMS_Library_API.Models.AboutSubject;

namespace LMS__Elibrary_BE.Services.StudyHistoryServices
{
    public interface IStudyHistoryService
    {
        Task<List<StudyHistory>> GetStudyHistoryForStudent(Guid studentId);
        Task<List<Document>> GetDocumentsWatchedByStudent(Guid studentId);
        Task<string> AddStudyHistory(Guid studentId, int documentId, int watchMinutes);
        Task<string> UpdateStudyHistory(StudyHistory studyHistory);
        Task<string> DeleteAllStudyHistoryForStudent(Guid studentId);



    }
}
