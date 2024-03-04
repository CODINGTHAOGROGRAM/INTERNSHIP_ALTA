using AutoMapper;
using LMS__Elibrary_BE.ModelsDTO;
using LMS__Elibrary_BE.Services.ExamServices;
using LMS_Library_API.Models.Exams;
using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IExamService _examService;
        public ExamController(IMapper mapper, IExamService examService)
        {
            _mapper = mapper;
            _examService = examService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExam()
        {
            try
            {
                var exams = await _examService.GetAllExam();
                return Ok(exams);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetExam/{examId}")]
        public async Task<IActionResult> GetById(string examId)
        {
            try
            {
                var exam = await _examService.GetExamById(examId);
                return Ok(exam);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetExam/{userId}")]
        public async Task<IActionResult> GetByUser(string userId)
        {
            try
            {
                var existingExam = await _examService.GetExamByUserId(userId);
                return Ok(existingExam);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        

        [HttpGet("Search")]
        public async Task<IActionResult> SearchExam(string searchTerm, string[] searchFields = null)
        {
            try
            {
                var search = await _examService.SearchExam(searchTerm, searchFields);
                return Ok(search);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddNew")]
        public async Task<IActionResult> AddNewExam(ExamDTO newExam)
        {
            try
            {
                var exam = _mapper.Map<Exam>(newExam);
                var examObj = await _examService.AddNewExam(exam);
                return Ok(examObj);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteExam")]
        public async Task<IActionResult> DeleteExam(string examId)
        {
            try
            {
                var examObj = await _examService.DeleteExam(examId);
                return Ok(examObj);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("UpdateExam")]
        public async Task<IActionResult> UpdateExam(ExamDTO Exam)
        {
            try
            {
                var exam = _mapper.Map<Exam>(Exam);
                var examObj = await _examService.UpdateExam(exam);
                return Ok(examObj);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
