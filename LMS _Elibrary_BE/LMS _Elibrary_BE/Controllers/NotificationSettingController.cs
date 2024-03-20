using AutoMapper;
using LMS__Elibrary_BE.Services.NotificationSettingServices;
using LMS_Library_API.Models.Notification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class NotificationSettingController : Controller
    {
        private readonly IMapper _mapper;
        private readonly INotificationSettingService _notificationSettingService;
        public NotificationSettingController(IMapper mapper, INotificationSettingService notificationSettingService)
        {
            _mapper = mapper;
            _notificationSettingService = notificationSettingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNotificationSettings()
        {
            try
            {
                var result = await _notificationSettingService.GetAllNotificationSettings();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("User/{userId}")]
        public async Task<IActionResult> GetNotificationSettingsByUserId(Guid userId)
        {
            try
            {
                var result = await _notificationSettingService.GetNotificationSettingsByUserId(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{userId}/{featureId}")]
        public async Task<IActionResult> GetNotificationSettingByUserIdAndFeaturesId(Guid userId, int featuresId)
        {
            try
            {
                var result = await _notificationSettingService.GetNotificationSettingByUserIdAndFeaturesId(userId, featuresId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNotificationSetting(NotificationSetting notificationSetting)
        {
            try
            {
                var result = await _notificationSettingService.AddNotificationSetting(notificationSetting);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNotificationSetting(NotificationSetting notificationSetting)
        {
            try
            {
                var result = await _notificationSettingService.UpdateNotificationSetting(notificationSetting);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{userId}/{featureId}")]
        public async Task<IActionResult> DeleteNotificationSetting(Guid userId, int featuresId)
        {
            try
            {
                var result = await _notificationSettingService.DeleteNotificationSetting(userId, featuresId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
