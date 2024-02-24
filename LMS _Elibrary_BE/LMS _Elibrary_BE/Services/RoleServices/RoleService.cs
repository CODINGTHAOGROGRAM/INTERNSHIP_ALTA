using LMS__Elibrary_BE.Context;
using LMS_Library_API.Models.RoleAccess;
using Microsoft.EntityFrameworkCore;

namespace LMS__Elibrary_BE.Services.RoleServices
{
    public class RoleService : IRoleService
    {

        private readonly DataContext _context;
        public RoleService(DataContext context ) 
        {
            _context = context;
        }    
        public async Task<int> AddNew(Role role)
        {
            _context.Role.Add( role );
            await _context.SaveChangesAsync();
            return 0;
        }

        public async Task DeleteRole(int roleID)
        {
            try
            {
                var role = await _context.Role.FirstOrDefaultAsync(r => r.Id == roleID); 
                if (role == null)
                {
                    throw new Exception("Không tìm thấy vai trò cần xóa");
                }

                _context.Remove(role);
                await _context.SaveChangesAsync();
                
            } 
            catch (Exception ex)
            {
                throw new Exception("Xảy ra lỗi khi xóa", ex);
            }
          
        }

        public async Task<List<Role>> GetAllRole()
        {
            try
            {
                return await _context.Role.ToListAsync();
            }
            catch (Exception ex) 
            {
                return new List<Role>();
            }
        }

        public async Task<Role> GetRoleById(int roleID)
        {
            try
            {
                return await _context.Role.FirstOrDefaultAsync(r => r.Id == roleID);
            }
            catch(Exception ex) 
            {
                return new Role();
            }
        }

        public async Task<int> UpdateRole(Role role)
        {
            try
            {
                var ExitRole = _context.Role.FirstOrDefault(r => r.Id == role.Id);
                if(ExitRole == null)
                {
                    throw new Exception("Vai trò không tồn tại");
                }

                ExitRole.Name = role.Name;
                ExitRole.Description = role.Description;
                ExitRole.DateUpdated = role.DateUpdated;

                await _context.SaveChangesAsync();
            }
            catch(Exception ex) 
            {
                throw new Exception("Lỗi khi thay đổi", ex);
            }
            return 0;
        }
    }
}
