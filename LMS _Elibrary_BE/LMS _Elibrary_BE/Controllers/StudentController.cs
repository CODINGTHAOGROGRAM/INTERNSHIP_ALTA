using AutoMapper;
using LMS__Elibrary_BE.ModelsDTO;
using LMS__Elibrary_BE.Services.StudentServices;
using LMS_Library_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class StudentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;
        public StudentController(IMapper mapper, IStudentService studentService)
        {
            _mapper = mapper;
            _studentService = studentService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            try
            {
                var students = await _studentService.GetAllStudent();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("studentId")]
        public async Task<IActionResult> GetStudentById(string studentId)
        {
            try
            {
                var student = await _studentService.GetStudentById(studentId);
                return Ok(student);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Search")]
        public async Task<IActionResult> SearchStudent(string searchTerm)
        {
            try
            {
                var result = await _studentService.SearchStudent(searchTerm);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetStudentByClass")]
        public async Task<IActionResult> GetStudentsByClass(string classId)
        {
            try
            {
                var result = await _studentService.GetStudentsByClass(classId);
                return Ok(result);
            }
            catch( Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("AddNew")]
        public async Task<IActionResult> AddNewStudent(StudentDTO studentObj)
        {
            try
            {
                var newStudent = _mapper.Map<Student>(studentObj);
                var student = await _studentService.AddNewStudent(newStudent);
                return Ok(student);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("UpdateStudent")]
        public async Task<IActionResult> UpdateStudent(StudentDTO student)
        {
            try
            {
                var stu = _mapper.Map<Student>(student);
                var newStudent = await _studentService.UpdateStudent(stu);
                return Ok(newStudent);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(string studentId)
        {
            try
            {
                var student = await _studentService.DeleteStudentById(studentId);
                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
