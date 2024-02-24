using LMS_Library_API.Models;

namespace LMS__Elibrary_BE.Services.UserServices
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetById(string userID);
        Task<string> AddNew(User user);
        Task<string> Update(User user); 
    }
}
