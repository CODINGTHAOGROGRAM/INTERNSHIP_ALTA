using LMS__Elibrary_BE.Services.NotificationFeaturesServices;
using LMS_Library_API.Models.Notification;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;

namespace LMS__Elibrary_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationFeatureController : Controller
    {
        private readonly INotificationFeaturesService _notificationFeaturesService;
        public NotificationFeatureController(INotificationFeaturesService notificationFeaturesService)
        {
            _notificationFeaturesService = notificationFeaturesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNotificationFeatures()
        {
            try
            {
                var result = await _notificationFeaturesService.GetAllNotificationFeatures();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Notification/{featureId}")]
        public async Task<IActionResult> GetNotificationFeaturesById(int featuresId)
        {
            try
            {
                var result = await _notificationFeaturesService.GetNotificationFeaturesById(featuresId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNotificationFeatures(NotificationFeatures notificationFeatures)
        {
            try
            {
                var result = await _notificationFeaturesService.AddNotificationFeatures(notificationFeatures);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNotificationFeatures(int featuresId, NotificationFeatures updatedNotificationFeatures)
        {
            try
            {
                var result = await _notificationFeaturesService.UpdateNotificationFeatures(featuresId, updatedNotificationFeatures);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{featureId}")]
        public async Task<IActionResult> DeleteNotificationFeatures(int featuresId)
        {
            try
            {
                var result = await _notificationFeaturesService.DeleteNotificationFeatures(featuresId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
