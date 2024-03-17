using AutoMapper;
using LMS__Elibrary_BE.ModelsDTO;
using LMS__Elibrary_BE.Services.LessonQuestionServices;
using LMS_Library_API.Models.AboutSubject;
using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonQuestionController : Controller
    {
        private readonly ILessonQuestionService _lessonQuestionService;
        private readonly IMapper _mapper;
        public LessonQuestionController(IMapper mapper, ILessonQuestionService lessonQuestionService)
        {
            _lessonQuestionService = lessonQuestionService;
            _mapper = mapper;
        }

        [HttpGet("GetQuestionForLesson/{lessonId}")]
        public async Task<IActionResult> GetQuestionsForLesson(int lessonId)
        {
            try
            {
                var questions = await _lessonQuestionService.GetQuestionsForLesson(lessonId);
                return Ok(questions);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get-All")]
        public async Task<IActionResult> GetQuestions()
        {
            try
            {
                var questions = await _lessonQuestionService.GetQuestions();
                return Ok(questions);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{questionId}")]
        public async Task<IActionResult> GetQuestionById(int questionId)
        {
            try
            {
                var question = await _lessonQuestionService.GetQuestionById(questionId);
                return Ok(question);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddQuestionForLesson")]
        public async Task<IActionResult> AddQuestionToLesson(LessonQuestionDTO question)
        {
            try
            {
                var ques = _mapper.Map<LessonQuestion>(question);
                var newQuestion = await _lessonQuestionService.AddQuestionToLesson(ques);
                return Ok(newQuestion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateQuestion")]
        public async Task<IActionResult> UpdateQuestionForLesson(int questionId, LessonQuestion updatedQuestion)
        {
            try
            {
                var question = await _lessonQuestionService.UpdateQuestionForLesson(questionId, updatedQuestion);
                return Ok(question);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{questionId}")]
        public async Task<IActionResult> eleteQuestionFromLesson(int questionId)
        {
            try
            {
                var ex = await _lessonQuestionService.DeleteQuestionFromLesson(questionId);
                return Ok(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
