using System.ComponentModel.DataAnnotations.Schema;

namespace LMS__Elibrary_BE.Models.Notifications
{
    public class NotificationSetting
    {

        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public virtual Users Users { get; set; }
    }
}
