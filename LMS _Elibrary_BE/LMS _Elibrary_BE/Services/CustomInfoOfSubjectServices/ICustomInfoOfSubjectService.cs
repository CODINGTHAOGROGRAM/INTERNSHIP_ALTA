using LMS_Library_API.Models.AboutSubject;

namespace LMS__Elibrary_BE.Services.CustomInfoOfSubjectServices
{
    public interface ICustomInfoOfSubjectService
    {
        Task<CustomInfoOfSubject> GetCustomInfoForSubject(string subjectId);
        Task<string> AddCustomInfoForSubject(CustomInfoOfSubject customInfo);
        Task<string> UpdateCustomInfoForSubject(string subjectId, CustomInfoOfSubject updatedCustomInfo);
        Task<string> RemoveCustomInfoForSubject(string subjectId);

    }
}
