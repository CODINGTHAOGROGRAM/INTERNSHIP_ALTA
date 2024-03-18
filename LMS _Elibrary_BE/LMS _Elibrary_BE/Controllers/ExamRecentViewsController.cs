using AutoMapper;
using LMS__Elibrary_BE.ModelsDTO;
using LMS__Elibrary_BE.Services.ExamRecentViewsServices;
using LMS_Library_API.Models.AboutUser;
using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamRecentViewsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IExamRecentViewsService _service;
        public ExamRecentViewsController(IMapper mapper, IExamRecentViewsService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExamRecentViews()
        {
            try
            {
                var result = await _service.GetAllExamRecentViews();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ExamView/{userId}")]
        public async Task<IActionResult> GetExamRecentViewsByUserId(Guid userId)
        {
            try
            {
                var result = await _service.GetExamRecentViewsByUserId(userId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("ExamView/{examId}")]
        public async Task<IActionResult> GetExamRecentViewsByExamId(string examId)
        {
            try
            {
                var result = await _service.GetExamRecentViewsByExamId(examId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddExamRecentViews(ExamRecentDTO examRecentViews)
        {
            try
            {
                var newEx = _mapper.Map<ExamRecentViews>(examRecentViews);
                var result = await _service.AddExamRecentViews(newEx);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateExamRecentViews(ExamRecentDTO examRecentViews)
        {
            try
            {
                var newEx = _mapper.Map<ExamRecentViews>(examRecentViews);
                var result = await _service.UpdateExamRecentViews(newEx);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{examId}/{userId}")]
        public async Task<IActionResult> DeleteExamRecentViews(Guid userId, string examId)
        {
            try
            {
                var result = await _service.DeleteExamRecentViews(userId, examId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
