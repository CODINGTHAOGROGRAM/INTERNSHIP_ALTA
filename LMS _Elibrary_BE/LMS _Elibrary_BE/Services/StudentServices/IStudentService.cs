using LMS_Library_API.Models;
using System.Collections;

namespace LMS__Elibrary_BE.Services.StudentServices
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudent();
        Task<Student> GetStudentById(string studentId);
        Task<string> AddNewStudent(Student student);
        Task<string> DeleteStudentById(string studentId);
        Task<string> UpdateStudent(Student  studentObj);
        Task<IEnumerable<Student>> SearchStudent(string searchTerm);
        Task<IEnumerable<Student>> GetStudentsByClass(string classId);
    }
}
