using AutoMapper;
using LMS__Elibrary_BE.ModelsDTO;
using LMS__Elibrary_BE.Services.SubjectServices;
using LMS_Library_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ISubjectService _subjectService;
        public SubjectController(IMapper mapper, ISubjectService subjectService)
        {
            _mapper = mapper;
            _subjectService = subjectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubject()
        {
            try
            {
                var subjects = await _subjectService.GetSubjects();
                return Ok(subjects);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{subjectId}")]
        public async Task<IActionResult> GetSubjectId(string subjectId)
        {
            try
            {
                var subject = await _subjectService.GetSubjectById(subjectId);
                return Ok(subject);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetSubjects/{userId}")]
        public async Task<IActionResult> GetSubjectsByUserId(string userId)
        {
            try
            {
                var subjects = await _subjectService.GetSubjectByUserId(userId);
                return Ok(subjects);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("SearchSubject")]
        public async Task<IActionResult> SearchSubject(string searchTerm, string[] searchFields = null)
        {
            try
            {
                var result = await _subjectService.SearchSubjects(searchTerm, searchFields);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 

        [HttpPost("AddStudentToSubject")]
        public async Task<IActionResult> AddStudentToSubject(string subjectId, string studentId)
        {
            try
            {
                var result = await _subjectService.AddStudentToSubject(subjectId, studentId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddNewSubject")]
        public async Task<IActionResult> AddNewSubject(SubjectDTO newSubject)
        {
            try
            {
                var subject = _mapper.Map<Subject>(newSubject);
                var result = await _subjectService.AddNewSubject(subject);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("mark-as-read/{subjectId}/{studentId}")]
        public async Task<IActionResult> MarkSubjectAsRead(string subjectId, string studentId)
        {
            try
            {
                var isMarkedAsRead = await _subjectService.MarkSubjectAsRead(subjectId, studentId);

                if (isMarkedAsRead)
                    return Ok("Môn học đã được đánh dấu là đã đọc.");
                else
                    return NotFound("Không tìm thấy môn học hoặc sinh viên.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       
        [HttpDelete("DeleteSubject/{subjectId}")]
        public async Task<IActionResult> DeleteSubject(string subjectId)
        {
            try
            {
                var result = await _subjectService.DeleteSubject(subjectId);
                return Ok(result);   
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("RemoveStuFromSubject/{subjectId}/{StudentId}")]
        public async Task<IActionResult> RemoveStudentFromSubject(string subjectId, string studentId)
        {
            try
            {
                var result = await _subjectService.RemoveStudentFromSubject(subjectId, studentId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("toggle-favorite/{subjectId}/{studentId}")]
        public async Task<IActionResult> ToggleFavoriteSubject(string subjectId, string studentId)
        {
            try
            {
                var isFavorite = await _subjectService.ToggleFavoriteSubject(subjectId, studentId);
                return Ok(isFavorite);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateSubject")]
        public async Task<IActionResult> UpdateSubject(SubjectDTO subjectObj)
        {
            try
            {
                var subject = _mapper.Map<Subject>(subjectObj);
                var updateSub = await _subjectService.UpdateSubject(subject);
                return Ok(updateSub);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
