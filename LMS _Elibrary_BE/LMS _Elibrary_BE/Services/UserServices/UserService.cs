using LMS__Elibrary_BE.Context;
using LMS__Elibrary_BE.Helpers;
using LMS_Library_API.Models;

namespace LMS__Elibrary_BE.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        
        private readonly IUpLoadFileHelper _upLoadFileHelper;

        public UserService(DataContext context, IUpLoadFileHelper upLoadFileHelper)
        {
            _context = context;
            _upLoadFileHelper = upLoadFileHelper;
        }

        public async Task<string> AddNew(User user)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(string userID)
        {
            throw new NotImplementedException();
        }

        public Task<string> Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
