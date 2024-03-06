using LMS__Elibrary_BE.Context;
using LMS_Library_API.Models;
using Microsoft.EntityFrameworkCore;

namespace LMS__Elibrary_BE.Services.StudentServices
{
    public class StudentService : IStudentService
    {
        private readonly DataContext _context;
        public StudentService(DataContext context)
        {
            _context = context;
        }

        public async Task<string> AddNewStudent(Student student)
        {
            try
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return ("Thêm thành công");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm"+ex.Message, ex);
            }
        }

        public async Task<string> DeleteStudentById(string studentId)
        {
            try
            {
                var existingStudent = _context.Students.FirstOrDefault(st => st.Id == Guid.Parse(studentId));
                if(existingStudent == null)
                {
                    return ("Không tìm thấy bất kì sinh viên nào theo Id trên");
                }
                _context.Students.Remove(existingStudent);
                await _context.SaveChangesAsync();
                return ("Xóa thành công");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa" + ex.Message, ex);
            }
        }

        public async Task<List<Student>> GetAllStudent()
        {
            try
            {
                return await _context.Students.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Không tìm thấy danh sách");
            }
        }

        public async Task<Student> GetStudentById(string studentId)
        {
            try
            {
                return await _context.Students.FirstOrDefaultAsync(st => st.Id == Guid.Parse(studentId));
            }
            catch(Exception ex) 
            {
                throw new Exception("Không tìm thấy sinh viên theo ID trên");
            }
        }

        public async Task<IEnumerable<Student>> GetStudentsByClass(string classId)
        {
            try
            {
                var result = await _context.Students.Where(st => st.classId == classId).ToListAsync();
                if(result == null)
                {
                    throw new Exception("Không tìm thấy sinh viên theo mã lớp trên");
                }    
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm danh sách sinh viên theo mã lớp");
            }
        }

        public async Task<IEnumerable<Student>> SearchStudent(string searchTerm)
        {
            try
            {
                var students = _context.Students.Where(st => st.FullName.Contains(searchTerm)
                                || st.Email.Contains(searchTerm)
                                || st.PhoneNumber.Contains(searchTerm)
                                || st.Address.Contains(searchTerm));
                if (students == null)
                    throw new Exception("không tìm thấy học sinh");
                return await students.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiến sinh viên"+ ex.Message, ex);
            }
        }

        public async Task<string> UpdateStudent(Student studentObj)
        {
            try
            {
                var existingStudent = _context.Students.FirstOrDefault(st => st.Id ==studentObj.Id);
                if(existingStudent == null)
                {
                    return ("Không tìm thấy sinh viên cần chỉnh sửa");
                }
                existingStudent.FullName = studentObj.FullName;
                existingStudent.Email = studentObj.Email;
                existingStudent.PhoneNumber = studentObj.PhoneNumber;
                existingStudent.Address = studentObj.Address;
                existingStudent.Gender = studentObj.Gender;
                existingStudent.Avartar = studentObj.Avartar;
                await _context.SaveChangesAsync();
                return ("Thay đổi thành công");

            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi thay đổi sinh viên" + ex.Message, ex);
            }
        }
    }
}
