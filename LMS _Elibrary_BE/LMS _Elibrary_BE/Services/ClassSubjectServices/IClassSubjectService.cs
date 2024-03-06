using LMS_Library_API.Models.AboutStudent;
using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Services.ClassSubjectServices
{
    public interface IClassSubjectService
    {
        Task<List<ClassSubject>> GetAllClassSubjects();

        Task<ClassSubject?> GetClassSubjectById(string classId, string subjectId);

        Task<string> CreateClassSubject(ClassSubject classSubject);

        Task<string> UpdateClassSubject(string classId, string subjectId, ClassSubject updatedClassSubject);

        Task<string> DeleteClassSubject(string classId, string subjectId);
    }
}
