using LMS__Elibrary_BE.Context;
using LMS__Elibrary_BE.Helpers;
using LMS__Elibrary_BE.ViewModels;
using LMS_Library_API.Models;
using Microsoft.EntityFrameworkCore;

namespace LMS__Elibrary_BE.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;
        private readonly IEncodeHelper _encodeHelper;
        public AuthService(DataContext context, IEncodeHelper encodeHelper)
        {
            _context = context;
            _encodeHelper = encodeHelper;
        }
        public async Task<Student> StudentLogin(ViewLogin login)
        {
            try
            {
                var request = await _context.Students.FirstOrDefaultAsync(x => x.Email.Equals(login.Email) && x.Password.Equals(_encodeHelper.Encode(login.Password)));
                if (request == null)
                {
                    throw new Exception("Tài khoản đăng nhập không tồn tại");
                }
                return request;

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> UserLogin(ViewLogin login)
        {
            try
            {
                var request = await _context.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.Email.Equals(login.Email) && x.Password.Equals(_encodeHelper.Encode(login.Password)));
                if(request == null)
                {
                    throw new Exception("Tài khoản không tồn tại");
                }    
                return request;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
