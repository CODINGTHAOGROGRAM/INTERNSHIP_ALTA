using LMS__Elibrary_BE.Services.StudentQvsALikeServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class StudentQvsALikeController : Controller
    {
        private readonly IStudentQvsAService _studentQvsAService;
        public StudentQvsALikeController(IStudentQvsAService studentQvsAService)
        {
            _studentQvsAService = studentQvsAService;
        }


        [HttpGet("Questions")]
        public async Task<IActionResult> GetQuestionsLikedByStudent(Guid studentId)
        {
            try
            {
                var result = await _studentQvsAService.GetQuestionsLikedByStudent(studentId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Answers")]

        public async Task<IActionResult> GetAnswersLikedByStudent(Guid studentId)
        {
            try
            {
                var result = await _studentQvsAService.GetAnswersLikedByStudent(studentId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("GetStudentLikeQuestion")]
        public async Task<IActionResult> GetStudentsWhoLikedQuestion(string questionId)
        {
            try
            {
                var student = await _studentQvsAService.GetStudentsWhoLikedQuestion(questionId);
                return Ok(student);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetStudentLikeAnswer")]
        public async Task<IActionResult> GetStudentsWhoLikedAnswer(string questionId)
        {
            try
            {
                var student = await _studentQvsAService.GetStudentsWhoLikedAnswer(questionId);
                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("questions/{questionId}/toggle/{studentId}")]
        public async Task<IActionResult> ToggleQuestionLike(Guid studentId, string questionId)
        {
            try
            {
                await _studentQvsAService.ToggleQuestionLike(studentId, questionId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpPost("answers/{answerId}/toggle/{studentId}")]
        public async Task<IActionResult> ToggleAnswerLike(Guid studentId, string answerId)
        {
            try
            {
                await _studentQvsAService.ToggleAnswerLike(studentId, answerId);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
    }
}
