using LMS__Elibrary_BE.Models;

namespace LMS__Elibrary_BE.Services.RoleServices
{
    public interface IRoleService
    {
        Task<List<Role>> GetAllRole();
        Task<Role> GetRoleById(int roleID);
        Task<int> AddNew(Role role);
        Task <int> UpdateRole(Role role);
        Task DeleteRole(int roleID);

    }
}
