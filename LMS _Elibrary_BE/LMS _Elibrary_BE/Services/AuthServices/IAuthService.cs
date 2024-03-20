using LMS__Elibrary_BE.ViewModels;
using LMS_Library_API.Models;

namespace LMS__Elibrary_BE.Services.AuthServices
{
    public interface IAuthService
    {
        Task<Student> StudentLogin(ViewLogin login);
        Task<User> UserLogin(ViewLogin login);
    }
}
