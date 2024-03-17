using AutoMapper;
using LMS__Elibrary_BE.Services.LessonServices;
using LMS_Library_API.Models.AboutSubject;
using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : Controller
    {
        private readonly ILessonService _lessonService;
        private readonly IMapper _mapper;
        public LessonController(IMapper mapper, ILessonService lessonService)
        {
            _mapper = mapper;
            _lessonService = lessonService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllLessons()
        {
            try
            {
                var lessons = await _lessonService.GetAllLessons();
                return Ok(lessons);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("LessonById/{lessonId}")]
        public async Task<IActionResult> GetLessonById(int lessonId)
        {
            try
            {
                var lesson = await _lessonService.GetLessonById(lessonId);
                return Ok(lesson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("LessonByPart/{partId}")]
        public async Task<IActionResult> GetLessonsByPart(int partId)
        {
            try
            {
                var lesson = await _lessonService.GetLessonsByPart(partId);
                return Ok(lesson);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("LessonByTeacher/{teacherId}")]
        public async Task<IActionResult> GetLessonsByTeacher(Guid teacherId)
        {
            try
            {
                var lesson = await _lessonService.GetLessonsByTeacher(teacherId);
                return Ok(lesson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddLesson(Lesson lesson)
        {
            try
            {
                var newLesson = await _lessonService.AddLesson(lesson);
                return Ok(newLesson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateLesson/{lessonId}")]
        public async Task<IActionResult> UpdateLesson(int lessonId, Lesson updatedLesson)
        {
            try
            {
                var lessonObj = await _lessonService.UpdateLesson(lessonId, updatedLesson);
                return Ok(lessonObj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{lessonId}")]
        public async Task<IActionResult> DeleteLesson(int lessonId)
        {
            try
            {
                var result = await _lessonService.DeleteLesson(lessonId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
