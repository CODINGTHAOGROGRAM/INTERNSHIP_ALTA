using AutoMapper;
using LMS__Elibrary_BE.ModelsDTO;
using LMS__Elibrary_BE.Services.LessonAnswerServices;
using LMS_Library_API.Models.AboutSubject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LessonAnswerController : Controller
    {
        private readonly ILessonAnswerService _lessonAnswerService;
        private readonly IMapper _mapper;
        public LessonAnswerController(ILessonAnswerService lessonAnswerService, IMapper mapper)
        {
            _lessonAnswerService = lessonAnswerService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAnswerLesson()
        {
            try
            {
                var answers = await _lessonAnswerService.GetAllAnswers();
                return Ok(answers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAnswerForLesson/{lessonQuestionId}")]
        public async Task<IActionResult> GetAnswersForLessonQuestion(int lessonQuestionId)
        {
            try
            {
                var answers = await _lessonAnswerService.GetAnswersForLessonQuestion(lessonQuestionId);
                return Ok(answers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("AnswerId/{answerId}")]
        public async Task<IActionResult> GetAnswerById(int answerId)
        {
            try
            {
                var answer = await _lessonAnswerService.GetAnswerById(answerId);
                return Ok(answer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAnswerToLessonQuestion(LessonAnswerDTO answer)
        {
            try
            {
                var ans = _mapper.Map<LessonAnswer>(answer);
                var newAnswer = await _lessonAnswerService.AddAnswerToLessonQuestion(ans);
                return Ok(newAnswer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{answerId}")]
        public async Task<IActionResult> UpdateAnswerToLessonQuestion(int answerId, LessonAnswerDTO updatedAnswer)
        {
            try
            {
                var ans = _mapper.Map<LessonAnswer>(updatedAnswer);
                var answerObj = await _lessonAnswerService.UpdateAnswerToLessonQuestion(answerId, ans);
                return Ok(answerObj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("{answerId}")]
        public async Task<IActionResult> DeleteAnswerToLessonQuestion(int answerId)
        {
            try
            {
                var ex = await _lessonAnswerService.DeleteAnswerToLessonQuestion(answerId);
                return Ok(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
