using AutoMapper;
using LMS__Elibrary_BE.Services.ClassSubjectServices;
using LMS_Library_API.Models.AboutStudent;
using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLassSubjectController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IClassSubjectService _classSubjectService;
        
        public CLassSubjectController(IMapper mapper, IClassSubjectService classSubjectService)
        {
            _mapper = mapper;
            _classSubjectService = classSubjectService;
        }


        [HttpGet]
        public async Task<IActionResult> GetALlClassSubject()
        {
            try
            {
                var classSubjects = await _classSubjectService.GetAllClassSubjects();
                return Ok(classSubjects);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("GetById/{classId}/{subjectId}")]
        public async Task<IActionResult> GetClassSubjectById(string classId, string subjectId)
        {
            try
            {
                var result = await _classSubjectService.GetClassSubjectById(classId, subjectId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ClassSubject/{classId}/{subjectId}/exists")]
        public async Task<IActionResult> IsClassSubjectExists(string classId, string subjectId)
        {
            try
            {
                if (string.IsNullOrEmpty(classId) || string.IsNullOrEmpty(subjectId))
                {
                    return BadRequest("Cần hai Id của class và subject để tìm");
                }

                var exists = await _classSubjectService.IsClassSubjectExists(classId, subjectId);

                return Ok(exists);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost("AddNewClassSubject")]
        public async Task<IActionResult> CreateClassSubject(ClassSubject classSubject)
        {
            try
            {
                var newClassSubject = await _classSubjectService.CreateClassSubject(classSubject);
                return Ok(newClassSubject);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
        }

        [HttpPut("UpdateClassSubject")]
        public async Task<IActionResult> UpdateClassSubject(string classId, string subjectId, ClassSubject updatedClassSubject)
        {
            try
            {
                var classSubject = await _classSubjectService.UpdateClassSubject(classId, subjectId, updatedClassSubject);
                return Ok(classSubject);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteClassSubject(string classId, string subjectId)
        {
            try
            {
                var result = await _classSubjectService.DeleteClassSubject(classId, subjectId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
