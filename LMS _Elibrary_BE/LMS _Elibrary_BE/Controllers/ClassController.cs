using AutoMapper;
using LMS__Elibrary_BE.ModelsDTO;
using LMS__Elibrary_BE.Services.ClassServices;
using LMS_Library_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class ClassController : Controller
    {
        private readonly IClassService _classService;
        private readonly IMapper _mapper;
        public ClassController(IClassService classService, IMapper mapper)
        {
            _classService = classService;
            _mapper = mapper;
        }


        [HttpPost("AddClass")]
        public async Task<IActionResult> AddNewClass(ClassDTO newClass)
        {
            try
            {
                var classObj = _mapper.Map<Class>(newClass); 
                string result = await _classService.AddNewClass(classObj);
                return Ok(result); // Trả về thông báo thành công
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Trả về lỗi 500 và thông báo lỗi
            }
        }

        [HttpDelete("DeleteClass/{classId}")]
        public async Task<IActionResult> DeleteClass(string id)
        {
            try
            {
                string result = await _classService.DeleteClass(id);
                return Ok(result); // Trả về thông báo thành công
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Trả về lỗi 500 và thông báo lỗi
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClasses()
        {
            try
            {
                var classes = await _classService.GetAllClass();
                return Ok(classes); // Trả về danh sách các lớp học
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Trả về lỗi 500 và thông báo lỗi
            }
        }

        [HttpGet("{classId}")]
        public async Task<IActionResult> GetClassById(string classId)
        {
            try
            {
                var classObj = await _classService.GetById(classId);
                return Ok(classObj); // Trả về lớp học có ID tương ứng
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Trả về lỗi 500 và thông báo lỗi
            }
        }

        [HttpPut("UpdateFile")]
        public async Task<IActionResult> UpdateClass(ClassDTO newClass)
        {
            try
            {
                var classObj = _mapper.Map<Class>(newClass);
                string result = await _classService.UpdateClass(classObj);
                return Ok(result); // Trả về thông báo thành công
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Trả về lỗi 500 và thông báo lỗi
            }
        }

    }
}
