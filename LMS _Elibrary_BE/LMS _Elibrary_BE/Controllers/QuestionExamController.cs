using AutoMapper;
using LMS__Elibrary_BE.Models.Exams;
using LMS__Elibrary_BE.Services.QuestionExamServices;
using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionExamController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IQuestionExamService _questionExamService;

        public QuestionExamController(IMapper mapper, IQuestionExamService questionExamService)
        {
            _mapper = mapper;
            _questionExamService = questionExamService;
        }


        [HttpGet("question-for-exam/{examId}")]
        public async Task<IActionResult> GetQuestionsForExam(string examId)
        {
            try
            {
                var questions = await _questionExamService.GetQuestionsForExam(examId);
                return Ok(questions);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("exams-for-question/{questionId}")]
        public async Task<IActionResult> GetExamsForQuestion(int questionId)
        {
            try
            {
                var exams = await _questionExamService.GetExamsForQuestion(questionId);
                return Ok(exams);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get-MC-Answer")]
        public async Task<IActionResult> GetMCAnswersForQuestion(int questionId)
        {
            try
            {
                var answer = await _questionExamService.GetMCAnswersForQuestion(questionId);
                return Ok(answer);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get-ES-Answer")]
        public async Task<IActionResult> GetESAnswersForQuestion(int questionId)
        {
            try
            {
                var answer = await _questionExamService.GetEssayAnswersForQuestion(questionId);
                return Ok(answer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-question-to-exam")]
        public async Task<IActionResult> AddQuestionToExam(string examId, int questionId)
        {
            try
            {
                var result = await _questionExamService.AddQuestionToExam(examId, questionId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create-New-Exam")]
        public async Task<IActionResult> CreateNewExam([FromBody] ExamCreationRequest examCreationRequest)
        {
            try
            {
                var rs = await _questionExamService.CreateNewExamFromQuestionBank(examCreationRequest);
                return Ok(rs);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update-Answer-Content")]
        public async Task<IActionResult> UpdateAnswerContent(int questionId, string newAnswerContent)
        {
            try
            {
                var rs = await _questionExamService.UpdateAnswerContent(questionId, newAnswerContent);
                return Ok(rs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("delete-question-to-exam")]
        public async Task<IActionResult> RemoveQuestionFromExam(string examId, int questionId)
        {
            try
            {
                var result = await _questionExamService.RemoveQuestionFromExam(examId, questionId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
