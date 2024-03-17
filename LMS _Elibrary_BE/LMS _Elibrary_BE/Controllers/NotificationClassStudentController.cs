using AutoMapper;
using LMS__Elibrary_BE.ModelsDTO;
using LMS__Elibrary_BE.Services.NotificationClassStudentServices;
using LMS_Library_API.Models.AboutSubject;
using LMS_Library_API.Models.Notification;
using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationClassStudentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly INotificationClassStudentService _notificationClassStudentService;
        public NotificationClassStudentController(INotificationClassStudentService notificationClassStudentService, IMapper mapper)
        {
            _mapper = mapper;
            _notificationClassStudentService = notificationClassStudentService;
        }
        [HttpGet("{classId}")]
        public async Task<IActionResult> GetNotificationsForClass(string classId)
        {
            try
            {
                var notifications = await _notificationClassStudentService.GetNotificationsForClass(classId);
                return Ok(notifications);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetNotificationsForStudent(Guid studentId)
        {
            try
            {
                var notifications = await _notificationClassStudentService.GetNotificationsForStudent(studentId);
                return Ok(notifications);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var notifications = await _notificationClassStudentService.GetNotifications();
                return Ok(notifications);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNotification(NotificationClassStudentDTO notification)
        {
            try
            {
                var obj = _mapper.Map<NotificationClassStudent>(notification);
                var newNotification = await _notificationClassStudentService.AddNotification(obj);
                return Ok(newNotification);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNotification(NotificationClassStudentDTO updatedNotification)
        {
            try
            {
                var obj = _mapper.Map<NotificationClassStudent>(updatedNotification);
                var ex = await _notificationClassStudentService.UpdateNotification(obj);
                return Ok(ex);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("{classId}")]
        public async Task<IActionResult> RemoveNotificationFromClass(string classId)
        {
            try
            {
                var del = await _notificationClassStudentService.RemoveNotificationFromClass(classId);
                return Ok(del);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpDelete("{student}")]
        public async Task<IActionResult> RemoveNotificationFromStudent(Guid studentId)
        {
            try
            {
                var del = await _notificationClassStudentService.RemoveNotificationFromStudent(studentId);
                return Ok(del);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
