using AutoMapper;
using LMS__Elibrary_BE.ModelsDTO;
using LMS__Elibrary_BE.Services.SubjectNotificationServices;
using LMS_Library_API.Models.AboutSubject;
using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectNotificationController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ISubjectNotificationService _subjectNotificationService;
        public SubjectNotificationController(IMapper mapper, ISubjectNotificationService subjectNotificationService)
        {
            _mapper = mapper;
            _subjectNotificationService = subjectNotificationService;
        }


        [HttpGet]
        public async Task<IActionResult> GetNotifications()
        {
            try
            {
                var notifications = await _subjectNotificationService.GetNotifications();
                return Ok(notifications);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{notificationId}")]
        public async Task<IActionResult> GetNotificationsById(int notificationId)
        {
            try
            {
                var notification = await _subjectNotificationService.GetNotificationsById(notificationId);
                return Ok(notification);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Notification/{subjectId}")]
        public async Task<IActionResult> GetNotificationsForSubject(string subjectId)
        {
            try
            {
                var notification = await _subjectNotificationService.GetNotificationsForSubject(subjectId);
                return Ok(notification);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Notification/{teacherId}")]
        public async Task<IActionResult> GetNotificationsForTeacher(Guid teacherId)
        {
            try
            {
                var notification = await _subjectNotificationService.GetNotificationsForTeacher(teacherId);
                return Ok(notification);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNotification(SubjectNotificationDTO notification)
        {
            try
            {
                var notifi = _mapper.Map<SubjectNotification>(notification);
                var newNotification = await _subjectNotificationService.AddNotification(notifi);
                return Ok(newNotification);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNotification(SubjectNotification updatedNotification)
        {
            try
            {
                var obj = _mapper.Map<SubjectNotification>(updatedNotification);
                var newNoti = await _subjectNotificationService.UpdateNotification(updatedNotification);
                return Ok(newNoti);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Notification/{notificationId}")]
        public async Task<IActionResult> DeleteNotification(int notificationId)
        {
            try
            {
                var result = await _subjectNotificationService.RemoveNotification(notificationId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
