using LMS_Library_API.Models;

namespace LMS__Elibrary_BE.Services.DepartmentServices
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetAllDepartments();
        Task<Department> GetDepartmentById(string departmentId);
        Task<string> CreateDepartment(Department department);
        Task<string> UpdateDepartment(string departmentId, Department updatedDepartment);
        Task<string> DeleteDepartment(string departmentId);
        Task<IEnumerable<Department>> SearchDepartmentsByName(string name);
        Task<List<User>> GetUsersByDepartmentId(string departmentId);                                                                  
    }
}
