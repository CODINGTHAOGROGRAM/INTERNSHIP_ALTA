using AutoMapper;
using LMS__Elibrary_BE.Services.StudyTimeServices;
using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyTimeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IStudyTimeService _studyTimeService;
        public StudyTimeController(IMapper mapper, IStudyTimeService studyTimeService)
        {
            _mapper = mapper;
            _studyTimeService = studyTimeService;
        }


        [HttpGet("Study-Time-Student/{studentId}")]
        public async Task<IActionResult> GetStudyTimeForStudent(Guid studentId)
        {
            try
            {
                var studies = await _studyTimeService.GetStudyTimeForStudent(studentId);
                return Ok(studies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Subject-By-Study-time/{studentId}")]
        public async Task<IActionResult> GetSubjectsStudiedByStudent(Guid studentId)
        {
            try
            {
                var result = await _studyTimeService.GetSubjectsStudiedByStudent(studentId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add-Study-Time")]
        public async Task<IActionResult> AddStudyTime(Guid studentId, string subjectId, int totalTime)
        {
            try
            {
                var newStudy = _studyTimeService.AddStudyTime(studentId, subjectId, totalTime);
                return Ok(newStudy);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
