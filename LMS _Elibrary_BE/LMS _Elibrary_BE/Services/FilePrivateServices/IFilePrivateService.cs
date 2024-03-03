using LMS_Library_API.Models.AboutUser;

namespace LMS__Elibrary_BE.Services.FilePrivateServices
{
    public interface IFilePrivateService
    {
        Task<List<PrivateFile>> GetAllFile();
        Task<PrivateFile> GetById( int fileId);
        Task<string> AddNewFile(PrivateFile file);
        Task<string> UpdateFile(PrivateFile file);
        Task<string> DeleteFile(int fileId);
        Task<PrivateFile> GetByUserId (string userId);
        Task<IEnumerable<PrivateFile>> SearchbyItem(string query, string[] searchFields = null);

    }
}
