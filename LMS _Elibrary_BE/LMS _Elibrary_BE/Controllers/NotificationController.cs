using AutoMapper;
using LMS__Elibrary_BE.ModelsDTO;
using LMS__Elibrary_BE.Services.NotificationServices;
using LMS_Library_API.Models.Notification;
using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : Controller
    {
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;
        public NotificationController(IMapper mapper, INotificationService notificationService)
        {
            _mapper = mapper;
            _notificationService = notificationService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllNotifications()
        {
            try
            {
                var result = await _notificationService.GetAllNotifications();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Notification/{recipientId}")]
        public async Task<IActionResult> GetNotificationsByRecipientId(Guid recipientId)
        {
            try
            {
                var result = await _notificationService.GetNotificationsByRecipientId(recipientId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("UnRead/{recipientId}")]
        public async Task<IActionResult> GetUnreadNotificationsByRecipientId(Guid recipientId)
        {
            try
            {
                var result = await _notificationService.GetUnreadNotificationsByRecipientId(recipientId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNotification(NotificationDTO notification)
        {
            try
            {
                var obj = _mapper.Map<Notification>(notification);
                var newObj = await _notificationService.AddNotification(obj);
                return Ok(newObj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("MarkRead/{notificationId}")]
        public async Task<IActionResult> MarkNotificationAsRead(int notificationId)
        {
            try
            {
                var result = await _notificationService.MarkNotificationAsRead(notificationId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("notificationId")]
        public async Task<IActionResult> DeleteNotification(int notificationId)
        {
            try
            {
                var result = await _notificationService.DeleteNotification(notificationId);
                return Ok(result);
            }
            catch( Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
