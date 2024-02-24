using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LMS_Library_API.Models.Notification
{
    public class NotificationSetting
    {
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        [ForeignKey("NotificationFeatures")]
        public int FeaturesId { get; set; }

        [Required]
        public bool ReceiveNotification { get; set; }

        // Navigation property
        [JsonIgnore]
        public virtual User User { get; set; }

        public virtual NotificationFeatures NotificationFeatures { get; set; }
    }
}
