using AutoMapper;
using LMS__Elibrary_BE.Services.StudyHistoryServices;
using LMS_Library_API.Models.AboutStudent;
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


        [HttpPut("UpdateStudyHistory")]
        public async Task<IActionResult> UpdateStudyHistory(StudyHistory studyHistory)
        {
            try
            {
                var studyHis = await _studyHistoryService.UpdateStudyHistory(studyHistory);
                return Ok(studyHis);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete-Study-History/{studentId}")]
        public async Task<IActionResult> DeleteAllHistory(Guid studentId)
        {
            try
            {
                var rs = await _studyHistoryService.DeleteAllStudyHistoryForStudent(studentId);
                return Ok(rs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
