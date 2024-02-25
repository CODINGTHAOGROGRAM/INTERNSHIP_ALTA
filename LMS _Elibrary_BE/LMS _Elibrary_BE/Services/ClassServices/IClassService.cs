using LMS_Library_API.Models;

namespace LMS__Elibrary_BE.Services.ClassServices
{
    public interface IClassService
    {
        Task<Class> GetById(string id);
        Task<List<Class>> GetAllClass();
        Task<string> AddNewClass(Class classObj);
        Task<string> UpdateClass(Class classObj);
        Task<string> DeleteClass(string id);

    }
}
