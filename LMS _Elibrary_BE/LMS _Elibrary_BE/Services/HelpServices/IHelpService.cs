using LMS_Library_API.Models.AboutUser;

namespace LMS__Elibrary_BE.Services.HelpServices
{
    public interface IHelpService
    {
        Task<List<Help>> GetAllHelp();
        Task<Help> GetHelpById(int id);
        Task<string> AddHelp(Help help);
        Task<string> UpdateHelp(int id, Help updatedHelp);
        Task<string> DeleteHelp(int id);
    }
}
