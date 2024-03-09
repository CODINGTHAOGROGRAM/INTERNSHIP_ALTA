using LMS__Elibrary_BE.Context;
using LMS_Library_API.Models;
using Microsoft.EntityFrameworkCore;

namespace LMS__Elibrary_BE.Services.DepartmentServices
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DataContext _context;
        public DepartmentService(DataContext context)
        {
            _context = context;
        }
        public async Task<string> CreateDepartment(Department department)
        {
            try
            {
                 _context.Departments.Add(department);
                await _context.SaveChangesAsync();
                return ("Thêm thành công");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm" + ex.Message, ex);
            }
        }

        public async Task<string> DeleteDepartment(string departmentId)
        {
            try
            {
                var exitsDepartment = _context.Departments.FirstOrDefault(x => x.Id == departmentId);
                if (exitsDepartment == null)
                {
                    return ("Id không tồn tại");
                }
                _context.Remove(exitsDepartment);
                await _context.SaveChangesAsync();
                return "Xóa thành công";
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi truy xuất Id" + ex.Message, ex);
            }
           
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            try
            {
               return await _context.Departments.ToListAsync();
            }
            catch(Exception ex)
            {
                return new List<Department>();
            }
        }

        public async Task<Department> GetDepartmentById(string departmentId)
        {
            try
            {
                return await _context.Departments.FirstOrDefaultAsync(x => x.Id == departmentId);
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi truy xuất" +ex.Message, ex);
            }
        }

        public async Task<List<User>> GetUsersByDepartmentId(string departmentId)
        {
            try
            {
                return await _context.Users.Where(x => x.Id == Guid.Parse(departmentId)).ToListAsync();
            }
            catch(Exception ex)
            {
                return new List<User>();
            }
        }

        public async Task<IEnumerable<Department>> SearchDepartmentsByName(string name)
        {
            try
            {
                return await _context.Departments.Where(d => d.Name.Contains(name)).ToListAsync();
            }
            catch(Exception ex)
            {
                return new List<Department>();
            }
        }

        public async Task<string> UpdateDepartment(string departmentId, Department updatedDepartment)
        {
            try
            {
                var department = await _context.Departments.FirstOrDefaultAsync(d => d.Id == departmentId);
                if (department != null)
                {
                    department.Name = updatedDepartment.Name;
                    await _context.SaveChangesAsync();
                    
                }
                return ("Không tìm thấy Id cần tìm");
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi truy xuất");
            }
        }
    }
}
