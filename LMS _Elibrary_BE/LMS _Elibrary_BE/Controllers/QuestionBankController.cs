using AutoMapper;
using LMS__Elibrary_BE.ModelsDTO;
using LMS__Elibrary_BE.Services.QuestionBankServices;
using LMS_Library_API.Models.Exams;
using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionBankController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IQuestionBankService _questionBankService;
        public QuestionBankController(IMapper mapper, IQuestionBankService questionBankService)
        {
            _mapper = mapper;
            _questionBankService = questionBankService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuestion()
        {
            try
            {
                var questions = await _questionBankService.GetAllQuestionBanks();
                return Ok(questions);
            }
             catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }   
        }

        [HttpGet("GetQuestion/{questionId}")]
        public async Task<IActionResult> GetQuestionById(int questionId)
        {
            try
            {
                var question = await _questionBankService.GetQuestionBankId(questionId);
                return Ok(question);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPost("AddNewQuestion")]
        public async Task<IActionResult> AddNewQuestion(QuestionBankDTO newQuestion)
        {
            try
            {
                var question = _mapper.Map<QuestionBanks>(newQuestion);
                var newQues = await _questionBankService.AddNew(question);
                return Ok(newQues);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateQuestion")]
        public async Task<IActionResult> UpdateQuestion(QuestionBankDTO questionObj)
        {
            try
            {
                var question = _mapper.Map<QuestionBanks>(questionObj);
                var newQuestion = await _questionBankService.UpdateQuestionBank(question);
                return Ok(newQuestion);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteQuestion/{questionId}")]
        public async Task<IActionResult> DeleteQuestion(int questionId)
        {
            try
            {
                var question = await _questionBankService.DeleteQuestionBank(questionId);
                return Ok(question);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Search")]
        public async Task<IActionResult> SearchQuestionBanks(string searchTerm, string[] searchFields = null)
        {
            try
            {
                var result = await _questionBankService.SearchQuestionBanks(searchTerm, searchFields);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("RandomQuestion")]
        public async Task<IActionResult> RandomQuestionBank()
        {
            try
            {
                var questionBank = await _questionBankService.GetRandomQuestionBank();
                return Ok(questionBank);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetQuestionByTopic")]
        public async Task<IActionResult> GetQuestionBankByTopic(int topicId)
        {
            try
            {
                var questionList = await _questionBankService.GetQuestionBanksByTopic(topicId);
                return Ok(questionList);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Pagination")]
        public async Task<IActionResult> PaginationQuestionBank(int pageSize, int pageNumber)
        {
            try
            {
                var pagination = await _questionBankService.PaginationQuestionBanks(pageNumber, pageSize);
                return Ok(pagination);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       
    }
}
