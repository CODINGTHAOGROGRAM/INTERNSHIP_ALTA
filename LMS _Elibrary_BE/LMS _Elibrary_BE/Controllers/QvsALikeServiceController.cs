using AutoMapper;
using LMS__Elibrary_BE.Services.QvsAServices;
using LMS_Library_API.Models.AboutUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class QvsALikeServiceController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IQvsAService _qvsAService;
        public QvsALikeServiceController(IMapper mapper, IQvsAService qvsAService)
        {
            _mapper = mapper;
            _qvsAService = qvsAService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetQnALikesByUserId(Guid userId)
        {
            try
            {
                var result = await _qvsAService.GetQnALikesByUserId(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Question/{questionId}")]
        public async Task<IActionResult> GetLikedQuestionsById(Guid userId)
        {
            try
            {
                var result = await _qvsAService.GetLikedQuestionsById(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Answer/{answerId}")]
        public async Task<IActionResult> GetLikedAnswersById(Guid userId)
        {
            try
            {
                var result = await _qvsAService.GetLikedAnswersById(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateQnALikes(Guid userId, QnALikeDTO updatedQnALikes)
        {
            try
            {
                var obj = _mapper.Map<QnALikeDTO>(updatedQnALikes);
                var updateObj = await _qvsAService.UpdateQnALikes(userId, updatedQnALikes);
                return Ok(updateObj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Question/{userId}")]
        public async Task<IActionResult> ClearLikedQuestions(Guid userId)
        {
            try
            {
                var result = await _qvsAService.ClearLikedQuestions(userId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Answer/{userId}")]
        public async Task<IActionResult> ClearLikedAnswers(Guid userId)
        {
            try
            {
                var result = await _qvsAService.ClearLikedAnswers(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
