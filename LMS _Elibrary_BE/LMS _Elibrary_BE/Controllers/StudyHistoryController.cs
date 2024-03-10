using AutoMapper;
using LMS__Elibrary_BE.Services.StudyHistoryServices;
using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyHistoryController : Controller
    {
        private readonly IStudyHistoryService _studyHistoryService;
        private readonly IMapper _mapper;
        public StudyHistoryController(IStudyHistoryService studyHistoryService, IMapper mapper)
        {
            _studyHistoryService = studyHistoryService;
            _mapper = mapper;
        }

        [HttpGet("GetHistoryForStudent/{studentId}")]
        public async Task<IActionResult> GetStudyHistoryForStudent(Guid studentId)
        {
            try
            {
                var resualt = await _studyHistoryService.GetStudyHistoryForStudent(studentId);
                return Ok(resualt);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetDocumetForStudent/{studentId}")]
        public async Task<IActionResult> GetDocumentsWatchedByStudent(Guid studentId)
        {
            try
            {
                var documentStudent = await _studyHistoryService.GetDocumentsWatchedByStudent(studentId);
                return Ok(documentStudent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddHistory")]
        public async Task<IActionResult> AddStudyHistory(Guid studentId, int documentId, int watchMinutes)
        {
            try
            {
                var rs = await _studyHistoryService.AddStudyHistory(studentId, documentId, watchMinutes);
                return Ok(rs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
