using LMS__Elibrary_BE.Context;
using LMS__Elibrary_BE.Helpers;
using LMS__Elibrary_BE.ViewModels;
using LMS_Library_API.Models;
using Microsoft.EntityFrameworkCore;

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
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return "Thêm thành công";
            }
            catch (DbUpdateException ex) 
            {
                throw new Exception("Lỗi khi thêm" +ex.Message,ex);
            }
           
        }

        public Task<int?> ChangePassword(ChangePassword changePassword)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteById(string userID)
        {
            try
            {
                var userDelete = _context.Users.FirstOrDefault(u => u.Id == Guid.Parse(userID));
                if (userDelete == null)
                {
                    throw new Exception("Không tìm thấy người dùng để xóa.");
                }
                _context.Remove(userDelete);
                await _context.SaveChangesAsync();
                throw new Exception("Xóa người dùng thành công");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Lỗi khi xóa người dùng.", ex);
            }
           
        }

        public Task<int> ForgotPassword(string newPassword, string empEmail)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                var users = await _context.Users.ToListAsync();
                if (users.Count == 0)
                {
                    throw new Exception("Danh sách người dùng trống");
                }
                return users;
            }catch(DbUpdateException ex)
            {
                return new List<User>();
            }
            
        }

        public async Task<User> GetById(string userID)
        {
            try
            {
                return await _context.Users.FirstOrDefaultAsync(u => u.Id == Guid.Parse(userID));
               
            }
            catch(DbUpdateException ex) 
            {
                return new User();
            }
        }

        public async Task<string> Update(User user)
        {
            try
            {
                var existingUser = _context.Users.FirstOrDefault(u => u.Id == user.Id);
                if(existingUser == null)
                {
                  throw new Exception("Không tìm thấy người dùng để cập nhật.");
                }
                //
                existingUser.FullName = user.FullName;
                existingUser.Email = user.Email;
                existingUser.Gender = user.Gender;
                existingUser.PhoneNumber = user.PhoneNumber;
                existingUser.Address = user.Address;
                existingUser.Department = user.Department;
                if(user.Avartar == null)
                {
                    existingUser.Avartar = user.Avartar;
                }
                else
                {
                    existingUser.Avartar = user.Avartar;
                }
                await _context.SaveChangesAsync();
                return "Thay đổi thành công";
            }
            catch(Exception ex) 
            {
                throw new Exception("Lỗi khi cập nhật" + ex.Message, ex);
            } 
            
            
        }


    }
}
