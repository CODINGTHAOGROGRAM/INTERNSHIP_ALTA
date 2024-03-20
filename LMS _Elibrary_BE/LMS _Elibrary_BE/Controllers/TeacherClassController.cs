using AutoMapper;
using LMS__Elibrary_BE.ModelsDTO;
using LMS__Elibrary_BE.Services.TeacherClassServices;
using LMS_Library_API.Models.AboutUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class TeacherClassController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITeacherClassService _service;
        public TeacherClassController(IMapper mapper, ITeacherClassService service)
        {
            _mapper = mapper;
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllTeacherClasses()
        {
            try
            {
                var result = await _service.GetAllTeacherClasses();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Classes/{teacherId}")]
        public async Task<IActionResult> GetTeacherClassesByTeacherId(Guid teacherId)
        {
            try
            {
                var result = await _service.GetTeacherClassesByTeacherId(teacherId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("Classes/{classId}")]
        public async Task<IActionResult> GetTeacherClassesByClassId(string classId)
        {
            try
            {
                var result = await _service.GetTeacherClassesByClassId(classId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddTeacherClass(TeacherClassDTO teacherClass)
        {
            try
            {
                var obj = _mapper.Map<TeacherClass>(teacherClass);
                var newObj = await _service.AddTeacherClass(obj);
                return Ok(newObj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeacherClass(TeacherClass teacherClass)
        {
            try
            {
                var obj = _mapper.Map<TeacherClass>(teacherClass);
                var updateObj = await _service.UpdateTeacherClass(obj);
                return Ok(updateObj);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{teacherId}/{classId}")]
        public async Task<IActionResult> RemoveTeacherFromClass(Guid teacherId, string classId)
        {
            try
            {
                var result = await _service.RemoveTeacherFromClass(teacherId, classId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
